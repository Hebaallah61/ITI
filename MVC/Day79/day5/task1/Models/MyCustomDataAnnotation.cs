using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace task1.Models
{
    public class MyCustomDataAnnotation:ValidationAttribute
    {
        int TotalPrice;
        public MyCustomDataAnnotation(int TP)
        {
            TotalPrice=(int)TP;
        }

        public override bool IsValid(object value)
        {
            if(value== null) return false;
            else
            {
                if(value is decimal)
                {
                    decimal custordertotal =(decimal)value;
                    if(custordertotal > TotalPrice)
                    {
                        return true;
                    }
                    else
                    {
                        ErrorMessage = $"Total Price Does Not Match With Our Package";
                        return false;
                    }
                }
                else { return false; }
            }
            
        }

    }
}