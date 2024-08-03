using System;

namespace StrategyPattern
{
    public interface IPromoteStrategy
    {
        double DoDiscount(double price);
    }

    public class Ticket
    {
        private IPromoteStrategy _promoteStrategy;
        private double _price;
        private string _name;

        public IPromoteStrategy GetPromoteStrategy()
        {
            return _promoteStrategy;
        }

        public void SetPromoteStrategy(IPromoteStrategy value)
        {
            _promoteStrategy = value;
        }

        public double GetPrice()
        {
            return _price;
        }

        public void SetPrice(double value)
        {
            _price = value;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string value)
        {
            _name = value;
        }

        public Ticket() { }

        public Ticket(IPromoteStrategy promoteStrategy)
        {
            _promoteStrategy = promoteStrategy;
        }

        public double GetPromotedPrice()
        {
            return _promoteStrategy.DoDiscount(_price);
        }
    }

    public class HalfDiscountStrategy : IPromoteStrategy
    {
        public double DoDiscount(double price)
        {
            return price * 0.5;
        }
    }

    public class QuarterDiscountStrategy : IPromoteStrategy
    {
        public double DoDiscount(double price)
        {
            return price * 0.75;
        }
    }

    public class NoDiscountStrategy : IPromoteStrategy
    {
        public double DoDiscount(double price)
        {
            return price;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start getting tickets!");

            var random = new Random();

            for (var i = 0; i <= 5; i++)
            {
                var strategyIndex = random.Next(0, 3); // Generate a random number between 0 and 2
                var ticket = new Ticket();
                ticket.SetName("Ticket " + (i + 1));
                ticket.SetPrice(50d * i);

                switch (strategyIndex)
                {
                    case 0:
                        ticket.SetPromoteStrategy(new NoDiscountStrategy());
                        break;
                    case 1:
                        ticket.SetPromoteStrategy(new QuarterDiscountStrategy());
                        break;
                    default:
                        ticket.SetPromoteStrategy(new HalfDiscountStrategy());
                        break;
                }

                var promotedPrice = ticket.GetPromotedPrice();

                Console.WriteLine("Promoted price of " + ticket.GetName() + " is " + promotedPrice);
                Console.WriteLine();
            }
        }
    }
}
