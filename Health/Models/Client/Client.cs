namespace Health.Models.Client
{
    using System.ComponentModel.DataAnnotations;

    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime BirthDay { get; set; }
        public string? Sex { get; set; }
        public string? Email { get; set; }
        public int Telephone { get; set; }
        public double Cpf { get; set; }
        public string? Address { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
