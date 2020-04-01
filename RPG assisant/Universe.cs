using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_assisant
{
    //The Universe is the class that links all the campains that are being led in the same universe
    //This is the same story basis, the same statistics, the same opponents and the same available classes/professions etc
    [Serializable]
    class Universe
    {
        public string name;//the name of the universe
        public string description;//the description of the universe
        public List<Statistic> statistics;//
        //int critCap //in percentage
    }
}
