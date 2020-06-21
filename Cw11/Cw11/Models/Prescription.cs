using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Cw11.Models
{
    public class Prescription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPrescription { get; set; }

        public DateTime Date { get; set; }

        public DateTime DueDate { get; set; }

        public int IdPatient { get; set; }

        [ForeignKey("IdPatient")]
        public virtual Patient Patient { get; set; }

        public int IdDoctor{ get; set; }

        [ForeignKey("IdDoctor")]
        public virtual Doctor Doctor { get; set; }
    }
}
