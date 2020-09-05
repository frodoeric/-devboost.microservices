using System;

namespace Integration.Pay.Queries
{
    public class QueryPatyOperatorResult
    {
        public int Id { get; set; }
        public int CreditCardPaymentId { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
    }
}
