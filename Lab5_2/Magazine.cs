using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_2
{
    public class Magazine : Printable
    {
        public enum CoverType { Hard, Soft }
        public int ID { get; }
        public DateTime RealiseDate { get; }
        public CoverType Cover { get; }
        public Magazine()
        {

        }
        public Magazine(Printable Edition, int ID, DateTime RealiseDate, CoverType Cover) : base(Edition)
        {
            this.ID = ID;
            this.RealiseDate = RealiseDate;
            this.Cover = Cover;
        }
        public Magazine(Magazine other) : base(other)
        {
            this.ID = other.ID;
            this.RealiseDate = other.RealiseDate;
            this.Cover = other.Cover;
        }
        public override void Print()
        {
            Console.WriteLine("The base class of Magazine");
            base.Print();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The Magazine class");
            Console.ResetColor();
            Console.WriteLine($"The ID: {ID}");
            Console.WriteLine($"The Realise Date: {RealiseDate}");
            Console.WriteLine($"The Cover type: {Cover}");
        }
        public override void SetPrice(int NumberOfCopies, int NumberOfPages, decimal OnePageCost, decimal HardSoftFactor, decimal PrintFormatFactor, decimal ColorFactor) => Price = NumberOfCopies * NumberOfPages * OnePageCost * (1 + HardSoftFactor) * (0.8m + PrintFormatFactor) * (0.5m + ColorFactor);
        public static Magazine operator +(Magazine a, Magazine b) => (new Magazine((Printable)a + b, Math.Max(a.ID, b.ID) + 1, DateTime.Now, CoverType.Hard));
        public static Magazine operator -(Magazine a, Magazine b) => (new Magazine((Printable)a - b, Math.Max(a.ID, b.ID) + 1, DateTime.Now, CoverType.Hard));

    }
}
