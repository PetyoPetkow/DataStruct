namespace DataStruct
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        
        {
            Date p = new Date { Day = 10, Month = 11, Year = 2010 };
            p.Add(ref p);

            Console.WriteLine($"{p.Day}, {p.Month}, {p.Year}");

            Date z = new Date { Day = 2, Month = 7, Year = 2012 };
            z.Remove(ref z);

            Console.WriteLine($"{z.Day}, {z.Month}, {z.Year}");
        }
    }
}
