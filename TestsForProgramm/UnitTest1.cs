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
            var expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n����� ����� ���������� 0\n�� ���������� 0 �������� �����";
            var actual = SomeBill.statement();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UsualStatementTestWithBonuses()
        {
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 10), view);
            var expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tCola\t\t65\t6\t390\t11,7\t368,3\t19\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n\tFanta\t\t35\t1\t35\t0\t35\t0\n����� ����� ���������� 553,3\n�� ���������� 20 �������� �����";
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
            var expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tCola\t\t65\t6\t390\t11,7\t378,3\t19\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n\tFanta\t\t35\t1\t35\t0\t35\t0\n����� ����� ���������� 563,3\n�� ���������� 20 �������� �����";
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
            var expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tCola\t\t65\t6\t390\t11,7\t368,3\t19\n����� ����� ���������� 368,3\n�� ���������� 19 �������� �����";
            SomeBill.addGoods(new Item(new REG("Cola"), 6, 65));
            var actual = SomeBill.statement();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestWithoutBonusesForREG() 
        {
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 0), view);
            var expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tCola\t\t65\t6\t390\t11,7\t378,3\t19\n����� ����� ���������� 378,3\n�� ���������� 19 �������� �����";
            SomeBill.addGoods(new Item(new REG("Cola"), 6, 65));
            var actual = SomeBill.statement();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestWithBonusesForSAL() 
        {
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 10), view);
            var expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n����� ����� ���������� 150\n�� ���������� 1 �������� �����";
            SomeBill.addGoods(new Item(new SAL("Pepsi"), 3, 50));
            var actual = SomeBill.statement();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestWithoutBonusesForSAL() 
        {
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 0), view);
            var expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n����� ����� ���������� 150\n�� ���������� 1 �������� �����";
            SomeBill.addGoods(new Item(new SAL("Pepsi"), 3, 50));
            var actual = SomeBill.statement();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestWithBonusesForSPO() 
        {
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 10), view);
            var expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tFanta\t\t35\t1\t35\t0\t35\t0\n����� ����� ���������� 35\n�� ���������� 0 �������� �����";
            SomeBill.addGoods(new Item(new SPO("Fanta"), 1, 35));
            var actual = SomeBill.statement();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestWithoutBonusesForSPO() 
        {
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 0), view);
            var expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tFanta\t\t35\t1\t35\t0\t35\t0\n����� ����� ���������� 35\n�� ���������� 0 �������� �����";
            SomeBill.addGoods(new Item(new SPO("Fanta"), 1, 35));
            var actual = SomeBill.statement();
            Assert.AreEqual(expected, actual);
        }
    }
}