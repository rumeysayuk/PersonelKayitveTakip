using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ConsoleApp1.Models
{
    public partial class TblPersonel
    {
        public short PerId { get; set; }
        public string PerAd { get; set; }
        public string PerSoyad { get; set; }
        public string PerSehir { get; set; }
        public short? PerMaas { get; set; }
        public bool? PerDurum { get; set; }
        public string PerMeslek { get; set; }
    }
}
