using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
   public  class UserModel 
    {
        /// <summary>
        /// HEre we store data for user Model
        /// </summary>
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        /// <summary>
        /// IDCardName is number on ID card       
        /// </summary>
        public string IDCardName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int AddressID { get; set; }
    }
}
