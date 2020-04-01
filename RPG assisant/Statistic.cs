using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_assisant
{
    //Statistic - A class that contains basic information about Statistics available in the universe
    //
    [Serializable]
    public class Statistic
    {
        public string symbol;//e.g. STR
        public string name;//e.g. Strength
        public int limit;//maximum value of statistic e.g 20
        public string description;//long description of the statistic
        //string longName; //e.g. STR20 - the symbol of statistic and its limit
        //bool expandable; //informs whether the statistic can go beyond its limit

        public void DisplayStatistic()
        {
            Console.Write("Symbol:\t\t");
            Console.WriteLine(symbol);
            Console.Write("Name:\t\t");
            Console.WriteLine(name);
            Console.Write("Limit:\t\t");
            Console.WriteLine(limit);
            Console.Write("Description:\t");
            Console.WriteLine(description);
        }
    }
}
