using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiStudent
{
    public class StudentDetail
    {
        public int Id { get; set; }
        [Required]
        [StringLength (225)]
        public string Fristname { get; set; }
        [StringLength (25)]
        public string Lastname { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string dateofbirth { get; set; }
        [StringLength (2000)]
        public string Address { get; set; }
        [Required]
       
        public long Phoneno { get; set; }
        public int courseId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public string enrollmentdate { get; set; }
    }
}
