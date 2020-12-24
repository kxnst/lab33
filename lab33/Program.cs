using System;
using lab33.Controllers;
using lab33.Models;
using lab33.Views;
using lab33.Classes;

namespace lab33
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller(new Model());
        }
    }
}
