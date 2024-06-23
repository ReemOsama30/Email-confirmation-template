using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    public class Department
    {
        public int id { get; set; }
        public string name { get; set; }

        [ForeignKey("user")]
        public string? userId { get; set; }
        public ApplicationUser? user { get; set; }

    }
}
