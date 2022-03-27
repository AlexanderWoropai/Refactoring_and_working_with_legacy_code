using NUnit.Framework;
using RLCLab;

namespace TestsForProgramm
{
    public class Tests
    {
        [Test]
        public void EmptyBillStatementTest()
        {
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 0), view);
            var expected = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\nСумма счета составляет 0\nВы заработали 0 бонусных балов";
            var actual = SomeBill.statement();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UsualStatementTestWithBonuses()
        {
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 10), view);
            var expected = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t11,7\t368,3\t19\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n\tFanta\t\t35\t1\t35\t0\t35\t0\nСумма счета составляет 553,3\nВы заработали 20 бонусных балов";
            SomeBill.addGoods(new Item(new REG("Cola"), 6, 65));
            SomeBill.addGoods(new Item(new SAL("Pepsi"), 3, 50));
            SomeBill.addGoods(new Item(new SPO("Fanta"), 1, 35));
            var actual = SomeBill.statement();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UsualStatementTestWithoutBonuses() 
        {
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 0), view);
            var expected = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t11,7\t378,3\t19\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n\tFanta\t\t35\t1\t35\t0\t35\t0\nСумма счета составляет 563,3\nВы заработали 20 бонусных балов";
            SomeBill.addGoods(new Item(new REG("Cola"), 6, 65));
            SomeBill.addGoods(new Item(new SAL("Pepsi"), 3, 50));
            SomeBill.addGoods(new Item(new SPO("Fanta"), 1, 35));
            var actual = SomeBill.statement();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestWithBonusesForREG() 
        {
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 10), view);
            var expected = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t11,7\t368,3\t19\nСумма счета составляет 368,3\nВы заработали 19 бонусных балов";
            SomeBill.addGoods(new Item(new REG("Cola"), 6, 65));
            var actual = SomeBill.statement();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestWithoutBonusesForREG() 
        {
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 0), view);
            var expected = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t11,7\t378,3\t19\nСумма счета составляет 378,3\nВы заработали 19 бонусных балов";
            SomeBill.addGoods(new Item(new REG("Cola"), 6, 65));
            var actual = SomeBill.statement();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestWithBonusesForSAL() 
        {
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 10), view);
            var expected = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tPepsi\t\t50\t3\t150\t0\t150\t1\nСумма счета составляет 150\nВы заработали 1 бонусных балов";
            SomeBill.addGoods(new Item(new SAL("Pepsi"), 3, 50));
            var actual = SomeBill.statement();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestWithoutBonusesForSAL() 
        {
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 0), view);
            var expected = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tPepsi\t\t50\t3\t150\t0\t150\t1\nСумма счета составляет 150\nВы заработали 1 бонусных балов";
            SomeBill.addGoods(new Item(new SAL("Pepsi"), 3, 50));
            var actual = SomeBill.statement();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestWithBonusesForSPO() 
        {
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 10), view);
            var expected = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tFanta\t\t35\t1\t35\t0\t35\t0\nСумма счета составляет 35\nВы заработали 0 бонусных балов";
            SomeBill.addGoods(new Item(new SPO("Fanta"), 1, 35));
            var actual = SomeBill.statement();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestWithoutBonusesForSPO() 
        {
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 0), view);
            var expected = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tFanta\t\t35\t1\t35\t0\t35\t0\nСумма счета составляет 35\nВы заработали 0 бонусных балов";
            SomeBill.addGoods(new Item(new SPO("Fanta"), 1, 35));
            var actual = SomeBill.statement();
            Assert.AreEqual(expected, actual);
        }
    }
}