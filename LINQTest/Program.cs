using System;
using System.Collections.Generic;
using System.Linq;


namespace LINQTest
{
    class Comic
    {
        public string Name { get; set; }
        public int Issue { get; set; }

        public override string ToString() => $"{Name} (Issue #{Issue})";

        public static readonly IEnumerable<Comic> Catalog = new List<Comic>
        {
            new Comic { Name = "JOhnny America vs Pink", Issue = 6 },
            new Comic { Name = "Aamazon", Issue = 19},
            new Comic { Name ="Big Google", Issue = 57},
            new Comic { Name ="Dady Big Bucks", Issue = 68},
            new Comic { Name ="LJ Thornton", Issue = 74 },
            new Comic { Name ="Gave my hear away", Issue = 83}

        };

        public static readonly IReadOnlyDictionary<int, decimal> Prices = new Dictionary<int, decimal>
        {
            {6, 3600M },
            {19, 500M },
            {36, 650M },
            {57, 13525M },
            {68, 1000M },
            {74, 360.5M },
            {83, 895.6M },

        };
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Comic> mostExpenive =
                from comic in Comic.Catalog
                where Comic.Prices[comic.Issue] > 500
                orderby -Comic.Prices[comic.Issue]
                select comic;

            foreach (Comic comic in mostExpenive)
            {
                Console.WriteLine($"{comic} is worth {Comic.Prices[comic.Issue]:c}");
            }


        }
    }
}
