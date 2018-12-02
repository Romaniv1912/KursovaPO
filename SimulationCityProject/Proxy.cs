using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationCityProject
{
    /// <summary>
    /// Часть из шаблона Заместитель. Представляет собой заместителя.
    /// </summary>
    public class Proxy : Bank
    {
        /// <summary>
        /// Оганичения выдачи карт по возрасту.
        /// </summary>
        private static int AGE_LIMIT = 16;

        /// <summary>
        /// Сообщения об успешно пройденой операции.
        /// </summary>
        private static String OPERATION_SUCCES_MES = "Операция завершена.";

        /// <summary>
        /// Сообщения об не пройденой операции.
        /// </summary>
        private static String OPERATION_DENY_MES = "Операция не прошла.";

        /// <summary>
        /// Ссылка на обьект типа <see cref="RealBank"/>.
        /// </summary>
        private RealBank bank;

        /// <summary>
        /// Индентификаторы банка.
        /// </summary>
        private List<String> bankNumbers;

        /// <summary>
        /// Свойство которое отвечает за отображение логов.
        /// <see cref="true"/> - отображение включено.
        /// <see cref="false"/> - отображение выключено.
        /// </summary>
        public bool ShowLogs
        {
            get; private set;
        }

        /// <summary>
        /// Создает объект типа <see cref="Proxy"/>.
        /// </summary>
        /// <param name="bank">Ссылка на объект который будет замещен заместителем.</param>
        /// <param name="bankNum">Индентыфикатор банка.</param>
        /// <param name="showLogs">Отображение логов.</param>
        public Proxy(RealBank bank, String bankNum, bool showLogs = false)
        {
            this.bank = bank;
            this.bankNumbers = new List<string>();
            this.addBankNuber(bankNum);
            this.ShowLogs = showLogs;
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
            return this.bank.getCard(login, password, out card, out pinKOD);
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
            if (this.ShowLogs)
                Console.WriteLine(DateTime.Today.ToString() + ": Регистрация пользователя " + name + ".");
            if (age > AGE_LIMIT && !name.Equals("") && !login.Equals("") && !password.Equals(""))
            {
                if (this.bank.registration(name, login, password, isCompany, age))
                {
                    if (this.ShowLogs)
                        Console.WriteLine(DateTime.Today.ToString() + ":  Регистрация прошла усрешно!");
                    return true;
                }
            }
            if (this.ShowLogs)
                Console.WriteLine(DateTime.Today.ToString() + ": Регистрация не удалась!");
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
            if (this.ShowLogs)
                Console.WriteLine(DateTime.Today.ToString() + ": Начисления на карту " + card.CardNumber + ".");
            if (checkCard(card))
            {
                if (this.ShowLogs)
                    Console.WriteLine(DateTime.Today.ToString() + ": " + OPERATION_SUCCES_MES);
                return this.bank.cashIn(card, cash);
            }
            if (this.ShowLogs)
                Console.WriteLine(DateTime.Today.ToString() + ": " + OPERATION_DENY_MES);
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
            if (this.ShowLogs)
                Console.WriteLine(DateTime.Today.ToString() + ": Снятие денег с карты " + card.CardNumber + ".");
            if (checkCard(card))
            {
                if (this.ShowLogs)
                    Console.WriteLine(DateTime.Today.ToString() + ":  " + OPERATION_SUCCES_MES);
                return this.bank.cashOut(card, pinKOD, cash);
            }
            if (this.ShowLogs)
                Console.WriteLine(DateTime.Today.ToString() + ": " + OPERATION_DENY_MES);
            return -1;
        }

        /// <summary>
        /// Проверка карты на подленость.
        /// </summary>
        /// <param name="card">Карта</param>
        /// <returns></returns>
        private bool checkCard(Card card)
        {
            if (this.ShowLogs)
                Console.WriteLine(DateTime.Today.ToString() + ": Проверка карты - " + card.GetHashCode().ToString() + ".");
            if (card.CardNumber.Length == 16)
            {
                foreach (String str in this.bankNumbers)
                {
                    if (card.CardNumber.StartsWith(str))
                    {
                        if (this.ShowLogs)
                            Console.WriteLine(DateTime.Today.ToString() + ": Карта прошла проверку.");
                        return true;
                    }
                }
            }
            if (this.ShowLogs)
                Console.WriteLine(DateTime.Today.ToString() + ": Карта не подходит.");
            return false;
        }

        /// <summary>
        /// Операция перевода денег.
        /// </summary>
        /// <param name="cardFrom">Карта отправителя.</param>
        /// <param name="cardTo">Карта получателя.</param>
        /// <param name="pinKOD">Пин-КОД отправителя.</param>
        /// <param name="cash">Сумма.</param>
        /// <returns>Возвращает <see cref="true"/> если операция прошла, в противном случаи <see cref="false"/>.</returns>
        public bool transfer(Card cardFrom, Card cardTo, String pinKOD, float cash)
        {
            if (checkCard(cardTo))
            {
                cash = this.bank.cashOut(cardFrom, pinKOD, cash);
                if (cash > -1)
                {
                    if (!this.cashIn(cardTo, cash))
                    {
                        this.bank.cashIn(cardFrom, cash);
                        return false;
                    }
                    else 
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Даёт информацию о пользователе.
        /// </summary>
        /// <param name="login">Логин пользователя.</param>
        /// <param name="password">Пароль пользователя.</param>
        /// <returns>Возвращает информацию о пользователе.</returns>
        public string getUserInfo(String login, String password)
        {
            return this.bank.getUserInfo(login, password);
        }

        /// <summary>
        /// Добавления индентификатора банка.
        /// </summary>
        /// <param name="bankNumber">Индентификатор банка.</param>
        /// <returns>Возвращает <see cref="true"/> если операция прошла, в противном случаи <see cref="false"/>.</returns>
        public bool addBankNuber(String bankNumber)
        {
            if (this.ShowLogs)
                Console.WriteLine(DateTime.Today.ToString() + ": Индентификатор банка - " + bankNumber + " добавление.");
            if (bankNumber.Length == 4)
            {
                
                if (this.ShowLogs)
                    Console.WriteLine(DateTime.Today.ToString() + ": Индентификатор банка добавлен.");
                this.bankNumbers.Add(bankNumber);
                return this.bank.addBankNuber(bankNumber);
            }
            if (this.ShowLogs)
                Console.WriteLine(DateTime.Today.ToString() + ": Операция отвергнута.");
            return false;
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
            return this.bank.showBalance(login, password, card);
        }
    }
}
