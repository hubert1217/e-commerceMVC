using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace e_commerceMVC.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="Musisz wpriwadzić e-mail")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Musisz wpriwadzić hasło")]
        public string Password { get; set; }
        [Display(Name="Zapamiętaj mnie")]
        public bool RememberMe { get; set; }
    }
}