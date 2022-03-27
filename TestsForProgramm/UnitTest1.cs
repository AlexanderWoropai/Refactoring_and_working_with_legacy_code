using NUnit.Framework;
using RLCLab;

namespace TestsForProgramm
{
    public class Tests
    {
        [Test]
        public void TXT_EmptyBillStatementTestWithBonuses()
        {
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 10), view);
            var expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n����� ����� ���������� 0\n�� ���������� 0 �������� �����";
            var actual = SomeBill.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TXT_EmptyBillStatementTestWithoutBonuses()
        {
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 0), view);
            var expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n����� ����� ���������� 0\n�� ���������� 0 �������� �����";
            var actual = SomeBill.GetBill();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TXT_UsualStatementTestWithBonuses()
        {
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 10), view);
            var expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tCola\t\t65\t6\t390\t11,7\t368,3\t19\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n\tFanta\t\t35\t1\t35\t0\t35\t0\n����� ����� ���������� 553,3\n�� ���������� 20 �������� �����";
            SomeBill.addGoods(new Item(new REG("Cola"), 6, 65));
            SomeBill.addGoods(new Item(new SAL("Pepsi"), 3, 50));
            SomeBill.addGoods(new Item(new SPO("Fanta"), 1, 35));
            var actual = SomeBill.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TXT_UsualStatementTestWithoutBonuses() 
        {
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 0), view);
            var expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tCola\t\t65\t6\t390\t11,7\t378,3\t19\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n\tFanta\t\t35\t1\t35\t0\t35\t0\n����� ����� ���������� 563,3\n�� ���������� 20 �������� �����";
            SomeBill.addGoods(new Item(new REG("Cola"), 6, 65));
            SomeBill.addGoods(new Item(new SAL("Pepsi"), 3, 50));
            SomeBill.addGoods(new Item(new SPO("Fanta"), 1, 35));
            var actual = SomeBill.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TXT_TestWithBonusesForREG() 
        {
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 10), view);
            var expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tCola\t\t65\t6\t390\t11,7\t368,3\t19\n����� ����� ���������� 368,3\n�� ���������� 19 �������� �����";
            SomeBill.addGoods(new Item(new REG("Cola"), 6, 65));
            var actual = SomeBill.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TXT_TestWithoutBonusesForREG() 
        {
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 0), view);
            var expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tCola\t\t65\t6\t390\t11,7\t378,3\t19\n����� ����� ���������� 378,3\n�� ���������� 19 �������� �����";
            SomeBill.addGoods(new Item(new REG("Cola"), 6, 65));
            var actual = SomeBill.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TXT_TestWithBonusesForSAL() 
        {
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 10), view);
            var expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n����� ����� ���������� 150\n�� ���������� 1 �������� �����";
            SomeBill.addGoods(new Item(new SAL("Pepsi"), 3, 50));
            var actual = SomeBill.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TXT_TestWithoutBonusesForSAL() 
        {
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 0), view);
            var expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n����� ����� ���������� 150\n�� ���������� 1 �������� �����";
            SomeBill.addGoods(new Item(new SAL("Pepsi"), 3, 50));
            var actual = SomeBill.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TXT_TestWithBonusesForSPO() 
        {
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 10), view);
            var expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tFanta\t\t35\t1\t35\t0\t35\t0\n����� ����� ���������� 35\n�� ���������� 0 �������� �����";
            SomeBill.addGoods(new Item(new SPO("Fanta"), 1, 35));
            var actual = SomeBill.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TXT_TestWithoutBonusesForSPO() 
        {
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 0), view);
            var expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tFanta\t\t35\t1\t35\t0\t35\t0\n����� ����� ���������� 35\n�� ���������� 0 �������� �����";
            SomeBill.addGoods(new Item(new SPO("Fanta"), 1, 35));
            var actual = SomeBill.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HTML_EmptyBillStatementTestWithBonuses()
        {
            IView view = new HtmlView();
            var SomeBill = new Bill(new Customer("Test", 10), view);
            var expected = "<style>.field{width: 100px; float: left;}</style><p>���� ��� Test</p><div class='field'>��������</div><div class='field'>����</div><div class='field'>���-��</div><div class='field'>���������</div><div class='field'>������</div><div class='field'>�����</div><div class='field'>�����</div><br><p>����� ����� ���������� 0</p><p>�� ���������� 0 �������� ������</p>";
            var actual = SomeBill.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HTML_EmptyBillStatementTestWithoutBonuses()
        {
            IView view = new HtmlView();
            var SomeBill = new Bill(new Customer("Test", 0), view);
            var expected = "<style>.field{width: 100px; float: left;}</style><p>���� ��� Test</p><div class='field'>��������</div><div class='field'>����</div><div class='field'>���-��</div><div class='field'>���������</div><div class='field'>������</div><div class='field'>�����</div><div class='field'>�����</div><br><p>����� ����� ���������� 0</p><p>�� ���������� 0 �������� ������</p>";
            var actual = SomeBill.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HTML_UsualStatementTestWithBonuses()
        {
            IView view = new HtmlView();
            var SomeBill = new Bill(new Customer("Test", 10), view);
            var expected = "<style>.field{width: 100px; float: left;}</style><p>���� ��� Test</p><div class='field'>��������</div><div class='field'>����</div><div class='field'>���-��</div><div class='field'>���������</div><div class='field'>������</div><div class='field'>�����</div><div class='field'>�����</div><br><style>.field{width: 100px; float: left;}</style><div class='field'>Cola</div><div class='field'>65</div><div class='field'>6</div><div class='field'>390</div><div class='field'>11,7</div><div class='field'>368,3</div><div class='field'>19</div><br><style>.field{width: 100px; float: left;}</style><div class='field'>Pepsi</div><div class='field'>50</div><div class='field'>3</div><div class='field'>150</div><div class='field'>0</div><div class='field'>150</div><div class='field'>1</div><br><style>.field{width: 100px; float: left;}</style><div class='field'>Fanta</div><div class='field'>35</div><div class='field'>1</div><div class='field'>35</div><div class='field'>0</div><div class='field'>35</div><div class='field'>0</div><br><p>����� ����� ���������� 553,3</p><p>�� ���������� 20 �������� ������</p>";
            SomeBill.addGoods(new Item(new REG("Cola"), 6, 65));
            SomeBill.addGoods(new Item(new SAL("Pepsi"), 3, 50));
            SomeBill.addGoods(new Item(new SPO("Fanta"), 1, 35));
            var actual = SomeBill.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HTML_UsualStatementTestWithoutBonuses()
        {
            IView view = new HtmlView();
            var SomeBill = new Bill(new Customer("Test", 0), view);
            var expected = "<style>.field{width: 100px; float: left;}</style><p>���� ��� Test</p><div class='field'>��������</div><div class='field'>����</div><div class='field'>���-��</div><div class='field'>���������</div><div class='field'>������</div><div class='field'>�����</div><div class='field'>�����</div><br><style>.field{width: 100px; float: left;}</style><div class='field'>Cola</div><div class='field'>65</div><div class='field'>6</div><div class='field'>390</div><div class='field'>11,7</div><div class='field'>378,3</div><div class='field'>19</div><br><style>.field{width: 100px; float: left;}</style><div class='field'>Pepsi</div><div class='field'>50</div><div class='field'>3</div><div class='field'>150</div><div class='field'>0</div><div class='field'>150</div><div class='field'>1</div><br><style>.field{width: 100px; float: left;}</style><div class='field'>Fanta</div><div class='field'>35</div><div class='field'>1</div><div class='field'>35</div><div class='field'>0</div><div class='field'>35</div><div class='field'>0</div><br><p>����� ����� ���������� 563,3</p><p>�� ���������� 20 �������� ������</p>";
            SomeBill.addGoods(new Item(new REG("Cola"), 6, 65));
            SomeBill.addGoods(new Item(new SAL("Pepsi"), 3, 50));
            SomeBill.addGoods(new Item(new SPO("Fanta"), 1, 35));
            var actual = SomeBill.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HTML_TestWithBonusesForREG()
        {
            IView view = new HtmlView();
            var SomeBill = new Bill(new Customer("Test", 10), view);
            var expected = "<style>.field{width: 100px; float: left;}</style><p>���� ��� Test</p><div class='field'>��������</div><div class='field'>����</div><div class='field'>���-��</div><div class='field'>���������</div><div class='field'>������</div><div class='field'>�����</div><div class='field'>�����</div><br><style>.field{width: 100px; float: left;}</style><div class='field'>Cola</div><div class='field'>65</div><div class='field'>6</div><div class='field'>390</div><div class='field'>11,7</div><div class='field'>368,3</div><div class='field'>19</div><br><p>����� ����� ���������� 368,3</p><p>�� ���������� 19 �������� ������</p>";
            SomeBill.addGoods(new Item(new REG("Cola"), 6, 65));
            var actual = SomeBill.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HTML_TestWithoutBonusesForREG()
        {
            IView view = new HtmlView();
            var SomeBill = new Bill(new Customer("Test", 0), view);
            var expected = "<style>.field{width: 100px; float: left;}</style><p>���� ��� Test</p><div class='field'>��������</div><div class='field'>����</div><div class='field'>���-��</div><div class='field'>���������</div><div class='field'>������</div><div class='field'>�����</div><div class='field'>�����</div><br><style>.field{width: 100px; float: left;}</style><div class='field'>Cola</div><div class='field'>65</div><div class='field'>6</div><div class='field'>390</div><div class='field'>11,7</div><div class='field'>378,3</div><div class='field'>19</div><br><p>����� ����� ���������� 378,3</p><p>�� ���������� 19 �������� ������</p>";
            SomeBill.addGoods(new Item(new REG("Cola"), 6, 65));
            var actual = SomeBill.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HTML_TestWithBonusesForSAL()
        {
            IView view = new HtmlView();
            var SomeBill = new Bill(new Customer("Test", 10), view);
            var expected = "<style>.field{width: 100px; float: left;}</style><p>���� ��� Test</p><div class='field'>��������</div><div class='field'>����</div><div class='field'>���-��</div><div class='field'>���������</div><div class='field'>������</div><div class='field'>�����</div><div class='field'>�����</div><br><style>.field{width: 100px; float: left;}</style><div class='field'>Pepsi</div><div class='field'>50</div><div class='field'>3</div><div class='field'>150</div><div class='field'>0</div><div class='field'>150</div><div class='field'>1</div><br><p>����� ����� ���������� 150</p><p>�� ���������� 1 �������� ������</p>";
            SomeBill.addGoods(new Item(new SAL("Pepsi"), 3, 50));
            var actual = SomeBill.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HTML_TestWithoutBonusesForSAL()
        {
            IView view = new HtmlView();
            var SomeBill = new Bill(new Customer("Test", 0), view);
            var expected = "<style>.field{width: 100px; float: left;}</style><p>���� ��� Test</p><div class='field'>��������</div><div class='field'>����</div><div class='field'>���-��</div><div class='field'>���������</div><div class='field'>������</div><div class='field'>�����</div><div class='field'>�����</div><br><style>.field{width: 100px; float: left;}</style><div class='field'>Pepsi</div><div class='field'>50</div><div class='field'>3</div><div class='field'>150</div><div class='field'>0</div><div class='field'>150</div><div class='field'>1</div><br><p>����� ����� ���������� 150</p><p>�� ���������� 1 �������� ������</p>";
            SomeBill.addGoods(new Item(new SAL("Pepsi"), 3, 50));
            var actual = SomeBill.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HTML_TestWithBonusesForSPO()
        {
            IView view = new HtmlView();
            var SomeBill = new Bill(new Customer("Test", 10), view);
            var expected = "<style>.field{width: 100px; float: left;}</style><p>���� ��� Test</p><div class='field'>��������</div><div class='field'>����</div><div class='field'>���-��</div><div class='field'>���������</div><div class='field'>������</div><div class='field'>�����</div><div class='field'>�����</div><br><style>.field{width: 100px; float: left;}</style><div class='field'>Fanta</div><div class='field'>35</div><div class='field'>1</div><div class='field'>35</div><div class='field'>0</div><div class='field'>35</div><div class='field'>0</div><br><p>����� ����� ���������� 35</p><p>�� ���������� 0 �������� ������</p>";
            SomeBill.addGoods(new Item(new SPO("Fanta"), 1, 35));
            var actual = SomeBill.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HTML_TestWithoutBonusesForSPO()
        {
            IView view = new HtmlView();
            var SomeBill = new Bill(new Customer("Test", 0), view);
            var expected = "<style>.field{width: 100px; float: left;}</style><p>���� ��� Test</p><div class='field'>��������</div><div class='field'>����</div><div class='field'>���-��</div><div class='field'>���������</div><div class='field'>������</div><div class='field'>�����</div><div class='field'>�����</div><br><style>.field{width: 100px; float: left;}</style><div class='field'>Fanta</div><div class='field'>35</div><div class='field'>1</div><div class='field'>35</div><div class='field'>0</div><div class='field'>35</div><div class='field'>0</div><br><p>����� ����� ���������� 35</p><p>�� ���������� 0 �������� ������</p>";
            SomeBill.addGoods(new Item(new SPO("Fanta"), 1, 35));
            var actual = SomeBill.GetBill();
            Assert.AreEqual(expected, actual);
        }

    }
}