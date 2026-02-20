using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RealEstate
{
    internal class Ad
    {
        public int Id { get; set; }
        public int Area { get; set; }
        public Category Category { get; set; }
        public DateTime CreateAt { get; set; }
        public string Description { get; set; }
        public int Floors { get; set; }
        public bool FreeOfCharge { get; set; }
        public string ImageUrl { get; set; }
        public string LatLong { get; set; }
        public int Rooms { get; set; }
        public Seller Seller { get; set; }


        public static List<Ad> LoadFromCsv(string fileName)
        {
            List<Ad> ads = new List<Ad>();
            string[] lines = File.ReadAllLines(fileName);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(';');
                int id, rooms, area, floors, categoryId, sellerId;
                bool freeOfCharge;
                DateTime createAt;

                // TryParse for all numeric and boolean fields
                if (!int.TryParse(data[0], out id)) continue;
                string description = data[1];
                if (!int.TryParse(data[2], out rooms)) continue;
                if (!int.TryParse(data[3], out area)) continue;
                if (!int.TryParse(data[4], out floors)) continue;
                categoryId = string.IsNullOrWhiteSpace(data[5]) ? 0 : (int.TryParse(data[5], out int tmpCatId) ? tmpCatId : 0);
                string categoryName = data[6];
                if (!int.TryParse(data[7], out sellerId)) continue;
                string sellerName = data[8];
                string sellerPhone = data[9];
                if (!bool.TryParse(data[10], out freeOfCharge)) freeOfCharge = false;
                string imageUrl = data[11];
                string latLong = data[12];
                if (!DateTime.TryParse(data[13], out createAt)) continue;

                Ad ad = new Ad
                {
                    Id = id,
                    Description = description,
                    Rooms = rooms,
                    Area = area,
                    Floors = floors,
                    Category = new Category
                    {
                        Id = categoryId,
                        Name = categoryName
                    },
                    Seller = new Seller
                    {
                        Id = sellerId,
                        Name = sellerName,
                        Phone = sellerPhone
                    },
                    FreeOfCharge = freeOfCharge,
                    ImageUrl = imageUrl,
                    LatLong = latLong,
                    CreateAt = createAt
                };

                ads.Add(ad);
            }

            return ads;
        }

    }
}

