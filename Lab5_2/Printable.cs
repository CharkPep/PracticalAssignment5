using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab5_2
{
    public class Printable
    {
        public enum Purpose { Scientific, Educational, Socio_political, Artistic, Fairy_Tail, Fasion };
        public Purpose PrintPurpose { get; }
        public string? Title { get; }
        public IEnumerable<string>? Authors { get; }
        public List<string>? PublishLanguages { get; }
        public int PageNumber { get; }
        public decimal Rate { get; protected set; }
        public decimal Price { get; protected set; }
        public int SoldNumber { get; }
        public Printable()
        {

        }
        public Printable(Purpose PrintPurpose, string Name, IEnumerable<string> Authors, int PageNumber, decimal Rate, decimal Price, int SoldNumber)
        {
            if(PageNumber < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(PageNumber));
            }
            if(Rate < 0 || Rate > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(Rate));
            }
            if(Price < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Price));
            }
            if(SoldNumber < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(SoldNumber));
            }
                Title = Name;
            this.Authors = Authors;
            this.PageNumber = PageNumber;
            this.Rate = Rate;
            this.Price = Price;
            this.SoldNumber = SoldNumber;
        }
        public Printable(string Name, IEnumerable<string> Authors, int PageNumber)
        {
            if (PageNumber < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(PageNumber));
            }
            if (Rate < 0 || Rate > 10)
            {
                throw new ArgumentOutOfRangeException(nameof(Rate));
            }
            if (Price < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Price));
            }
            if (SoldNumber < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(SoldNumber));
            }
            Title = Name;
            this.Authors = Authors;
            this.PageNumber = PageNumber;
        }
        public Printable(Printable other)
        {
            Title = other.Title;
            Authors = other.Authors;
            PageNumber = other.PageNumber;
            Rate = other.Rate;
            Price = other.Price;
            SoldNumber = other.SoldNumber;
        }
        public virtual void Print()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The base class");
            Console.ResetColor();
            Console.WriteLine($"The title is: {Title}");
            Console.WriteLine($"The purpose is: {PrintPurpose}");
            if(Authors != null)
            {
                Console.WriteLine($"The authors are:");
                foreach(var item in Authors)
                {
                    Console.Write($"{item} ");
                }
            }
            Console.WriteLine();
            Console.WriteLine($"The number of pages is: {PageNumber}");
            Console.WriteLine($"The rate(1-10) is: {Rate}");
            Console.WriteLine($"The price is: {Price}");
            Console.WriteLine($"Sold: {SoldNumber}");
        }
        public int Rating(IEnumerable<Printable> PublishersList)
        {
            if (!PublishersList.Contains(this))
            {
                throw new ArgumentException(nameof(Printable));
            }
            return PublishersList.OrderByDescending(x => x.SoldNumber).ToList().IndexOf(this) + 1;
        }
        public virtual void SetPrice(int NumberOfCopies, int NumberOfPages, decimal OnePageCost, decimal HardSoftFactor, decimal PrintFormatFactor, decimal ColorFactor) => Price = NumberOfCopies * NumberOfPages * OnePageCost * (1 + HardSoftFactor) * (1 + PrintFormatFactor) * (1 + ColorFactor);
        public virtual void SetPrice(int PaperPrice, int PrintingWorkPrice, decimal TaxesCoef) => Price = (PaperPrice + PrintingWorkPrice) * (1 + TaxesCoef);
        public virtual void SetPrice(int PaperPrice, int PrintingWorkPrice) => Price = (PaperPrice + PrintingWorkPrice);
        public virtual int GetNumberOfPrintableCopyes(decimal TotalSaleAmount)
        {
            if(Price == 0)
            {
                throw new ArgumentException("Price hasn`t been specified.", nameof(Price));
            }
            return Decimal.ToInt32(TotalSaleAmount / Price);
        }
        public static bool operator ==(Printable a, Printable b) => a.Price == b.Price;
        public static bool operator !=(Printable a, Printable b) => a.Price != b.Price;
        public static bool operator <(Printable a, Printable b) => a.Price < b.Price;
        public static bool operator >(Printable a, Printable b) => a.Price > b.Price;
        public static Printable operator +(Printable a, Printable b) => (new Printable(a.PrintPurpose, "Book`s assembly", a.Authors.ToList().Union(b.Authors), a.PageNumber + b.PageNumber, (a.Rate + b.Rate)/2, a.Price + b.Price, a.SoldNumber + b.SoldNumber));
        public static Printable operator -(Printable a, Printable b) => (new Printable(a.PrintPurpose, a.Title, a.Authors.Except(b.Authors), a.PageNumber - b.PageNumber < 0 ? 0 : a.PageNumber - b.PageNumber, (a.Rate + b.Rate) / 2, a.Price + b.Price, a.SoldNumber + b.SoldNumber));
        public static Printable operator ++(Printable a)
        {
            a.Price++;
            return a;
        }
        public static Printable operator --(Printable a)
        {
            a.Price--;
            return a;
        }
        public static Printable operator -(Printable a)
        {
            a.Price *= 0.1m;
            return a;
        }


        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
