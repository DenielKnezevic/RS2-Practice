﻿using System;
using System.Collections.Generic;

namespace RS2_Vjezbe.Models
{
    public partial class KorisniciUloge
    {
        public int KorisnikUlogaId { get; set; }
        public int KorisnikId { get; set; }
        public int UlogaId { get; set; }
        public DateTime DatumIzmjene { get; set; }

        public virtual Uloge Uloga { get; set; }
    }
}
