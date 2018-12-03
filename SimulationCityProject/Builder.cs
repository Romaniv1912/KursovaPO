using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationCityProject
{
    /// <summary>
    /// Часть патерна Строитель.
    /// </summary>
    public interface Builder
    {
        /// <summary>
        /// Сбрасывает уже созданый продукт.
        /// </summary>
        void reset();

        /// <summary>
        /// Строит стены.
        /// </summary>
        /// <param name="n">Кол-во стен.</param>
        void createWalls(int n = 1);

        /// <summary>
        /// Строит окна.
        /// </summary>
        /// <param name="n">Кол-во окон.</param>
        void createWindows(int n = 1);

        /// <summary>
        /// Строит двери.
        /// </summary>
        /// <param name="n">Кол-во дверей.</param>
        void createDoors(int n = 1);

        /// <summary>
        /// Строит гараж.
        /// </summary>
        void createGarage();

        /// <summary>
        /// Создает крышу.
        /// </summary>
        void createRoof();

        /// <summary>
        /// Создает этаж.
        /// </summary>
        void createFloor();

        /// <summary>
        /// Возвращает результат работы <see cref="Builder"/>.
        /// </summary>
        object getResult();
    }
}
