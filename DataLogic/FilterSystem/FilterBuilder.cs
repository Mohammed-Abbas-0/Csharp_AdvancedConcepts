using DataLogic.Enum;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;

namespace DataLogic.FilterSystem;
public class FilterBuilder<T>
{
    private List<FilterCondition> _conditions = new();

    public FilterBuilder<T> AddCondition(string propertyName, FilterOperation operation, object value)
    {
        _conditions.Add(new FilterCondition
        {
            PropertyName = propertyName,
            Operation = operation,
            Value = value
        });
        return this;
    }

    public Expression<Func<T, bool>> Build()
    {
        ParameterExpression param = Expression.Parameter(typeof(T), "x");
        Expression? combined = null;
        foreach (var condition in _conditions)
        {
            MemberExpression member = Expression.PropertyOrField(param, condition.PropertyName);
            ConstantExpression constant = Expression.Constant(Convert.ChangeType(condition.Value, member.Type));
            Expression? binaryExpression = condition.Operation switch
            {
                FilterOperation.Equals => Expression.Equal(member, constant),
                FilterOperation.NotEquals => Expression.NotEqual(member, constant),
                FilterOperation.GreaterThan => Expression.GreaterThan(member, constant),
                FilterOperation.LessThan => Expression.LessThan(member, constant),
                FilterOperation.GreaterThanOrEqual => Expression.GreaterThanOrEqual(member, constant),
                FilterOperation.LessThanOrEqual => Expression.LessThanOrEqual(member, constant),
                FilterOperation.Contains => Expression.Call(member, typeof(string).GetMethod("Contains", new[] { typeof(string) })!, constant),
                FilterOperation.StartsWith => Expression.Call(member, typeof(string).GetMethod("StartsWith", new[] { typeof(string) })!, constant),
                FilterOperation.EndsWith => Expression.Call(member, typeof(string).GetMethod("EndsWith", new[] { typeof(string) })!, constant),
                _ => throw new NotSupportedException($"Operation {condition.Operation} is not supported.")
            };
            combined = combined == null ? binaryExpression : Expression.AndAlso(combined, binaryExpression);
        }
        return Expression.Lambda<Func<T, bool>>(combined, param);

    }


    public T GetTypeOfPram(T obj)
    {
        if (typeof(T) == typeof(int))
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
            var addExp = Expression.Add(parameter, Expression.Constant(10));

            // لازم نحول الـ Expression لدالة ونشغلها
            var lambda = Expression.Lambda<Func<T, int>>(addExp, parameter);
            var func = lambda.Compile();

            int result = func(obj); // هنا الجمع حصل فعلاً
            return (T)(object)result; // بنحول النتيجة لنوع T عشان نرجعها
        }
        return obj;
    }

    public Expression<Func<T, bool>> BuildGreater(string propertyName, object threshold)
    {
        var paramter = Expression.Parameter(typeof(T), "x");
        var member = Expression.Property(paramter, propertyName);
        var constant = Expression.Constant(Convert.ChangeType(threshold, member.Type));
        var greaterExp = Expression.GreaterThan(member, constant);
        return Expression.Lambda<Func<T, bool>>(greaterExp, paramter);
    }



}

public static class ValidHelper<T>
{
    private static List<ValidationRule<T>> _rules = new();

    static List<Error> errors = new();
    public static ValidationResult Validate(T entity)
    {
        var result = new ValidationResult();
        var properties = typeof(T).GetProperties();

        foreach (var prop in properties)
        {
            var value = prop.GetValue(entity);

            // Check MinLength
            var minLengthAttr = prop.GetCustomAttribute<MinLengthAttribute>();
            if (minLengthAttr != null)
            {
                if (value == null || (value is string str && str.Length < minLengthAttr.Length))
                {
                    result.Errors.Add(new Error
                    {
                        PropertyName = prop.Name,
                        Message = $"{prop.Name} must be at least {minLengthAttr.Length} characters"
                    });
                }
            }
        }
        return result;
    }
    public static void AddRule(Expression<Func<T, bool>> condition, string errorMessage)
    {
        _rules.Add(new ValidationRule<T>
        {
            Condition = condition,
            ErrorMessage = errorMessage
        });
    }
}
public class ProductValid
{
    [MinLength(3)]
    public required string Name { get; set; }
    public int Price { get; set; }
}

public class ValidationResult
{
    public bool IsValid => !Errors.Any();
    public List<Error> Errors { get; set; } = new();
}

public class Error
{
    public required string Message { get; set; }
    public required string PropertyName { get; set; }
}