﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RS2_Vjezbe.Models.Requests
{
    public class KorisniciUpdateRequest
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Password { get; set; }
        public bool? Status { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}
