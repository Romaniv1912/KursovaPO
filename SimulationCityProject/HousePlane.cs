using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationCityProject
{
    /// <summary>
    /// Создает план дома и позволяет ему указать суммузаранее.
    /// </summary>
    public class HousePlane
    {   
        /// <summary>
        /// Список состоящий из частей дома.
        /// </summary>
        private List<String> names;

        /// <summary>
        /// Цена каждой части дома.
        /// </summary>
        private List<int> prices;

        /// <summary>
        /// Создает екземпляр объекта <see cref="HousePlane"/>
        /// </summary>
        public HousePlane()
        {
            names = new List<String>();
            prices = new List<int>();
        }

        /// <summary>
        /// Доавляет часть дома.
        /// </summary>
        /// <param name="name">Имя части из которой состоит дом.</param>
        /// <param name="price">Цена.</param>
        public void Add(String name, int price)
        {
            names.Add(name);
            prices.Add(price);
        }

        /// <summary>
        /// Подсчитует цену дома.
        /// </summary>
        public int getPrice()
        {
            int totalPrice = 0;
            for (int i = 0; i < prices.Count; i++)
            {
                totalPrice += prices[i];
            }
            return totalPrice;
        }

        /// <summary>
        /// Перегрузка метода <see cref="HousePlane.ToString"/>.
        /// </summary>
        /// <returns>Возвращает строку в которой находятся список частей из которых состоит дом.</returns>
        public override string ToString()
        {
            String str = String.Empty;
            for (int i = 0; i < this.names.Count; i++)
            {
                str += "\t" + names[i] + " - " + prices[i].ToString() + ", ";
            }
            str = str.Remove(str.Length - 2);
            return "Prouct parts: " + str;
        }
    }
}
