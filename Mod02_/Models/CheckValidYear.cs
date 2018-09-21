using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Mod02_.Models
{
    public class CheckValidYear : ValidationAttribute
    {
        public CheckValidYear()
        { 
            ErrorMessage = 
                "The earliest opera is Daphne, 1598, by Corsi, Peri, and Rinuccini";
        }

        public override bool IsValid(object value)
        {
            if (value == null) value = 0;
            int year = (int)value;
            if (year < 1598)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }

}