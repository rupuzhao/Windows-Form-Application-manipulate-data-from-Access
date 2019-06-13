using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_9_BusDriverDB
{
    public class Candidate
    {
        public Candidate(string driverId, string name, string age)
        {
            this.DriverID = driverId;
            this.Name = name;
            this.Age = age;
        }
        public string DriverID { set; get; }
        public string Name { set; get; }
        public string Age { set; get; }

        public string Details()
        {
            return DriverID + Name + Age;
        }
    }
}
