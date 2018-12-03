using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationCityProject
{
    /// <summary>
    /// Один из элементов патерана Строитель.
    /// </summary>
    public class Director
    {   
        /// <summary>
        /// Строитель.
        /// </summary>
        private Builder builder;

        /// <summary>
        /// Создает екземпляр объекта <see cref="Builder"/> который создает план дома, в зависимости от <paramref name="type"/>.
        /// </summary>
        /// <param name="type">Тип материала.</param>
        public void setPlaneBuilder(int type)
        {
            switch(type)
            {
                case 0: builder = new WoodPlaneHouseBuilder();
                    break;
                case 1: builder = new RockPlaneHouseBuilder();
                    break;
            }
        }

        /// <summary>
        /// Создает екземпляр объекта <see cref="Builder"/> который создает дом, в зависимости от <paramref name="type"/>.
        /// </summary>
        /// <param name="type">Тип дома.</param>
        public void setHouseBuilder(int type)
        {
            switch (type)
            {
                case 0:
                    builder = new WoodHouseBuilder();
                    break;
                case 1:
                    builder = new RockHouseBuilder();
                    break;
            }
        }

        /// <summary>
        /// Создает екземпляр объекта <see cref="object"/>, в зависимости от <paramref name="house"/>. 
        /// </summary>
        /// <param name="house"></param>
        public object buildHouse(int house)
        {
            object obj = null;
            switch (house)
            {
                case 0: obj = smallHouse(); break;
                case 1: obj = simpleHouse(); break;
                case 2: obj = mediumHouse(); break;
                case 3: obj = largeHouse(); break;
            }
            return obj;
        }

        /// <summary>
        /// Строит маленький дом.
        /// </summary>
        public object smallHouse()
        {
            builder.reset();
            builder.createFloor();
            builder.createWalls(4);
            builder.createWindows(2);
            builder.createDoors();
            builder.createRoof();
            return builder.getResult();
        }

        /// <summary>
        /// Строит простой дом.
        /// </summary>
        public object simpleHouse()
        {
            builder.reset();
            builder.createFloor();
            builder.createWalls(6);
            builder.createWindows(4);
            builder.createDoors(3);
            builder.createRoof();
            builder.createGarage();
            return builder.getResult();
        }

        /// <summary>
        /// Строит средний дом.
        /// </summary>
        public object mediumHouse()
        {
            builder.reset();
            builder.createFloor();
            builder.createFloor();
            builder.createWalls(14);
            builder.createWindows(8);
            builder.createDoors(5);
            builder.createRoof();
            builder.createGarage();
            return builder.getResult();
        }

        /// <summary>
        /// Строит большой дом.
        /// </summary>
        public object largeHouse()
        {
            builder.reset();
            builder.createFloor();
            builder.createFloor();
            builder.createFloor();
            builder.createWalls(40);
            builder.createWindows(60);
            builder.createDoors(20);
            builder.createRoof();
            builder.createRoof();
            builder.createGarage();
            builder.createGarage();
            return builder.getResult();
        }
    }
}
