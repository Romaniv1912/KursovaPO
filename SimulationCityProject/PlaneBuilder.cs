using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationCityProject
{
    /// <summary>
    ///  Создает <see cref="HousePlane"/>
    /// </summary>
    public abstract class PlaneBuilder : Builder
    {
        /// <summary>
        /// План дома.
        /// </summary>
        protected HousePlane product;

        /// <summary>
        /// Материал.
        /// </summary>
        public string SPECIALIZE
        {
            get; protected set;
        }

        /// <summary>
        /// Цена стены.
        /// </summary>
        public int PRICE_WALL
        {
            get; protected set;
        }

        /// <summary>
        /// Цена окна.
        /// </summary>
        public int PRICE_WINDOW
        {
            get; protected set;
        }

        /// <summary>
        /// Цена двери.
        /// </summary>
        public int PRICE_DOOR
        {
            get; protected set;
        }

        /// <summary>
        /// Цена гаража.
        /// </summary>
        public int PRICE_GARAGE
        {
            get; protected set;
        }

        /// <summary>
        /// Цена крышы.
        /// </summary>
        public int PRICE_ROOF
        {
            get; protected set;
        }

        /// <summary>
        /// Цена этажа.
        /// </summary>
        public int PRICE_FLOOR
        {
            get; protected set;
        }

        /// <summary>
        /// Создает екземпляр объекта <see cref="PlaneBuilder"/>
        /// </summary>
        public PlaneBuilder()
        {
            product = new HousePlane();
        }

        public void reset()
        {
            product = new HousePlane();
        }

        public void createWalls(int n = 1)
        {
            if (n > 0)
                product.Add(n.ToString() + " - " + SPECIALIZE + " wall" + (n == 1 ? "" : "s"), PRICE_WALL * n);
        }

        public void createWindows(int n = 1)
        {
            if (n > 0)
                product.Add(n.ToString() + " - " + SPECIALIZE + " window" + (n == 1 ? "" : " s"), PRICE_WINDOW * n);
        }

        public void createDoors(int n = 1)
        {
            if (n > 0)
                product.Add(n.ToString() + " - " + SPECIALIZE + " door" + (n == 1 ? "" : " s"), PRICE_DOOR * n);
        }

        public void createGarage()
        {
            product.Add("garage", PRICE_GARAGE);
        }

        public void createRoof()
        {
            product.Add("roof", PRICE_ROOF);
        }

        public void createFloor()
        {
            product.Add("floor", PRICE_FLOOR);
        }

        public object getResult()
        {
            return product;
        }
    }
}
