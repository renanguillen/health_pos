namespace Health.Models.PaymentMethod
{
    using System.ComponentModel.DataAnnotations;

    public class PaymentMethod
    {
        [Key]
        public int Id { get; set; }
        public double Number { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Cvc { get; set; }
        public string? Name { get; set; }
        public int Cpf { get; set; }
        public string? HealthCareName { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
