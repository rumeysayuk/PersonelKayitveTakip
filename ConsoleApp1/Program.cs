using ConsoleApp1.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using(var cont = new personelVeriTabaniContext())
            {
                //TblYonetici tbl = new TblYonetici();
                //tbl.KullaniciAd = "ahned";
                //tbl.Sifre = "1";
                // cont.TblYonetici.Add(tbl);
                //await cont.SaveChangesAsync();
                var per = cont.TblPersonel.FirstOrDefault(x => x.PerId == 371);
                per.PerAd = "Abdulrezzak";
                per.PerId = 371;
            }
          
            var a = 0;
        }
    }
}
