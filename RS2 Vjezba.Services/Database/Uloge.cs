﻿using System;
using System.Collections.Generic;

namespace RS2_Vjezba.Services.Database
{
    public partial class Uloge
    {
        public Uloge()
        {
            KorisniciUloges = new HashSet<KorisniciUloge>();
        }

        public int UlogaId { get; set; }
        public string Naziv { get; set; } = null!;
        public string? Opis { get; set; }

        public virtual ICollection<KorisniciUloge> KorisniciUloges { get; set; }
    }
}
