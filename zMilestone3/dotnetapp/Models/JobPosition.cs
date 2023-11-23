using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace dotnetapp.Models
{
    public class JobPosition
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Department { get; set; }

        [Required]
        [StringLength(100)]
        public string Location { get; set; }

        [Required]
        public string Responsibilities { get; set; }

        [Required]
        public string Qualifications { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ApplicationDeadline { get; set; }

        public bool IsClosed { get; set; }

        // Reference to related job applications
        [InverseProperty("JobPosition")]
        public ICollection<JobApplication>? Applications { get; set; }
    }
}