using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class JobApplication
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int JobPositionId { get; set; }

        [ForeignKey("JobPositionId")]
        public JobPosition? JobPosition { get; set; }

        [Required]
        [StringLength(100)]
        public string ApplicantName { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } // shortlist, reject, schedule

        // Add other applicant details as needed
    }
}