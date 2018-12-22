using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationCityProject
{
    class CitySimulation
    {
        static void Main(string[] args)
        {
            List<Person> listPerson = new List<Person>();
            RealBank rb = new RealBank();
            Proxy pb = new Proxy(rb,"1111");
            RealEastateAgency rea = new RealEastateAgency("Comp", pb);

            while (!Console.ReadLine().Equals("exit"))
            {
                listPerson.Add(new Person("Person"+ listPerson.Count.ToString(), 20));
                listPerson.Last().regBank(pb);
                pb.cashIn(listPerson.Last().Card, 20000);
                listPerson.Last().buyHouse(rea);
                Console.Clear();
                foreach (Person per in listPerson)
                {
                    Console.WriteLine("----------------------");
                    Console.WriteLine(per.ToString());
                }
            }
        }
    }
}
