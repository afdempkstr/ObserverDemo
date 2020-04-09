using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternSample.Events
{
    class EventSample
    {
        public static void Demo()
        {
            var vardinogiannis = new Investor("Vardinogiannis");
            var marinakis = new Investor("Marinakis");

            var aktor = new Stock("Aktor", 20m);
            var ellaktor = new Stock("Ellaktor", 30m);

            vardinogiannis.AddStock(aktor);
            vardinogiannis.AddStock(ellaktor);

            marinakis.AddStock(aktor);

            aktor.Price = 12m;

            ellaktor.Price = 33m;

            vardinogiannis.RemoveStock(aktor);

            aktor.Price = 35;

            Console.Read();
        }
    }
}
