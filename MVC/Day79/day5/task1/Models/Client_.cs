using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace task1.Models
{ 
    [Table("Client")]
    public class Client_
    {
       
       
        

            [Key]
            public int CustID { get; set; }
            [Required(ErrorMessage = "Enter Your Name Please")]
            [MaxLength(30, ErrorMessage = "Too long Name chararacters!!!!!!")]
            [Display(Name = "Client Name")]
            public string Name { get; set; }


            [Required]
            [EnumDataType(typeof(gender))]
            public gender Gender { get; set; }


            [Required(ErrorMessage = "Enter Email....")]
            [DataType(DataType.EmailAddress)]

            public string email { get; set; }
            [DataType(DataType.PhoneNumber)]
            [Display(Name = "Phone")]
            public string phoneNum { get; set; }

            public List<Order_> Orders { set; get; } = new List<Order_>();

        }

        public enum gender
        {
            MALE, Female
        }
    }
