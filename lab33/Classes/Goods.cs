using System;
using System.Text.Json;
namespace lab33.Classes
{
    [Serializable]
    public class Goods : IComparable
    {
        private DateTime _manufacture;

        public DateTime Manufacture
        {
            get => _manufacture;
            set => _manufacture = value;
        }
        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value;
        }
        private string _barcode;

        public string Barcode
        {
            get => _barcode;
            set => _barcode = value;
        }
        
        private DateTime _expiration;

        public DateTime Expiration
        {
            get => _expiration;
            set => _expiration = value;
        }

        private int _price;
        public int Price
        {
            get => _price;
            set => _price = value;
        }
        public Goods() {}
        public Goods(DateTime manufacture, string name, string barcode, DateTime expiration, int price)
        {
            _manufacture = manufacture;
            _name = name;
            _barcode = barcode;
            _expiration = expiration;
            _price = price;
        }
        public static string[] Manufacturers =
        {
            "Samsung","Nokia","LG","HP","Xiaomi","Apple","Huawei"
        };
        public static string[] Names =
        {
            "Laptop","Phone","TV","Mouse","Tablet","Camera"
        };
        public static Goods CreateRandom()
        {
            Random random = new Random();
            return new Goods(DateTime.Now, Names[random.Next(0, Names.Length - 1)], Manufacturers[random.Next(0, Names.Length - 1)], DateTime.Now.AddDays(random.Next(400, 10000)), random.Next(10, 1000));
        }
        public bool IsExpired()
        {
            return Expiration < DateTime.Now;
        }

        public int CompareTo(object obj)
        {
            Goods tmp = obj as Goods;
            if (obj == null)
                return -1;
            if (obj == null)
                return 1;
            return Price.CompareTo(tmp.Price);
        }
        public override string ToString()
        {
            return Price.ToString();
        }

    }
}

