using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationCityProject
{
    /// <summary>
    /// Часть из шаблона Заместитель. Представляет собой объект которого замещают.
    /// </summary>
    public class RealBank : Bank
    {
        /// <summary>
        /// Список всех акаунтов в банке.
        /// </summary>
        private List<Account> listAccount;

        /// <summary>
        /// Индендефикатоы банка.
        /// </summary>
        private List<String> bankNumber;

        /// <summary>
        /// Создает объект типа <see cref="RealBank"/>.
        /// </summary>
        public RealBank()
        {
            listAccount = new List<Account>();
            bankNumber = new List<string>();
        }

        /// <summary>
        /// Регистрация пользователя.
        /// </summary>
        /// <param name="name">Имя пользователя.</param>
        /// <param name="login">Логин пользователя.</param>
        /// <param name="password">Пароль пользователя.</param>
        /// <param name="isCompany">Переменная которая определяет пользователя(комрания/человек).</param>
        /// <param name="age">Возраст ползователя. Если пользователь это комрания то возраст равен -1.</param>
        /// <returns>Возвращает <see cref="true"/> если операция прошла, в противном случаи <see cref="false"/>.</returns>
        public bool registration(String name, String login, String password, bool isCompany, int age)
        {
            Account acc = new Account(name, login, password, this.listAccount.Count, isCompany, age);
            foreach (Account val in this.listAccount)
            {
                if (val == acc )
                    return false;
            }
            this.listAccount.Add(acc);
            return true;
        }

        /// <summary>
        /// Генерация карты.
        /// </summary>
        /// <param name="login">Логин пользователя.</param>
        /// <param name="password">Пароль пользователя.</param>
        /// <param name="card"></param>
        /// <param name="pinKOD">Пин-КОД пользователя.</param>
        /// <returns>Возвращает <see cref="true"/> если операция прошла, в противном случаи <see cref="false"/></returns>
        public bool getCard(String login, String password, out Card card, out String pinKOD)
        {
            int hash = password.GetHashCode() + login.GetHashCode();
            foreach (Account acc in this.listAccount)
            {
                if (acc.GetHashCodeLogIn() == hash)
                {
                    Random rnd = new Random();
                    return acc.generateCard(this.bankNumber[rnd.Next(0, this.bankNumber.Count)] 
                            + rnd.Next(1000, 10000).ToString()
                            + rnd.Next(1000, 10000).ToString()
                            + rnd.Next(1000, 10000).ToString()
                            , out card, out pinKOD);
                }
            }
            card = null;
            pinKOD = "";
            return false;
        }

        /// <summary>
        /// Операция начисления денег.
        /// </summary>
        /// <param name="card">Карта на которою будут начислены деньги.</param>
        /// <param name="cash">Сумма на которою будет пополнен счёт.</param>
        /// <returns>Возвращает <see cref="true"/> если операция прошла, в противном случаи <see cref="false"/>.</returns>
        public bool cashIn(Card card, float cash)
        {
            foreach(Account acc in this.listAccount)
            {
                if (acc.cashIn(card, cash))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Операция снятия денег.
        /// </summary>
        /// <param name="card">Карта с которой будут сняты деньги.</param>
        /// <param name="pinKOD">Пин-КОД для карты.</param>
        /// <param name="cash">Кол-во денег которые будут сняты со счёта.</param>
        /// <returns>Возвращает -1 если операция не прошла, иначе возвращает число.</returns>
        public float cashOut(Card card, String pinKOD, float cash)
        {
            foreach (Account acc in this.listAccount)
            {
                if (acc.cashOut(card, pinKOD, cash) > -1)
                {
                    return cash;
                }
            }
            return -1;
        }

        /// <summary>
        /// Даёт информацию о пользователе.
        /// </summary>
        /// <param name="login">Логин пользователя.</param>
        /// <param name="password">Пароль пользователя.</param>
        /// <returns>Возвращает информацию о пользователе.</returns>
        public string getUserInfo(String login, String password)
        {
            int hash = password.GetHashCode() + login.GetHashCode();
            for (int i = 0; i < this.listAccount.Count; i++)
            {
                if (this.listAccount[i].GetHashCodeLogIn() == hash)
                {
                    return this.listAccount[i].ToString();
                }
            }
            return "Не верные даные.";
        }

        /// <summary>
        /// Добавления индентификатора банка.
        /// </summary>
        /// <param name="bankNumber">Индентификатор банка.</param>
        /// <returns>Возвращает <see cref="true"/> если операция прошла, в противном случаи <see cref="false"/>.</returns>
        public bool addBankNuber(String bankNumber)
        {
            this.bankNumber.Add(bankNumber);
            return true;
        }

        /// <summary>
        /// Возвращает баланс пользователя на карте.
        /// </summary>
        /// <param name="login">Логин пользователя.</param>
        /// <param name="password">Пароль пользователя.</param>
        /// <param name="card">Карта пользователя.</param>
        /// <returns>Возвращает -1 когда операция не прошла, а если прошла тогда баланс.</returns>
        public float showBalance(String login, String password, Card card)
        {
            int hash = password.GetHashCode() + login.GetHashCode();
            foreach (Account acc in this.listAccount)
            {
                if (acc.GetHashCodeLogIn() == hash)
                {
                    for (int i = 0; i < acc.CardList.Count; i++)
                    {
                        if (acc.CardList[i] == card)
                        {
                            return acc.Balance[i];
                        }
                    }
                }
            }
            return -1;
        }
    }
}
