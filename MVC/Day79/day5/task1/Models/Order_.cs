using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace task1.Models
{ [Table("Order")]
    public class Order_
    {
       
        
            [Key]
            public int Id { get; set; }
            [Display(Name = "Total Price")]
            [MyCustomDataAnnotation(1000)]
            public decimal TotalPrice { get; set; }
            [Required, DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
            [Display(Name = "Date")]
            public DateTime Date { get; set; }

            [ForeignKey("Client_")]
            public int CustID { get; set; }

            public Client_ Client_ { get; set; }
        }
    }
