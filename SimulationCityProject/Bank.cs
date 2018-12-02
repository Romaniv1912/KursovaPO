using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationCityProject
{
    /// <summary>
    /// Патерн заместитель.
    /// </summary>
    public interface Bank
    {
        bool getCard(String login, String password, out Card card, out String pinKOD);    

        bool registration(String name, String login, String password, bool isCompany, int age);

        bool cashIn(Card card, float cash);

        float cashOut(Card card, String pinKOD, float cash);

        string getUserInfo(String login, String password);
        
        bool addBankNuber(String bankNumber);

        float showBalance(String login, String password, Card card);
    }
}
