using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tps.Server.Data.Entities
{
    [Table("Projects")]
    public class Project
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Client { get; set; }
        [Column(TypeName = "decimal(10,5)")]
        public decimal Revenue { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public bool Status { get; set; }
    }
}
