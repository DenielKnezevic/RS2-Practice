using System;
using System.Collections.Generic;

namespace RS2_Vjezba.Services.Database
{
    public partial class JediniceMjere
    {
        public JediniceMjere()
        {
            Proizvodis = new HashSet<Proizvodi>();
        }

        public int JedinicaMjereId { get; set; }
        public string Naziv { get; set; } = null!;

        public virtual ICollection<Proizvodi> Proizvodis { get; set; }
    }
}
