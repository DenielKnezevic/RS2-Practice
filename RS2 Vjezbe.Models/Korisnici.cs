﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RS2_Vjezbe.Models
{
    public class Korisnici
    {

        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string KorisnickoIme { get; set; } 
        public bool? Status { get; set; }
        public string RoleNames => string.Join(", ", KorisniciUloges?.Select(x => x.Uloga?.Naziv)?.ToList());
        //public virtual ICollection<Izlazi> Izlazis { get; set; }
        public virtual ICollection<KorisniciUloge> KorisniciUloges { get; set; }
        //public virtual ICollection<Ulazi> Ulazis { get; set; }
    }
}
