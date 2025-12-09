using Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Facad.inventory;
using Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Facade.Data;
using Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Facade.Email;
using Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Facade.Inventory;
using Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Facade.Payment;
using Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Facade.Shipping;

namespace Csharp_AdvancedConcepts.DesignPattern.Structural_Patterns.Facade.FacadePattern
{
    public class CheckoutFacade : ICheckoutFacade
    {
        private readonly IPaymentService _paymentService;
        private readonly IEmailService _emailService;
        private readonly IInventoryService _inventoryService;
        private readonly IShippingService _shippingService;
        public CheckoutFacade()
        {
            _paymentService = new PaymentService();
            _emailService = new EmailService();
            _inventoryService = new InventoryService();
            _shippingService = new ShippingService();
        }
        public CheckoutResult ProcessOrder(Order order)
        {
            var productAvailable = _inventoryService.CheckStock(order.ProductId);
            if (!productAvailable)
            {
                return new CheckoutResult
                {
                    OrderId = order.OrderId,
                    IsSuccessful = false,
                    ErrorMessage = "Product is out of stock."
                };
            }
            var paymentResult = _paymentService.ValidateCard(order.CardNumber);
            if (!paymentResult)
            {
                return new CheckoutResult
                {
                    OrderId = order.OrderId,
                    IsSuccessful = false,
                    ErrorMessage = "Payment validation failed."
                };
            }
            _inventoryService.ReserveStock(order.ProductId, order.Quantity);

            return new CheckoutResult
            {
                OrderId = order.OrderId,
                IsSuccessful = true,
                ErrorMessage = string.Empty
            };
        }
    }
}
