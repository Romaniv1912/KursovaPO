using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationCityProject
{
    /// <summary>
    /// Предсавляет собой человека.
    /// </summary>
    class Person
    {
        /// <summary>
        /// Имя человека.
        /// </summary>
        public String Name {
            get; protected set;
        }

        /// <summary>
        /// Возраст человека.
        /// </summary>
        public int Age {
            get; protected set;
        }

        /// <summary>
        /// Дом человека.
        /// </summary>
        public House house {
            get; protected set;
        }

        /// <summary>
        /// Карта человека.
        /// </summary>
        protected Card card;

        /// <summary>
        /// Анагство по недвижымости.
        /// </summary>
        protected RealEastateAgency shop;


        /// <summary>
        /// Банк.
        /// </summary>
        protected Proxy rBank;
        
        /// <summary>
        /// Логин.
        /// </summary>
        protected String login;

        /// <summary>
        /// Пароль.
        /// </summary>
        protected String password;

        /// <summary>
        /// Пин-КОД.
        /// </summary>
        protected String pinKOD;


        /// <summary>
        /// Создает екземпляр объекта <see cref="Person"/>.
        /// </summary>
        /// <param name="name">Имя человека.</param>
        /// <param name="age">Возраст человека.</param>
        public Person(String name, int age)
        {
            this.Name = name;
            Random rnd = new Random();
            this.login = rnd.Next(10000, 100000).ToString();
            this.pinKOD = rnd.Next(10000, 100000).ToString();
            this.Age = age;
        }

        /// <summary>
        /// Регистрация и выдача карты в банке.
        /// </summary>
        /// <param name="bank">Банк в котором пользователь зарегистрируется.</param>
        /// <returns>Если всё прошло успешно тогда <see cref="true"/>, иначе <see cref="false"/></returns>
        public bool regBank(Proxy bank)
        {
            rBank = bank;
            rBank.registration(Name, login, password, false, Age);
            return rBank.getCard(login, password, out card, out pinKOD);      
        }

        /// <summary>
        /// Покупка дома.
        /// </summary>
        public bool buyHouse()
        {
            if (house != null && card != null)
            {
                Random rnd = new Random();
                shop.selectType(rnd.Next(0, 2));
                shop.selectHouse(rnd.Next(0, 4));
                house = shop.buy(card, pinKOD);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Перегрузка метода <see cref="Person.ToString"/>.
        /// </summary>
        /// <returns>Возвращает информацию об объекте.</returns>
        public override string ToString()
        {
            return "\tName: " + Name + "\tage: " + Age + "\tCard: " + 
                (card == null ? "NoN" : card.CardNumber) + 
                (house == null ? "\t House: NoN": "\nHouse:\n"+ house.ToString());
        }
    }
}
