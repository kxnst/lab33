using lab33.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace lab33.Models
{
    public class Model
    {
        private List<Goods> goods = new List<Goods>();
        private string last_serialised;
        private const int MAX_SIZE = 3;
        private XmlSerializer xmlSerializer;
        StringWriter writer = new StringWriter();
        BinaryFormatter formatter = new BinaryFormatter();
        MemoryStream memory;
        private string file;
        public Model()
        {
            for (int i = 0; i < MAX_SIZE; i++)
            {
                goods.Add(Goods.CreateRandom());
            }
            xmlSerializer = new XmlSerializer(goods.GetType());
            memory = new MemoryStream();
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            string Root = Directory.GetCurrentDirectory();
            file = Path.Combine(Root, @"..\..\..\database.txt");
        }
        public void setSer(string ser)
        {
            last_serialised = ser;
            Write();
        }
        public void ToJson()
        {
            JsonSerializerOptions serializerOptions = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            setSer(JsonSerializer.Serialize(goods, serializerOptions));
        }
        public void ToXml()
        {
            xmlSerializer.Serialize(writer, goods);
            setSer(writer.ToString());
        }
        public void ToBinary()
        {
            formatter.Serialize(memory, goods);
            setSer(Encoding.Default.GetString(memory.ToArray()));
        }
        public void Write()
        {
            File.WriteAllText(file, string.Empty);
            using (StreamWriter writer = File.AppendText(file))
            {
                writer.WriteLine(last_serialised);
            }
        }
        public string Last()
        {
            return last_serialised;
        }
        public void Deserialise()
        {
            FileStream stream = new FileStream(file, FileMode.Open);
            string responce;
            using var Str = new StreamReader(stream);
            responce = Str.ReadToEnd().Trim();
            try
            {
                switch (responce[0])
                {
                    case '<':
                        goods = (List<Goods>)xmlSerializer.Deserialize(new StringReader(responce));
                        break;
                    case '{':
                    case '[':
                        goods = (List<Goods>)JsonSerializer.Deserialize(responce, goods.GetType());
                        break;
                    default:
                        goods = (List<Goods>)formatter.Deserialize(new MemoryStream(Encoding.Default.GetBytes(responce)));
                        break;
                }
            }
            catch (Exception E)
            {
                Views.View.GenerateMessage("Something is wrong with your database");
            }

         
        }

    }
}
