using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModel;
using DataAccess;

namespace BusinessLogic
{
    public class QuotationBL
    {
        public static int Add(Quotation quotation, List<QuotationDetails> details)
        {
            int id = QuotationDA.Add(quotation);

            foreach (var d in details)
            {
                d.QuotationId = id;
            }
            if (QuotationDetailsDA.Add(details))
            {
                return id;
            }
            return 0;
        }

        public static bool UpdateOrderGenerated(int quotationId)
        {
            return QuotationDA.UpdateOrderGenerated(quotationId);
        }

        public static Quotation GetDetails(int quotationId)
        {
            return QuotationDA.GetDetails(quotationId);
        }
        public static List<Quotation> GetAllByClient(int clientId)
        {
            return QuotationDA.GetAllByClient(clientId);
        }

        public static int GenerateOrder(int quotationId)
        {
            var quotation = QuotationDA.GetDetails(quotationId);
            var quotationProducts = QuotationDetailsDA.GetAllDetailsForQuotation(quotationId);

            var order = new Order
            {
                ClientId = quotation.ClientId,
                OrderDate = DateTime.Now,
                TotalAmount = quotation.TotalPrice
            };
            var orderDetails = new List<OrderDetails>();
            var orderId = OrderDA.Add(order);

            if (orderId > 0)
            {
                foreach (var item in quotationProducts)
                {
                    var orderDetail = new OrderDetails
                    {
                        OrderId = orderId,
                        ProductLineId = item.ProductLineId,
                        Quantity = item.Quantity,
                        TotalProductPrice = item.TotalProductPrice
                    };

                    orderDetails.Add(orderDetail);
                }
                if (OrderDetailsDA.Add(orderDetails))
                {
                    var orderXStatus = new OrderXStatus
                    {
                        DateChanged = DateTime.Now,
                        OrderId = orderId,
                        OrderStatusId = (int)OrderXStatusDA.OrderStatus.Intiated,
                    };
                    if (OrderXStatusDA.AddOrderXStatus(orderXStatus))
                    {
                        if (QuotationDA.UpdateOrderGenerated(quotationId))
                        {
                            foreach (var item in orderDetails)
                            {
                                var product = ProductLineDA.GetDetails(item.ProductLineId);
                                product.QuantityInStock -= item.Quantity;
                                if (!ProductLineDA.Update(product))
                                    return 0;
                            }
                            return orderId;
                        }
                    }
                }
            }
            return 0;
        }
    }
}
