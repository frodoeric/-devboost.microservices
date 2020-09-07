using System;

namespace Integration.Pay.Dto
{
    public class PatyOperatorResultDto
    {
        public int Id { get; set; }
        public int CreditCardPaymentId { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; }
    }
}
