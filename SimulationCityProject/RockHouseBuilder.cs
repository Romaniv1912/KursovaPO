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
    public class RockHouseBuilder : HouseBuilder
    {
        /// <summary>
        ///  Создает екземпляр объекта <see cref="RockHouseBuilder"/>.
        /// </summary>
        public RockHouseBuilder() : base()
        {
            SPECIALIZE = "wood";
        }
    }

    /// <summary>
    /// Создает <see cref="HousePlane"/>.
    /// </summary>
    public class RockPlaneHouseBuilder : PlaneBuilder
    {
        /// <summary>
        ///  Создает екземпляр объекта <see cref="RockPlaneHouseBuilder"/>.
        /// </summary>
        public RockPlaneHouseBuilder() : base()
        {
            SPECIALIZE = "wood";
            PRICE_WALL = 20;
            PRICE_WINDOW = 15;
            PRICE_DOOR = 18;
            PRICE_GARAGE = 60;
            PRICE_ROOF = 200;
            PRICE_FLOOR = 143;
        }
    }
}
