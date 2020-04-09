using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternSample
{
    abstract class Stock
    {
        private decimal _price;
        private List<IInvestor> _observers = new List<IInvestor>();

        public decimal Price
        {
            get => _price;
            set
            {
                if (_price != value)
                {
                    _price = value;
                    Notify();
                }
            }
        }

        public Stock(decimal price)
        {
            _price = price;
        }

        public void Attach(IInvestor observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IInvestor observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
            Console.WriteLine();
        }
    }

    interface IInvestor
    {
        void Update(Stock stock);
    }

    class StockOwner : IInvestor
    {
        public readonly string Name;

        private Stock _stock;

        private decimal _sellThreshold;

        public StockOwner(string name, Stock stock, decimal sellThreshold)
        {
            Name = name;
            _stock = stock;
            _sellThreshold = sellThreshold;
        }

        public void Update(Stock stock)
        {
            Console.WriteLine($"StockOwner {Name} was notified that the {stock.GetType().Name} price changed to {stock.Price}");
            if (stock.Price >= _sellThreshold)
            {
                Console.WriteLine($"StockOwner {Name} wants to sell some {stock.GetType().Name}");
            }
        }
    }

    class StockInvestor : IInvestor
    {
        public readonly string Name;

        private Stock _stock;

        private decimal _buyThreshold;

        public StockInvestor(string name, Stock stock, decimal buyThreshold)
        {
            Name = name;
            _stock = stock;
            _buyThreshold = buyThreshold;
        }

        public void Update(Stock stock)
        {
            Console.WriteLine($"StockInvestor {Name} was notified that the {stock.GetType().Name} price changed to {stock.Price}");
            if (stock.Price <= _buyThreshold)
            {
                Console.WriteLine($"StockInvestor {Name} wants to buy some {stock.GetType().Name}");
            }
        }
    }

    class Aktor : Stock
    {
        public Aktor(decimal price) : base(price)
        { }
    }
}
