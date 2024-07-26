using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tps.Server.Data.Entities
{
    [Table("Tasks")]
    public class Task
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int Id { get; set; }
        public string Code { get; set; }
        public string JobName { get; set; }
        public string Service { get; set; }
        public ushort VolumePages { get; set; }
        public ushort Rate { get; set; }
        public int Total { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal MarginPercent { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public bool Status { get; set; }
        [ForeignKey(nameof(Project))]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        [ForeignKey(nameof(Translator))]
        public int TranslatorId { get; set; }
        public virtual Translator Translator { get; set; }
    }
}
