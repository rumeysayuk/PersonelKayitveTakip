using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ConsoleApp1.Models
{
    public partial class TblYonetici
    {
        public string KullaniciAd { get; set; }
        public string Sifre { get; set; }
        public bool? Admin { get; set; }
    }
}
