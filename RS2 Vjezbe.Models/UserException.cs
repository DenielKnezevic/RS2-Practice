using System;
using System.Collections.Generic;
using System.Text;

namespace RS2_Vjezbe.Models
{
    public class UserException : Exception
    {
        public UserException(string message):base(message)
        {

        }
    }
}
