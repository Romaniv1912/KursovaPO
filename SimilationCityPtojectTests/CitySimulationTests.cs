using SimulationCityProject;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimulationCityProject.Tests
{
    [TestClass()]
    public class CitySimulationTests
    {
        RealBank rb;
        Proxy pr;
        Card crd1, crd2;
        String l1 = "login_first_user",
                p1 = "password_first_user",
                l2 = "login_second_user",
                p2 = "password_second_user",
                pinKOD1 = "",
                pinKOD2 = "";

        public CitySimulationTests()
        {
            rb = new RealBank();
            pr = new Proxy(rb, "1111");
        }

        /// <summary>
        /// Метод проверяющий работу конструктора <see cref="Card"/> и метода <see cref="Card.Equals(object)"/>.
        /// </summary>
        [TestMethod]
        public void Equals_Card()
        {
            DateTime date = new DateTime();
            Card c1 = new Card("1111 1111 1111 1111", date);
            Card c2 = new Card("1111 1111 1111 1111", date);
            Assert.AreEqual(c1, c2); 
        }


        /// <summary>
        /// Проверяет клас <see cref="Account"/> работают ли методы <see cref="Account.cashIn(Card, float)"/> и <see cref="Account.cashOut(Card, string, float)"/>.
        /// </summary>
        [TestMethod]
        public void CheckAccountCash_OutIn()
        {
            Account acc = new Account("Some company","login","password",1);
            Card card;
            String pin;
            if(!acc.generateCard("1111111111111111",out card, out pin))
            {
                Assert.IsTrue(false);
            }
            if(!acc.cashIn(card, 2000))
            {
                Assert.IsTrue(false);
            }
            Assert.IsTrue(acc.cashOut(card, pin, 1000) < 0 ? false: true);
        }

        /// <summary>
        /// Проверяет работу метода <see cref="Proxy.registration(string, string, string, bool, int)"./>
        /// </summary>
        [TestMethod]
        public void CheckRegistrationBank()
        {   
            if (!pr.registration("first user", l1, p1, false, 18))
                Assert.IsTrue(false);
            if (!pr.registration("second user", l2, p2, false, 26))
                Assert.IsTrue(false);
            Assert.IsTrue(true);
        }

        /// <summary>
        /// Проверяет работу метода <see cref="Proxy.getCard(string, string, out Card, out string)"/>.
        /// </summary>
        [TestMethod]
        public void CheckGetCard()
        {
            CheckRegistrationBank();
            if (!pr.getCard(l1, p1, out crd1, out pinKOD1))
                Assert.IsTrue(false);
            if (!pr.getCard(l2, p2, out crd2, out pinKOD2))
                Assert.IsTrue(false);
            Assert.IsTrue(true);
        }


        /// <summary>
        /// Проверяет работу метода <see cref="Proxy.transfer(Card, Card, string, float)"/>.
        /// </summary>
        [TestMethod]
        public void CheckTransfer()
        {
            CheckGetCard();
            pr.cashIn(crd1, 3000);
            pr.cashIn(crd2, 5000);
            if (!pr.transfer(crd2, crd1, pinKOD2, 5000))
                Assert.IsTrue(false);
            Assert.IsTrue(pr.cashOut(crd1, pinKOD1, 8000) > 0 ? true: false);
        }

        /// <summary>
        /// Проверяет работу <see cref="Builder"/> & <see cref="WoodPlaneHouseBuilder"/>.
        /// </summary>
        [TestMethod]
        public void CheckPlaneBuilder()
        {
            WoodPlaneHouseBuilder wdPl = new WoodPlaneHouseBuilder();
            wdPl.createFloor();
            wdPl.createWalls(4);
            wdPl.createWindows(4);
            wdPl.createDoors(1);
            wdPl.createRoof();
            HousePlane actual = wdPl.getResult() as HousePlane;
            int expected = wdPl.PRICE_DOOR + wdPl.PRICE_FLOOR + wdPl.PRICE_ROOF + wdPl.PRICE_WALL * 4 + wdPl.PRICE_WINDOW * 4;
            Assert.AreEqual(expected, actual.getPrice());
        }

        [TestMethod]
        public void CheckShopBuy()
        {
            CheckTransfer();
            RealEastateAgency ra = new RealEastateAgency("comp", pr);
            pr.cashIn(crd1, 5000);
            ra.selectType(1);
            ra.selectHouse(1);
            Assert.IsNotNull(ra.buy(crd1, pinKOD1));
        }
    }
}
