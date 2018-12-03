using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationCityProject
{
    /// <summary>
    /// Представляет собой дом.
    /// </summary>
    public class House
    {
        /// <summary>
        ///  Список состоящий из частей дома.
        /// </summary>
        private List<String> names;

        /// <summary>
        /// Создает екземпляр объекта <see cref="House"/>.
        /// </summary>
        public House()
        {
            names = new List<String>();
        }

        /// <summary>
        /// Доавляет часть дома.
        /// </summary>
        /// <param name="name">Имя части из которой состоит дом.</param>
        /// <param name="price">Цена.</param>
        public void Add(String name)
        {
            names.Add(name);
        }


        /// <summary>
        /// Перегрузка метода <see cref="House.ToString"/>.
        /// </summary>
        /// <returns>Возвращает строку в которой находятся список частей из которых состоит дом.</returns>
        public override string ToString()
        {
            String str = String.Empty;
            for(int i = 0; i < this.names.Count; i++)
            {
                str += names[i] + ", ";
            }
            str = str.Remove(str.Length - 2);
            return "Prouct parts: " + str;
        }
    }
}
