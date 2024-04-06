namespace Health.Models.Doctor
{
    using System.ComponentModel.DataAnnotations;

    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        public int Crm { get; set; }
        public string? Name { get; set; }
        public string? Speciality { get; set; }
        public int Telephone { get; set; }
        public string? Address { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
