using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationCityProject
{
    /// <summary>
    /// Класс имитирующий аккаунт пользователя.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Создает екземпляр класса.<see cref="Account"/>
        /// </summary>
        /// <param name="name">Имя пользователя.</param>
        /// <param name="login">Логин пользователя.</param>
        /// <param name="password">Пароль пользователя.</param>
        /// <param name="id">Индентификатор пользователя.</param>
        /// <param name="isCompany">Переменная которая опеделяет кому пренадлежит аккаунт(человеку/компании).</param>
        /// <param name="age">Возразст.</param>
        /// <remarks>Пользователем может быть как человеком так и компанией.</remarks>
        public Account(String name, String login, String password, int id, bool isCompany = false, int age = -1)
        {
            this.Name = name;
            this.Age = age;
            this.Login = login;
            this.Password = password;
            this.Id = id;
            this.IsCompany = isCompany;
            this.CardList = new List<Card>();
            this.PinKODList = new List<string>();
            this.Balance = new List<float>();
        }


        /// <summary>
        /// Операция снятия наличных.
        /// </summary>
        /// <param name="card">Карта с которой будут сняты деньги.</param>
        /// <param name="pinKOD">Пин-КОД к карте.</param>
        /// <param name="cash">Сумма которую нужно снять.</param>
        /// <returns>Возвращает -1 если операция не прошла.</returns>
        public float cashOut(Card card, String pinKOD, float cash)
        {
            for(int i = 0; i < this.CardList.Count; i++)
            {

                if (this.CardList[i] == card && this.PinKODList[i] == pinKOD && this.Balance[i] >= cash)
                {
                    this.Balance[i] -= cash;
                    return cash;
                }
            }
            return -1;
        }

        /// <summary>
        /// Операция пополнения счёта.
        /// </summary>
        /// <param name="card">Карта куда будут перечислены деньги.</param>
        /// <param name="cash">Сумма на которую будет пополнена карта.</param>
        /// <returns>Возвращает <see cref="true"/> если операция прошла успешно.</returns>
        public bool cashIn(Card card, float cash)
        {
            for (int i = 0; i < this.CardList.Count; i++)
            {

                if (this.CardList[i] == card)
                {
                    this.Balance[i] += cash;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Генерирует карту для пользователя.
        /// </summary>
        /// <param name="numberCard">Номер карты.</param>
        /// <param name="cardOut">Сгенерированая карта</param>
        /// <param name="pinKOD">Пин-КОД карты.</param>
        /// <returns>Возвращает <see cref="true"/> если карта создана успешно</returns>
        public bool generateCard(String numberCard, out Card cardOut, out String pinKOD)
        {
                Card card = new Card(numberCard, DateTime.Now);
                this.Balance.Add(0);
                this.CardList.Add(card);
                this.PinKODList.Add((new Random().Next(1000, 10000)).ToString());
                cardOut = card;
                pinKOD = this.PinKODList.Last();
                return true;
        }

        /// <summary>
        /// Перегрезка оператора равно.
        /// </summary>
        /// <returns>Возвращает переменную типа <see cref="bool"/>.</returns>
        public static bool operator ==(Account acnt1, Account acnt2)
        {
            return acnt1.GetHashCode() == acnt2.GetHashCode();
        }

        /// <summary>
        /// Перегрезка оператора не равно.
        /// </summary>
        /// <returns>Возвращает переменную типа <see cref="bool"/>.</returns>
        public static bool operator !=(Account acnt1, Account acnt2)
        {
            return !(acnt1 == acnt2);
        }

        /// <summary>
        /// Сравнивает два обекта типа <see cref="Account"/>
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj is Account)
            {
                return this == (obj as Account);
            }
            return false;
        }

        /// <summary>
        /// Формирует хэш для <see cref="Account"/>.
        /// </summary>
        public override int GetHashCode()
        {
            return this.Login.GetHashCode() + this.Id.GetHashCode();
        }

        public int GetHashCodeLogIn()
        {
            return this.Login.GetHashCode() + this.Password.GetHashCode();
        }

        /// <summary>
        /// Формирует строку для <see cref="Account"/>.
        /// </summary>
        /// <returns>Возвращает имя и возраст если человек, имя есди компания.</returns>
        public override string ToString()
        {
            return "----------" + (this.IsCompany ? "Compay": "Person") + "-----------\n" 
                    + "Name: " + this.Name + "\n"
                    + (this.IsCompany ? "": "Age :" + this.Age.ToString());
        }

        /// <summary>
        /// Имя компании или человека.
        /// </summary>
        public String Name {
            get; protected set;
        }

        /// <summary>
        /// Возраст. Равен -1 если это компания.
        /// </summary>
        public int Age {
            get; protected set;
        }

        /// <summary>
        /// Переменная типа <see cref="bool"/>, которая опеделяет кому пренадлежит аккаунт(человеку/компании).
        /// </summary>
        public bool IsCompany {
            get; protected set;
        }

        /// <summary>
        /// Пароль от акаунта.
        /// </summary>
        public String Password {
            get; protected set;
        }

        /// <summary>
        /// Список PIN-кодов к картам.
        /// </summary>
        private List<String> PinKODList {
            get; set;
        }

        /// <summary>
        /// Индентификатор акаунта.
        /// </summary>
        private int Id{
            get; set;
        }

        /// <summary>
        /// Логин пользователя.
        /// </summary>
        public String Login {
            get; private set;
        }

        /// <summary>
        /// Список карт привязанык к акаунту.
        /// </summary>
        public List<Card> CardList{
            get; protected set;
        } 

        /// <summary>
        /// Счёта на картах.
        /// </summary>
        public List<float> Balance {
            get; protected set;
        }

    }
}
