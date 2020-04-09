using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternSample.Events
{
    class ObserverSample
    {
        public static void Demo()
        {
            var aktor = new Aktor(20m);

            var marinakis = new StockOwner("Marinakis", aktor, 22m);
            var vardinogiannis = new StockInvestor("Vardinogiannis", aktor, 18m);

            aktor.Attach(marinakis);
            aktor.Attach(vardinogiannis);

            aktor.Price = 21m;
            aktor.Price = 23.23m;
            aktor.Price = 16.66m;

            aktor.Detach(marinakis);

            aktor.Price = 25m;

            Console.Read();
        }
    }
}
