using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationCityProject
{
    /// <summary>
    /// Класс который строит дома.
    /// </summary>
    public abstract class HouseBuilder : Builder
    {
        /// <summary>
        /// Специализация строителя.
        /// </summary>
        protected string SPECIALIZE;

        /// <summary>
        /// Дом который строит строитель.
        /// </summary>
        protected House product;


        /// <summary>
        /// Создает екземпляр объекта <see cref="HouseBuilder"/>
        /// </summary>
        public HouseBuilder()
        {
            product = new House();
        }
        
        /// <summary>
        /// <see cref="Builder.reset"/>
        /// </summary>
        public void reset()
        {
            product = new House();
        }

        /// <summary>
        /// <see cref="Builder.createWalls(int)"/>
        /// </summary>
        public void createWalls(int n = 1)
        {
            if (n > 0)
                product.Add(n.ToString() + " - " + SPECIALIZE + " wall" + (n == 1 ? "" : "s"));
        }

        /// <summary>
        /// <see cref="Builder.createWindows(int)"/>
        /// </summary>
        public void createWindows(int n = 1)
        {
            if (n > 0)
                product.Add(n.ToString() + " - " + SPECIALIZE + " window" + (n == 1 ? "" : " s"));
        }

        /// <summary>
        /// <see cref="Builder.createDoors(int)"/>
        /// </summary>
        public void createDoors(int n = 1)
        {
            if (n > 0)
                product.Add(n.ToString() + " - " + SPECIALIZE + " door" + (n == 1 ? "" : " s"));
        }

        /// <summary>
        /// <see cref="Builder.createGarage"/>
        /// </summary>
        public void createGarage()
        {
            product.Add("garage");
        }

        /// <summary>
        /// <see cref="Builder.createRoof"/>
        /// </summary>
        public void createRoof()
        {
            product.Add("roof");
        }

        /// <summary>
        /// <see cref="Builder.createFloor"/>
        /// </summary>
        public void createFloor()
        {
            product.Add("floor");
        }

        /// <summary>
        /// <see cref="Builder.getResult"/>
        /// </summary>
        public object getResult()
        {
            return product;
        }
    }
}
