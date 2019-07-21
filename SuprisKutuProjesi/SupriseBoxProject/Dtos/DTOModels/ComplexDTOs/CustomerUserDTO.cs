using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.DTOModels.ComplexDTOs
{
   public class CustomerUserDTO
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Display(Name ="E-Mail")]
        public string eMail { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
