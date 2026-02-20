using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RealEstate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName = "realestates.csv";
            List<Ad> ads = Ad.LoadFromCsv(fileName);

            
            Console.WriteLine($"Betöltött hirdetések száma: {ads.Count}");

            // 3. Példa a hozzáférésre: az első hirdetés adatai
            if (ads.Count > 0)
            {
                Ad first = ads[0];
                Console.WriteLine($"Hirdetés ID: {first.Id}");
                Console.WriteLine($"Leírás: {first.Description}");
                Console.WriteLine($"Szobák: {first.Rooms}");
                Console.WriteLine($"Alapterület: {first.Area} m²");
                Console.WriteLine($"Eladó: {first.Seller.Name}, Telefon: {first.Seller.Phone}");
                Console.WriteLine($"Kategória: {first.Category.Name}");
                Console.WriteLine($"Tehermentes: {first.FreeOfCharge}");
                Console.WriteLine($"Földrajzi koordináták: {first.LatLong}");
                Console.WriteLine($"Hirdetés feladva: {first.CreateAt.ToShortDateString()}");
            }

            // 4. Itt jöhetnek a további feladatok az ads listával
            // pl. szűrés, statisztika, rendezés, stb.
        }
    }
}
    

