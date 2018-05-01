using System;
using System.ComponentModel.DataAnnotations;

namespace restauranter.Models
{
    public class Restaurant 
    {
        public int id { get; set; }

        [Required(ErrorMessage= "Reviewer Name field cannot be empty")]
        [Display(Name = "Reviewer Name")]
        public string user_name { get; set; }

        [Required(ErrorMessage= "Restaurant Name field cannot be empty")]
        [Display(Name = "Restaurant Name")]
        public string rest_name { get; set; }

        [Required(ErrorMessage= "Review field cannot be empty")]
        [Display(Name = "Review")]
        [MinLength(10)]
        public string review { get; set; }

        [DataType(DataType.Date)]
        // [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage= "Visit Date field cannot be empty")]
        [Display(Name = "Visit Date")]
        public DateTime visit_date { get; set; }

        [Required(ErrorMessage= "Stars field cannot be empty")]
        [Display(Name = "Stars")]
        public int stars { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime created_at { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime updated_at { get; set; }

        public Restaurant()
        {
            this.created_at = DateTime.Now;
            this.updated_at = DateTime.Now;
        }

        public string Duration {
            get {
                double days = DateTime.Now.Subtract(this.created_at).TotalDays;
                double min =  DateTime.Now.Subtract(this.created_at).TotalMinutes;
                return $"{(int)days} day(s) ago";
            }
        }
    }
}