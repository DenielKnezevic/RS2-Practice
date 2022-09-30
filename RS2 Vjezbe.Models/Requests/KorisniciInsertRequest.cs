using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RS2_Vjezbe.Models.Requests
{
    public class KorisniciInsertRequest
    {
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Telefon { get; set; }
        [Required]
        [MinLength(5)]
        public string KorisnickoIme { get; set; }
        [Required]
        public string Password { get; set; }
        public bool? Status { get; set; }
        public List<int> UlogeID { get; set; }
        [Required]
        public string PasswordConfirmation { get; set; }
    }
}
