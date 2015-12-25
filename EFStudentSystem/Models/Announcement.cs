using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace EFStudentSystem.Models
{
    public class Announcement
    {
        public int ID { get; set; }

        public int InstructorID { get; set; }

        [Required]
        [StringLength(225)]
        [Display(Name = "Subject")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Short Description")]
        [StringLength(225)]
        public string ShortDescription { get; set; }

        [Required]
        [StringLength(5000)]
        [Display(Name = "Content")]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Post Time")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PostedOn { get; set; }

        public virtual Instructor Instructor { get; set; }

    }
}