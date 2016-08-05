using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppNetA.Models
{
    public class PredictModel
    {
       
            [Required]
        [Display(Name = "Area Square Id")]
        public int squareID { get; set; }
            [Required]
        [Display(Name = "Select Country")]
        public int countryCode { get; set; }
            [Required]
        [Display(Name = "Incoming SMS Activity")]
        public float smsInActivity { get; set; }
            [Required]
        [Display(Name = "Outgoing SMS Activity")]
        public float smsOutActivity { get; set; }
            [Required]
        [Display(Name = "Incoming Call Activity")]
        public float callInActivity { get; set; }
            [Required]
        [Display(Name = "Internet Traffic Activity")]
        public float internetTrafficActivity { get; set; }
            [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        [Display(Name = "Hour")]
        [Required]
        public int hour { get; set; }

        [Display(Name = "Call Out Activity")]
        public float callOutActivity { get; set; }

        public string category { get; set; }

        public float probability { get; set; }
        
        //[Required]
        //public string hour { get; set; }
        //[Required]
        //public int dayOfWeek { get; set; }
        //[Required]
        //public int weekday { get; set; }



    }
}