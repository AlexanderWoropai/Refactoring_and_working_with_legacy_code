using NUnit.Framework;
using RLCLab;

namespace TestsForProgramm
{
    public class Tests
    {
        [Test]
        public void EmptyBillStatementTest()
        {
            var SomeBill = new Bill(new Customer("SomeUser", 0));
            var expected = "���� ��� SomeUser\n\t��������\t����\t���-�����������\t������\t�����\t�����\n����� ����� ���������� 0\n�� ���������� 0 �������� �����";
            var actual = SomeBill.statement();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UsualStatementTest()
        {
            var SomeBill = new Bill(new Customer("Test", 10));
            var expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tCola\t\t65\t6\t390\t21,7\t368,3\t19\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n\tFanta\t\t35\t1\t35\t0\t35\t0\n����� ����� ���������� 553,3\n�� ���������� 20 �������� �����";
            SomeBill.addGoods(new Item(new Goods("Cola", 0), 6, 65));
            SomeBill.addGoods(new Item(new Goods("Pepsi", 1), 3, 50));
            SomeBill.addGoods(new Item(new Goods("Fanta", 2), 1, 35));
            var actual = SomeBill.statement();
            Assert.AreEqual(expected, actual);
        }
    }
}