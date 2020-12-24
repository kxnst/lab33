using System;
using System.Collections.Generic;
using System.Text;
using lab33.Models;
using lab33.Views;
using lab33.Classes;

namespace lab33.Controllers
{
    public class Controller
    {
        protected Model model;
        public Controller(Model model)
        {
            this.model = model;
            init();
        }
        public void init()
        {
            string resp = menu();
            switch (resp.Trim().ToLower())
            {
                case "1":
                    model.ToJson();
                    View.GenerateMessage(model.Last());
                    break;
                case "2":
                    model.ToXml();
                    View.GenerateMessage(model.Last());
                    break;
                case "3":
                    model.ToBinary();
                    View.GenerateMessage(model.Last());
                    break;
                case "4":
                    model.Deserialise();
                    break;
                case "5":
                    return;
            }
            init();
        }
        public string menu()
        {
            return View.GetData("1. Serialise to JSON + write\r\n" +
                "2. Serialise to XML + write\r\n" +
                "3. Serialise to binary + write\r\n" +
                "4. Deserialise + print\r\n" +
                "5. Exit");
        }

    }
}
