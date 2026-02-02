using DataLogic.Enum;

namespace DataLogic.FilterSystem;
public class FilterCondition
{
    public string PropertyName { get; set; }
    public FilterOperation Operation { get; set; }
    public object Value { get; set; }
}