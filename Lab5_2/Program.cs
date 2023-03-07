namespace Lab5_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Print1 = new Printable(Printable.Purpose.Scientific, "Print1", new List<string> { "Author1", "Author2" }, 100, 10, 110, 100);
            var Print2 = new Printable(Printable.Purpose.Scientific, "Print2", new List<string> { "Author3", "Author4" }, 110, 10, 100, 10);
            var Book1 = new Book(Print1, 1, DateTime.Now, 10, Book.CoverType.Hard);
            var Magazine1 = new Magazine(Print1, 1, DateTime.Now, Magazine.CoverType.Hard);
            
            Print1.Print();
            Console.WriteLine();
            Print2.Print();
            Console.WriteLine(Print1 > Print2);
            var Print3 = Print1 - Print2;
            Print3.Print();
            Console.WriteLine();
            var Print4 = Print1 + Print2;
            Print4.Print();
            Console.WriteLine();
            Book1.SetPrice(100, 100);
            Book1.Print();
            Console.WriteLine();
            Magazine1.Print();


        }
    }
}