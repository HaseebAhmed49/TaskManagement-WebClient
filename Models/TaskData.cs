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

        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Start Date is Required")]
        public DateTime startDate { get; set; }

        [Display(Name = "End Date")]
        [Required(ErrorMessage = "End Date is Required")]
        public DateTime endDate { get; set; }
    }
}
