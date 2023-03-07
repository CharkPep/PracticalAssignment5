using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_2
{
    public class Booklet : Printable
    {
        public enum CoverType { Hard, Soft }
        public int ID { get; }
        public DateTime RealiseDate { get; }
        public CoverType Cover { get; }
        public int NumberOfTurns { get; }
        public Booklet()
        {

        }
        public Booklet(Printable Edition, int ID, DateTime RealiseDate, CoverType Cover, int numberOfTurns) : base(Edition)
        {
            this.ID = ID;
            this.RealiseDate = RealiseDate;
            this.Cover = Cover;
            NumberOfTurns = numberOfTurns;
        }
        public Booklet(Booklet other) : base(other)
        {
            this.ID = other.ID;
            this.RealiseDate = other.RealiseDate;
            this.Cover = other.Cover;
            NumberOfTurns = other.NumberOfTurns;
        }
        public override void Print()
        {
            Console.WriteLine("The base class of Booklet");
            base.Print();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The Book class");
            Console.ResetColor();
            Console.WriteLine($"The ID: {ID}");
            Console.WriteLine($"The Realise Date: {RealiseDate}");
            Console.WriteLine($"The Cover type: {Cover}");
            Console.WriteLine($"The number of turns: {NumberOfTurns}");
        }
        public override void SetPrice(int NumberOfCopies, int NumberOfPages, decimal OnePageCost, decimal HardSoftFactor, decimal PrintFormatFactor, decimal ColorFactor) => Price = NumberOfCopies * NumberOfPages * OnePageCost * (1 + HardSoftFactor) * (1.5m + PrintFormatFactor) * (1.5m + ColorFactor);
        public static Booklet operator +(Booklet a, Booklet b) => (new Booklet((Printable)a + b, Math.Max(a.ID, b.ID) + 1, DateTime.Now, CoverType.Hard, a.NumberOfTurns + b.NumberOfTurns));
        public static Booklet operator -(Booklet a, Booklet b) => (new Booklet((Printable)a - b, Math.Max(a.ID, b.ID) + 1, DateTime.Now, CoverType.Hard, a.NumberOfTurns + b.NumberOfTurns < 0 ? 0 : a.NumberOfTurns + b.NumberOfTurns));

    }
}
