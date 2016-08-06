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
        [Range(38, 11454, ErrorMessage = "Area Square id should be between 38 and 11454. Refer to available square ids in that region.")]
        public int squareID { get; set; }

            [Required]
        [Display(Name = "Select Country")]
        public String countryCode { get; set; }
            [Required]

        [Display(Name = "Incoming SMS Activity")]
        [Range(0, 27, ErrorMessage = "SMS in Activity should be between 0 and 27")]
        public float smsInActivity { get; set; }
            [Required]
        [Display(Name = "Outgoing SMS Activity")]
        [Range(0, 20, ErrorMessage = "SMS out Activity should be between 0 and 20")]
        public float smsOutActivity { get; set; }

            [Required]
        [Display(Name = "Incoming Call Activity")]
        [Range(0, 16, ErrorMessage = "Call in Activity should be between 0 and 16")]
        public float callInActivity { get; set; }
            [Required]
        [Display(Name = "Internet Traffic Activity")]
        [Range(0, 70, ErrorMessage = "Internet Traffic Activity should be between 0 and 70")]
        public float internetTrafficActivity { get; set; }
            [Required]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime date { get; set; }
        [Display(Name = "Hour")]
        [Required]
        [Range(0, 23, ErrorMessage = "Hour should be betweeen 0 and 23")]
        public int hour { get; set; }

        [Display(Name = "Call Out Activity")]
        [Range(0, 35, ErrorMessage = "Call out Activity should be between 0 and 35 as factor")]
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