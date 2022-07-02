using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement_WebClient
{
    public class TaskData
    {
        [Key]
        [Display(Name ="ID")]
        public int id { get; set; }

        [Display(Name = "Task Name")]
        [Required(ErrorMessage ="Task Name is Required")]
        public string taskName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Start Date is Required")]
        public DateTime startDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        [Required(ErrorMessage = "End Date is Required")]
        public DateTime endDate { get; set; }

        [Display(Name ="Task Description")]
        [Required(ErrorMessage = "Description is Required")]
        [MinLength(10, ErrorMessage = "Task Description must be at least 10 characters long")]
        public string? taskDescription { get; set; }

        [Display(Name ="Task Status")]
        [Required(ErrorMessage ="Select Task Status")]
        public TaskStatus? taskStatus { get; set; }
    }

    public enum TaskStatus
    {
        NotStarted,
        Pending,
        Completed,
        OnHold
    }
}