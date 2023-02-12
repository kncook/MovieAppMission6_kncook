using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApp_kncook.Models
{
    public class ApplicationResponse
    {   //these add messages if the user does not input the correct input amount/ what is required
        //IN order to run migrations you need to have an ID
        [Key]
        [Required]
        public int ApplicationId { get; set; }
        [Required(ErrorMessage = "You must add a Category")]
        public string Category { get; set; }
        [Required(ErrorMessage = "You must add a Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "You must add a Director")]
        public string Director { get; set; }
        [Required(ErrorMessage = "You must add a Rating")]
        /*prop tab tab will build this line of code for you*/
        public string Rating { get; set; } /*byte is a smaller amount of int allowed*/
        /*use a dropdown menu (G, PG, PG-13, R)*/
        public bool Edited { get; set; }
        /*“Edited”, “Lent To”, and “Notes” are all OPTIONAL*/
        public string LentTo { get; set; }
        [StringLength(25, ErrorMessage ="Notes must be between 0-25 charachters.")]
        public string Note { get; set; }
      
    }
}
