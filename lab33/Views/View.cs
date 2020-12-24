using System;
using System.Collections.Generic;
using System.Text;

namespace lab33.Views
{
    public static class View
    {
        public static void GenerateMessage(string value)
        {
            Console.WriteLine(value);
        }
        public static string GetData(string message = null)
        {
            if (message != null)
                Console.WriteLine(message);
            string response = Console.ReadLine();
            return response;
        }
    }
}
