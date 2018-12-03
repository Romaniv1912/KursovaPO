using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationCityProject
{
    /// <summary>
    /// Объектк имитирующий агенство по недвижымости.
    /// </summary>
    public class RealEastateAgency
    {
        /// <summary>
        /// Имя компании.
        /// </summary>
        public String CompanyName {
            get; protected set;
        }

        /// <summary>
        /// Логин компании в банке.
        /// </summary>
        private String login;

        /// <summary>
        /// Пароль компании в банке.
        /// </summary>
        private String password;

        /// <summary>
        /// Карта компании.
        /// </summary>
        private Card cardCompany;

        /// <summary>
        /// Пин-КОД от карты.
        /// </summary>
        private String pinKOD;

        /// <summary>
        /// Банк карты компании.
        /// </summary>
        private Proxy pBank;

        /// <summary>
        /// Директор который работает со строителями.
        /// </summary>
        private Director director;

        /// <summary>
        /// Материал из которого сделан дом.
        /// </summary>
        private int type;

        /// <summary>
        /// Тип домов.
        /// </summary>
        private int house;

        /// <summary>
        /// Создает екземпляр объекта <see cref="RealEastateAgency"/>.
        /// </summary>
        /// <param name="companyName">Имя компании.</param>
        /// <param name="bank">Банк к которому будет привязана компания.</param>
        public RealEastateAgency(String companyName,Proxy bank)
        {
            CompanyName = companyName;
            pBank = bank;
            login = new Random().Next(10000, 100000).ToString();
            password = new Random().Next(10000, 100000).ToString();
            pBank.registration(CompanyName, login, password , true, -1);
            pBank.getCard(login, password, out cardCompany, out pinKOD);
            director = new Director();
            type = -1;
            house = -1;
        }

        /// <summary>
        /// Возвращает список возможных материалов.
        /// </summary>
        public String getTypesOfHouse()
        {
            return "1. Wood house\n2.Rock house";
        }

        /// <summary>
        /// Устанавливает тип материала.
        /// </summary>
        /// <param name="type">Тип материала.</param>
        public void selectType(int type)
        {
            this.type = type;
        }

        /// <summary>
        /// Возвращает список возможных домов.
        /// </summary>
        public String getListHouse()
        {
            return "1. small house\n2. simple house\n3.medium house\n4.lager house";
        }

        /// <summary>
        /// Устанавливает тип дома.
        /// </summary>
        /// <param name="house">Тип дома.</param>
        public void selectHouse(int house)
        {
            this.house = house;
        }

        /// <summary>
        /// Производит покупку дома выбраного ранее.
        /// </summary>
        /// <param name="card">Карта покупателя.</param>
        /// <param name="pinU">Пин-КОД покупателя.</param>
        /// <returns></returns>
        public House buy(Card card, String pinU)
        {
            director.setPlaneBuilder(type); 

            int price = (director.buildHouse(house) as HousePlane).getPrice();
            if (pBank.transfer(card, cardCompany, pinU, price))
            {
                director.setHouseBuilder(type);
                return (director.buildHouse(house) as House);
            }
            return null;
        }
    }
}
