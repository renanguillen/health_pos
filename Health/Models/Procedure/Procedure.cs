namespace Health.Models.Procedure
{
    using System.ComponentModel.DataAnnotations;

    public class Procedure
    {
        [Key]
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime ScheduledDate { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
