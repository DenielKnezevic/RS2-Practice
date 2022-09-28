using System;
using System.Collections.Generic;
using System.Text;

namespace RS2_Vjezbe.Models
{
    public class KorisniciSearchObject : BaseSearchObject
    {
        public string Username { get; set; }
        public string Ime { get; set; }
        public bool IncludeRoles { get; set; }
    }
}
