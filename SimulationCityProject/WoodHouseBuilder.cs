using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationCityProject
{ 
    /// <summary>
    /// Создает <see cref="House"/>.
    /// </summary>
    public class WoodHouseBuilder : HouseBuilder
    {
        /// <summary>
        /// Создает екземпляр объекта <see cref="WoodHouseBuilder"/>.
        /// </summary>
        public WoodHouseBuilder() : base()
        {
            SPECIALIZE = "wood";
        }
    }
    
    /// <summary>
    /// Создает <see cref="HousePlane"/>.
    /// </summary>
    public class WoodPlaneHouseBuilder : PlaneBuilder
    {
        /// <summary>
        /// Создает екземпляр объекта <see cref="WoodPlaneHouseBuilder"/>.
        /// </summary>
        public WoodPlaneHouseBuilder() : base()
        {
            SPECIALIZE = "wood";
            PRICE_WALL = 4;
            PRICE_WINDOW = 15;
            PRICE_DOOR = 20;
            PRICE_GARAGE = 100;
            PRICE_ROOF = 75;
            PRICE_FLOOR = 140;
        }
    }
}
