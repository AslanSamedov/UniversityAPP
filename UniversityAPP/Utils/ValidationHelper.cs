using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournall.Utils
{
    public static class ValidationHelper
    {
        public static string GetRequiredMessage(string propertyName)
        {
            return $"THE {propertyName} Info is Invalid!";
        }
        public static string GetExsistMessage(string propName)
        {
            return $"The {propName} already Exsist!";
        }

    }
}
