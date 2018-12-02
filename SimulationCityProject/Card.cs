using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationCityProject
{
    /// <summary>
    ///  Класс имитирующий карту
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Максимальное чсло для генерации номера на задней части карты.
        /// </summary>
        protected static int MAX_NUMBER_GEN = 10000000;

        /// <summary>
        /// Минимальное чсло для генерации номера на задней части карты.
        /// </summary>
        protected static int MIN_NUMBER_GEN = 1000000;

        /// <summary>
        /// Номер карты. 
        /// Состоит из 16 цыфр(4 - банк, остальные пользоветель)
        /// </summary>
        public String CardNumber {
            get; private set;
        }

        /// <summary>
        /// Номер на задней части карты.
        /// </summary>
        public String AccesKOD {
            get; private set;
        }

        /// <summary>
        /// Срок годности кары.
        /// </summary>
        public DateTime DateLimit {
            get; private set;
        }

        /// <summary>
        /// Конструктор который инициализирует все переменные.
        /// </summary>
        /// <param name="cardNumber">Номер карты.</param>
        /// <param name="dateLimit">Срок годности кары.</param>
        public Card(String cardNumber, DateTime dateLimit)
        {
            this.CardNumber = cardNumber;
            this.DateLimit = dateLimit;
            this.AccesKOD = Convert.ToString(new Random().Next(MIN_NUMBER_GEN, MAX_NUMBER_GEN));
        }

        /// <summary>
        /// Перегрезка оператора равно.
        /// </summary>
        /// <returns>Возвращает переменную типа <see cref="bool"/>.</returns>
        public static bool operator ==(Card card1, Card card2)
        {
            return card1.GetHashCode() == card2.GetHashCode();
        }

        /// <summary>
        /// Перегрезка оператора не равно.
        /// </summary>
        /// <returns>>Возвращает переменную типа <see cref="bool"/>.</returns>
        public static bool operator !=(Card card1, Card card2)
        {
            return !(card1 == card2);
        }
        
        /// <summary>
        /// Сравнивает два обекта типа <see cref="Card"/>.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj is Card)
            {
                return (obj as Card) == this;
            }
            return false;
        }

        /// <summary>
        /// Формирует строку для <see cref="Card"/>.
        /// </summary>
        public override string ToString()
        {
            return "Card:\n" + "card namber: " + this.CardNumber 
                + "\ncode: " + this.AccesKOD 
                + "\nexpires end: " + this.DateLimit.ToShortDateString();
        }

        /// <summary>
        /// Формирует хэш для <see cref="Card"/>.
        /// </summary>
        public override int GetHashCode()
        {
            return this.CardNumber.GetHashCode() + this.DateLimit.GetHashCode();
        }
    }
}
