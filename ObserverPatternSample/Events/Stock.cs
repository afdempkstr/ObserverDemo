using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPatternSample.Events
{
    class Stock
    {
        private decimal _price;

        public readonly string Name;

        public Stock(string name, decimal price)
        {
            Name = name;
            _price = price;
        }

        public decimal Price
        {
            get => _price;
            set
            {
                if (value != _price)
                {
                    _price = value;
                    OnPriceChanged();
                }
            }
        }

        public event EventHandler PriceChanged;

        private void OnPriceChanged()
        {
            PriceChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    class Investor
    {
        public readonly string Name;

        private List<Stock> _portfolio = new List<Stock>();

        public Investor(string name)
        {
            Name = name;
        }

        public void AddStock(Stock stock)
        {
            _portfolio.Add(stock);
            stock.PriceChanged += Stock_PriceChanged;
        }

        public void RemoveStock(Stock stock)
        {
            if (_portfolio.Remove(stock))
            {
                stock.PriceChanged -= Stock_PriceChanged;
            }
        }

        private void Stock_PriceChanged(object sender, EventArgs e)
        {
            var stock = (Stock)sender;
            Console.WriteLine($"Notified {Name} that the price of {stock.Name} changed to {stock.Price}");
        }
    }
}
