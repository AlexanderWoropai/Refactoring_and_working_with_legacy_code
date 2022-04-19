using NUnit.Framework;
using RLCLab;
using static RLCLab.Program;
using System;
using System.IO;
using Newtonsoft.Json;

namespace TestsForProgramm
{
    public class Tests
    {
        [Test]
        public void TXT_EmptyBillStatementTestWithBonuses()
        {
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 10));
            var BillGenerator = new BillGenerator(view, SomeBill);
            var expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n����� ����� ���������� 0\n�� ���������� 0 �������� �����";
            var actual = BillGenerator.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TXT_EmptyBillStatementTestWithoutBonuses()
        {
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 0));
            var BillGenerator = new BillGenerator(view, SomeBill);
            var expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n����� ����� ���������� 0\n�� ���������� 0 �������� �����";
            var actual = BillGenerator.GetBill();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TXT_UsualBillStatementTestWithBonuses()
        {
            GoodsFactory goodsFactory = new GoodsFactory(someconfigs);
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 10));
            var BillGenerator = new BillGenerator(view, SomeBill);
            var expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tCola\t\t65\t6\t390\t11,7\t368,3\t19\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n\tFanta\t\t35\t1\t35\t0\t35\t0\n����� ����� ���������� 553,3\n�� ���������� 20 �������� �����";
            SomeBill.addGoods(new Item(goodsFactory.Create("REG", "Cola"), 6, 65));
            SomeBill.addGoods(new Item(goodsFactory.Create("SAL", "Pepsi"), 3, 50));
            SomeBill.addGoods(new Item(goodsFactory.Create("SPO", "Fanta"), 1, 35));
            var actual = BillGenerator.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TXT_UsualBillStatementTestWithoutBonuses()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 0));
            var BillGenerator = new BillGenerator(view, SomeBill);
            var expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tCola\t\t65\t6\t390\t11,7\t378,3\t19\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n\tFanta\t\t35\t1\t35\t0\t35\t0\n����� ����� ���������� 563,3\n�� ���������� 20 �������� �����";
            SomeBill.addGoods(new Item(goodsFactory.Create("REG", "Cola"), 6, 65));
            SomeBill.addGoods(new Item(goodsFactory.Create("SAL", "Pepsi"), 3, 50));
            SomeBill.addGoods(new Item(goodsFactory.Create("SPO", "Fanta"), 1, 35));
            var actual = BillGenerator.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TXT_StatementTestWithBonusesForREG()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 10));
            var BillGenerator = new BillGenerator(view, SomeBill);
            var expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tCola\t\t65\t6\t390\t11,7\t368,3\t19\n����� ����� ���������� 368,3\n�� ���������� 19 �������� �����";
            SomeBill.addGoods(new Item(goodsFactory.Create("REG", "Cola"), 6, 65));
            var actual = BillGenerator.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TXT_StatementTestWithoutBonusesForREG()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 0));
            var BillGenerator = new BillGenerator(view, SomeBill);
            var expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tCola\t\t65\t6\t390\t11,7\t378,3\t19\n����� ����� ���������� 378,3\n�� ���������� 19 �������� �����";
            SomeBill.addGoods(new Item(goodsFactory.Create("REG", "Cola"), 6, 65));
            var actual = BillGenerator.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TXT_StatementTestWithBonusesForSAL()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 10));
            var BillGenerator = new BillGenerator(view, SomeBill);
            var expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n����� ����� ���������� 150\n�� ���������� 1 �������� �����";
            SomeBill.addGoods(new Item(goodsFactory.Create("SAL", "Pepsi"), 3, 50));
            var actual = BillGenerator.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TXT_StatementTestWithoutBonusesForSAL()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 0));
            var BillGenerator = new BillGenerator(view, SomeBill);
            var expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n����� ����� ���������� 150\n�� ���������� 1 �������� �����";
            SomeBill.addGoods(new Item(goodsFactory.Create("SAL", "Pepsi"), 3, 50));
            var actual = BillGenerator.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TXT_StatementTestWithBonusesForSPO()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 10));
            var BillGenerator = new BillGenerator(view, SomeBill);
            var expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tFanta\t\t35\t1\t35\t0\t35\t0\n����� ����� ���������� 35\n�� ���������� 0 �������� �����";
            SomeBill.addGoods(new Item(goodsFactory.Create("SPO", "Fanta"), 1, 35));
            var actual = BillGenerator.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TXT_StatementTestWithoutBonusesForSPO()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            IView view = new TxtView();
            var SomeBill = new Bill(new Customer("Test", 0));
            var BillGenerator = new BillGenerator(view, SomeBill);
            var expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tFanta\t\t35\t1\t35\t0\t35\t0\n����� ����� ���������� 35\n�� ���������� 0 �������� �����";
            SomeBill.addGoods(new Item(goodsFactory.Create("SPO", "Fanta"), 1, 35));
            var actual = BillGenerator.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HTML_EmptyBillStatementTestWithBonuses()
        {
            IView view = new HtmlView();
            var SomeBill = new Bill(new Customer("Test", 10));
            var BillGenerator = new BillGenerator(view, SomeBill);
            var expected = "<style>.field{width: 100px; float: left;}</style><p>���� ��� Test</p><div class='field'>��������</div><div class='field'>����</div><div class='field'>���-��</div><div class='field'>���������</div><div class='field'>������</div><div class='field'>�����</div><div class='field'>�����</div><br><p>����� ����� ���������� 0</p><p>�� ���������� 0 �������� ������</p>";
            var actual = BillGenerator.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HTML_EmptyBillStatementTestWithoutBonuses()
        {
            IView view = new HtmlView();
            var SomeBill = new Bill(new Customer("Test", 0));
            var BillGenerator = new BillGenerator(view, SomeBill);
            var expected = "<style>.field{width: 100px; float: left;}</style><p>���� ��� Test</p><div class='field'>��������</div><div class='field'>����</div><div class='field'>���-��</div><div class='field'>���������</div><div class='field'>������</div><div class='field'>�����</div><div class='field'>�����</div><br><p>����� ����� ���������� 0</p><p>�� ���������� 0 �������� ������</p>";
            var actual = BillGenerator.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HTML_UsualBillStatementTestWithBonuses()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            IView view = new HtmlView();
            var SomeBill = new Bill(new Customer("Test", 10));
            var BillGenerator = new BillGenerator(view, SomeBill);
            var expected = "<style>.field{width: 100px; float: left;}</style><p>���� ��� Test</p><div class='field'>��������</div><div class='field'>����</div><div class='field'>���-��</div><div class='field'>���������</div><div class='field'>������</div><div class='field'>�����</div><div class='field'>�����</div><br><style>.field{width: 100px; float: left;}</style><div class='field'>Cola</div><div class='field'>65</div><div class='field'>6</div><div class='field'>390</div><div class='field'>11,7</div><div class='field'>368,3</div><div class='field'>19</div><br><style>.field{width: 100px; float: left;}</style><div class='field'>Pepsi</div><div class='field'>50</div><div class='field'>3</div><div class='field'>150</div><div class='field'>0</div><div class='field'>150</div><div class='field'>1</div><br><style>.field{width: 100px; float: left;}</style><div class='field'>Fanta</div><div class='field'>35</div><div class='field'>1</div><div class='field'>35</div><div class='field'>0</div><div class='field'>35</div><div class='field'>0</div><br><p>����� ����� ���������� 553,3</p><p>�� ���������� 20 �������� ������</p>";
            SomeBill.addGoods(new Item(goodsFactory.Create("REG", "Cola"), 6, 65));
            SomeBill.addGoods(new Item(goodsFactory.Create("SAL", "Pepsi"), 3, 50));
            SomeBill.addGoods(new Item(goodsFactory.Create("SPO", "Fanta"), 1, 35));
            var actual = BillGenerator.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HTML_UsualBillStatementTestWithoutBonuses()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            IView view = new HtmlView();
            var SomeBill = new Bill(new Customer("Test", 0));
            var BillGenerator = new BillGenerator(view, SomeBill);
            var expected = "<style>.field{width: 100px; float: left;}</style><p>���� ��� Test</p><div class='field'>��������</div><div class='field'>����</div><div class='field'>���-��</div><div class='field'>���������</div><div class='field'>������</div><div class='field'>�����</div><div class='field'>�����</div><br><style>.field{width: 100px; float: left;}</style><div class='field'>Cola</div><div class='field'>65</div><div class='field'>6</div><div class='field'>390</div><div class='field'>11,7</div><div class='field'>378,3</div><div class='field'>19</div><br><style>.field{width: 100px; float: left;}</style><div class='field'>Pepsi</div><div class='field'>50</div><div class='field'>3</div><div class='field'>150</div><div class='field'>0</div><div class='field'>150</div><div class='field'>1</div><br><style>.field{width: 100px; float: left;}</style><div class='field'>Fanta</div><div class='field'>35</div><div class='field'>1</div><div class='field'>35</div><div class='field'>0</div><div class='field'>35</div><div class='field'>0</div><br><p>����� ����� ���������� 563,3</p><p>�� ���������� 20 �������� ������</p>";
            SomeBill.addGoods(new Item(goodsFactory.Create("REG", "Cola"), 6, 65));
            SomeBill.addGoods(new Item(goodsFactory.Create("SAL", "Pepsi"), 3, 50));
            SomeBill.addGoods(new Item(goodsFactory.Create("SPO", "Fanta"), 1, 35));
            var actual = BillGenerator.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HTML_StatementTestWithBonusesForREG()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            IView view = new HtmlView();
            var SomeBill = new Bill(new Customer("Test", 10));
            var BillGenerator = new BillGenerator(view, SomeBill);
            var expected = "<style>.field{width: 100px; float: left;}</style><p>���� ��� Test</p><div class='field'>��������</div><div class='field'>����</div><div class='field'>���-��</div><div class='field'>���������</div><div class='field'>������</div><div class='field'>�����</div><div class='field'>�����</div><br><style>.field{width: 100px; float: left;}</style><div class='field'>Cola</div><div class='field'>65</div><div class='field'>6</div><div class='field'>390</div><div class='field'>11,7</div><div class='field'>368,3</div><div class='field'>19</div><br><p>����� ����� ���������� 368,3</p><p>�� ���������� 19 �������� ������</p>";
            SomeBill.addGoods(new Item(goodsFactory.Create("REG", "Cola"), 6, 65));
            var actual = BillGenerator.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HTML_StatementTestWithoutBonusesForREG()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            IView view = new HtmlView();
            var SomeBill = new Bill(new Customer("Test", 0));
            var BillGenerator = new BillGenerator(view, SomeBill);
            var expected = "<style>.field{width: 100px; float: left;}</style><p>���� ��� Test</p><div class='field'>��������</div><div class='field'>����</div><div class='field'>���-��</div><div class='field'>���������</div><div class='field'>������</div><div class='field'>�����</div><div class='field'>�����</div><br><style>.field{width: 100px; float: left;}</style><div class='field'>Cola</div><div class='field'>65</div><div class='field'>6</div><div class='field'>390</div><div class='field'>11,7</div><div class='field'>378,3</div><div class='field'>19</div><br><p>����� ����� ���������� 378,3</p><p>�� ���������� 19 �������� ������</p>";
            SomeBill.addGoods(new Item(goodsFactory.Create("REG", "Cola"), 6, 65));
            var actual = BillGenerator.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HTML_StatementTestWithBonusesForSAL()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            IView view = new HtmlView();
            var SomeBill = new Bill(new Customer("Test", 10));
            var BillGenerator = new BillGenerator(view, SomeBill);
            var expected = "<style>.field{width: 100px; float: left;}</style><p>���� ��� Test</p><div class='field'>��������</div><div class='field'>����</div><div class='field'>���-��</div><div class='field'>���������</div><div class='field'>������</div><div class='field'>�����</div><div class='field'>�����</div><br><style>.field{width: 100px; float: left;}</style><div class='field'>Pepsi</div><div class='field'>50</div><div class='field'>3</div><div class='field'>150</div><div class='field'>0</div><div class='field'>150</div><div class='field'>1</div><br><p>����� ����� ���������� 150</p><p>�� ���������� 1 �������� ������</p>";
            SomeBill.addGoods(new Item(goodsFactory.Create("SAL", "Pepsi"), 3, 50));
            var actual = BillGenerator.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HTML_StatementTestWithoutBonusesForSAL()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            IView view = new HtmlView();
            var SomeBill = new Bill(new Customer("Test", 0));
            var BillGenerator = new BillGenerator(view, SomeBill);
            var expected = "<style>.field{width: 100px; float: left;}</style><p>���� ��� Test</p><div class='field'>��������</div><div class='field'>����</div><div class='field'>���-��</div><div class='field'>���������</div><div class='field'>������</div><div class='field'>�����</div><div class='field'>�����</div><br><style>.field{width: 100px; float: left;}</style><div class='field'>Pepsi</div><div class='field'>50</div><div class='field'>3</div><div class='field'>150</div><div class='field'>0</div><div class='field'>150</div><div class='field'>1</div><br><p>����� ����� ���������� 150</p><p>�� ���������� 1 �������� ������</p>";
            SomeBill.addGoods(new Item(goodsFactory.Create("SAL", "Pepsi"), 3, 50));
            var actual = BillGenerator.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HTML_StatementTestWithBonusesForSPO()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            IView view = new HtmlView();
            var SomeBill = new Bill(new Customer("Test", 10));
            var BillGenerator = new BillGenerator(view, SomeBill);
            var expected = "<style>.field{width: 100px; float: left;}</style><p>���� ��� Test</p><div class='field'>��������</div><div class='field'>����</div><div class='field'>���-��</div><div class='field'>���������</div><div class='field'>������</div><div class='field'>�����</div><div class='field'>�����</div><br><style>.field{width: 100px; float: left;}</style><div class='field'>Fanta</div><div class='field'>35</div><div class='field'>1</div><div class='field'>35</div><div class='field'>0</div><div class='field'>35</div><div class='field'>0</div><br><p>����� ����� ���������� 35</p><p>�� ���������� 0 �������� ������</p>";
            SomeBill.addGoods(new Item(goodsFactory.Create("SPO", "Fanta"), 1, 35));
            var actual = BillGenerator.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void HTML_StatementTestWithoutBonusesForSPO()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            IView view = new HtmlView();
            var SomeBill = new Bill(new Customer("Test", 0));
            var BillGenerator = new BillGenerator(view, SomeBill);
            var expected = "<style>.field{width: 100px; float: left;}</style><p>���� ��� Test</p><div class='field'>��������</div><div class='field'>����</div><div class='field'>���-��</div><div class='field'>���������</div><div class='field'>������</div><div class='field'>�����</div><div class='field'>�����</div><br><style>.field{width: 100px; float: left;}</style><div class='field'>Fanta</div><div class='field'>35</div><div class='field'>1</div><div class='field'>35</div><div class='field'>0</div><div class='field'>35</div><div class='field'>0</div><br><p>����� ����� ���������� 35</p><p>�� ���������� 0 �������� ������</p>";
            SomeBill.addGoods(new Item(goodsFactory.Create("SPO", "Fanta"), 1, 35));
            var actual = BillGenerator.GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void YAMLSource_EmptyBillReaderTestWithBonuses()
        {
            FileSourceFactory filesourceFactory = new FileSourceFactory();
            IView view = new TxtView();
            IFileSource filesource = filesourceFactory.Create("YAML");
            BillFactory factory = new BillFactory(filesource);
            var billforexpected = new Bill(new Customer("Test", 10));
            var billforactual = factory.CreateBill(new StringReader(String.Format(
                "CustomerName: Test" + "\n" +
                "CustomerBonus: 10" + "\n" +
                "GoodsTotalCount: 0" + "\n" +
                "# ID: NAME TYPE(REG/SAL/SPO)" + "\n" +
                "ItemsTotalCount: 0" + "\n" +
                "# ID: GID PRICE QTY")));
            var expected = new BillGenerator(view, billforexpected).GetBill();
            var actual = new BillGenerator(view, billforactual).GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void YAMLSource_EmptyBillReaderTestWithoutBonuses()
        {
            FileSourceFactory filesourceFactory = new FileSourceFactory();
            IView view = new TxtView();
            IFileSource filesource = filesourceFactory.Create("YAML");
            BillFactory factory = new BillFactory(filesource);
            var billforexpected = new Bill(new Customer("Test", 0));
            var billforactual = factory.CreateBill(new StringReader(String.Format(
                "CustomerName: Test" + "\n" +
                "CustomerBonus: 0" + "\n" +
                "GoodsTotalCount: 0" + "\n" +
                "# ID: NAME TYPE(REG/SAL/SPO)" + "\n" +
                "ItemsTotalCount: 0" + "\n" +
                "# ID: GID PRICE QTY")));
            var expected = new BillGenerator(view, billforexpected).GetBill();
            var actual = new BillGenerator(view, billforactual).GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void YAMLSource_UsualBillReaderTestWithBonuses()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            FileSourceFactory filesourceFactory = new FileSourceFactory();
            IView view = new TxtView();
            IFileSource filesource = filesourceFactory.Create("YAML");
            BillFactory factory = new BillFactory(filesource);
            var billforexpected = new Bill(new Customer("Test", 10));
            billforexpected.addGoods(new Item(goodsFactory.Create("REG", "Cola"), 6, 65));
            billforexpected.addGoods(new Item(goodsFactory.Create("SAL", "Pepsi"), 3, 50));
            billforexpected.addGoods(new Item(goodsFactory.Create("SPO", "Fanta"), 1, 35));
            var billforactual = factory.CreateBill(new StringReader(String.Format(
                "CustomerName: Test" + "\n" +
                "CustomerBonus: 10" + "\n" +
                "GoodsTotalCount: 3 " + "\n" +
                "# ID: NAME TYPE(REG/SAL/SPO)" + "\n" +
                "1: Cola REG" + "\n" +
                "2: Pepsi SAL" + "\n" +
                "3: Fanta SPO" + "\n" +
                "ItemsTotalCount: 3" + "\n" +
                "# ID: GID PRICE QTY" + "\n" +
                "1: 1 65 6" + "\n" +
                "2: 2 50 3" + "\n" +
                "3: 3 35 1")));
            var expected = new BillGenerator(view, billforexpected).GetBill();
            var actual = new BillGenerator(view, billforactual).GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void YAMLSource_UsualBillReaderTestWithoutBonuses()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            FileSourceFactory filesourceFactory = new FileSourceFactory();
            IView view = new TxtView();
            IFileSource filesource = filesourceFactory.Create("YAML");
            BillFactory factory = new BillFactory(filesource);
            var billforexpected = new Bill(new Customer("Test", 0));
            billforexpected.addGoods(new Item(goodsFactory.Create("REG", "Cola"), 6, 65));
            billforexpected.addGoods(new Item(goodsFactory.Create("SAL", "Pepsi"), 3, 50));
            billforexpected.addGoods(new Item(goodsFactory.Create("SPO", "Fanta"), 1, 35));
            var billforactual = factory.CreateBill(new StringReader(String.Format(
                "CustomerName: Test" + "\n" +
                "CustomerBonus: 0" + "\n" +
                "GoodsTotalCount: 3 " + "\n" +
                "# ID: NAME TYPE(REG/SAL/SPO)" + "\n" +
                "1: Cola REG" + "\n" +
                "2: Pepsi SAL" + "\n" +
                "3: Fanta SPO" + "\n" +
                "ItemsTotalCount: 3" + "\n" +
                "# ID: GID PRICE QTY" + "\n" +
                "1: 1 65 6" + "\n" +
                "2: 2 50 3" + "\n" +
                "3: 3 35 1")));
            var expected = new BillGenerator(view, billforexpected).GetBill();
            var actual = new BillGenerator(view, billforactual).GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void YAMLSource_ReaderTestWithBonusesForREG()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            FileSourceFactory filesourceFactory = new FileSourceFactory();
            IView view = new TxtView();
            IFileSource filesource = filesourceFactory.Create("YAML");
            BillFactory factory = new BillFactory(filesource);
            var billforexpected = new Bill(new Customer("Test", 10));
            billforexpected.addGoods(new Item(goodsFactory.Create("REG", "Cola"), 6, 65));
            var billforactual = factory.CreateBill(new StringReader(String.Format(
                "CustomerName: Test" + "\n" +
                "CustomerBonus: 10" + "\n" +
                "GoodsTotalCount: 1 " + "\n" +
                "# ID: NAME TYPE(REG/SAL/SPO)" + "\n" +
                "1: Cola REG" + "\n" +
                "ItemsTotalCount: 1" + "\n" +
                "# ID: GID PRICE QTY" + "\n" +
                "1: 1 65 6")));
            var expected = new BillGenerator(view, billforexpected).GetBill();
            var actual = new BillGenerator(view, billforactual).GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void YAMLSource_ReaderTestWithoutBonusesForREG()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            FileSourceFactory filesourceFactory = new FileSourceFactory();
            IView view = new TxtView();
            IFileSource filesource = filesourceFactory.Create("YAML");
            BillFactory factory = new BillFactory(filesource);
            var billforexpected = new Bill(new Customer("Test", 0));
            billforexpected.addGoods(new Item(goodsFactory.Create("REG", "Cola"), 6, 65));
            var billforactual = factory.CreateBill(new StringReader(String.Format(
                "CustomerName: Test" + "\n" +
                "CustomerBonus: 0" + "\n" +
                "GoodsTotalCount: 1 " + "\n" +
                "# ID: NAME TYPE(REG/SAL/SPO)" + "\n" +
                "1: Cola REG" + "\n" +
                "ItemsTotalCount: 1" + "\n" +
                "# ID: GID PRICE QTY" + "\n" +
                "1: 1 65 6")));
            var expected = new BillGenerator(view, billforexpected).GetBill();
            var actual = new BillGenerator(view, billforactual).GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void YAMLSource_ReaderTestWithBonusesForSAL() 
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            FileSourceFactory filesourceFactory = new FileSourceFactory();
            IView view = new TxtView();
            IFileSource filesource = filesourceFactory.Create("YAML");
            BillFactory factory = new BillFactory(filesource);
            var billforexpected = new Bill(new Customer("Test", 10));
            billforexpected.addGoods(new Item(goodsFactory.Create("SAL", "Pepsi"), 3, 50));
            var billforactual = factory.CreateBill(new StringReader(String.Format(
                "CustomerName: Test" + "\n" +
                "CustomerBonus: 10" + "\n" +
                "GoodsTotalCount: 1 " + "\n" +
                "# ID: NAME TYPE(REG/SAL/SPO)" + "\n" +
                "1: Pepsi SAL" + "\n" +
                "ItemsTotalCount: 1" + "\n" +
                "# ID: GID PRICE QTY" + "\n" +
                "1: 1 50 3")));
            var expected = new BillGenerator(view, billforexpected).GetBill();
            var actual = new BillGenerator(view, billforactual).GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void YAMLSource_ReaderTestWithoutBonusesForSAL()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            FileSourceFactory filesourceFactory = new FileSourceFactory();
            IView view = new TxtView();
            IFileSource filesource = filesourceFactory.Create("YAML");
            BillFactory factory = new BillFactory(filesource);
            var billforexpected = new Bill(new Customer("Test", 0));
            billforexpected.addGoods(new Item(goodsFactory.Create("SAL", "Pepsi"), 3, 50));
            var billforactual = factory.CreateBill(new StringReader(String.Format(
                "CustomerName: Test" + "\n" +
                "CustomerBonus: 0" + "\n" +
                "GoodsTotalCount: 1 " + "\n" +
                "# ID: NAME TYPE(REG/SAL/SPO)" + "\n" +
                "1: Pepsi SAL" + "\n" +
                "ItemsTotalCount: 1" + "\n" +
                "# ID: GID PRICE QTY" + "\n" +
                "1: 1 50 3")));
            var expected = new BillGenerator(view, billforexpected).GetBill();
            var actual = new BillGenerator(view, billforactual).GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void YAMLSource_ReaderTestWithBonusesForSPO() 
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            FileSourceFactory filesourceFactory = new FileSourceFactory();
            IView view = new TxtView();
            IFileSource filesource = filesourceFactory.Create("YAML");
            BillFactory factory = new BillFactory(filesource);
            var billforexpected = new Bill(new Customer("Test", 10));
            billforexpected.addGoods(new Item(goodsFactory.Create("SPO", "Fanta"), 1, 35));
            var billforactual = factory.CreateBill(new StringReader(String.Format(
                "CustomerName: Test" + "\n" +
                "CustomerBonus: 10" + "\n" +
                "GoodsTotalCount: 1 " + "\n" +
                "# ID: NAME TYPE(REG/SAL/SPO)" + "\n" +
                "1: Fanta SPO" + "\n" +
                "ItemsTotalCount: 1" + "\n" +
                "# ID: GID PRICE QTY" + "\n" +
                "1: 1 35 1")));
            var expected = new BillGenerator(view, billforexpected).GetBill();
            var actual = new BillGenerator(view, billforactual).GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void YAMLSource_ReaderTestWithoutBonusesForSPO()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            FileSourceFactory filesourceFactory = new FileSourceFactory();
            IView view = new TxtView();
            IFileSource filesource = filesourceFactory.Create("YAML");
            BillFactory factory = new BillFactory(filesource);
            var billforexpected = new Bill(new Customer("Test", 0));
            billforexpected.addGoods(new Item(goodsFactory.Create("SPO", "Fanta"), 1, 35));
            var billforactual = factory.CreateBill(new StringReader(String.Format(
                "CustomerName: Test" + "\n" +
                "CustomerBonus: 0" + "\n" +
                "GoodsTotalCount: 1 " + "\n" +
                "# ID: NAME TYPE(REG/SAL/SPO)" + "\n" +
                "1: Fanta SPO" + "\n" +
                "ItemsTotalCount: 1" + "\n" +
                "# ID: GID PRICE QTY" + "\n" +
                "1: 1 35 1")));
            var expected = new BillGenerator(view, billforexpected).GetBill();
            var actual = new BillGenerator(view, billforactual).GetBill();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// ///////
        /// </summary>

        [Test]
        public void TXTSource_EmptyBillReaderTestWithBonuses()
        {
            FileSourceFactory filesourceFactory = new FileSourceFactory();
            IView view = new TxtView();
            IFileSource filesource = filesourceFactory.Create("TXT");
            BillFactory factory = new BillFactory(filesource);
            var billforexpected = new Bill(new Customer("Test", 10));
            var billforactual = factory.CreateBill(new StringReader(String.Format(
                "���������������: Test" + "\n" +
                "������������������: 10" + "\n" +
                "����������������������: 0" + "\n" +
                "// ����: ��� ���(REG/SAL/SPO)" + "\n" +
                "������������������������: 0" + "\n" +
                "// ����: ��� ���� ����������")));
            var expected = new BillGenerator(view, billforexpected).GetBill();
            var actual = new BillGenerator(view, billforactual).GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TXTSource_EmptyBillReaderTestWithoutBonuses()
        {
            FileSourceFactory filesourceFactory = new FileSourceFactory();
            IView view = new TxtView();
            IFileSource filesource = filesourceFactory.Create("TXT");
            BillFactory factory = new BillFactory(filesource);
            var billforexpected = new Bill(new Customer("Test", 0));
            var billforactual = factory.CreateBill(new StringReader(String.Format(
                "���������������: Test" + "\n" +
                "������������������: 0" + "\n" +
                "����������������������: 0" + "\n" +
                "// ����: ��� ���(REG/SAL/SPO)" + "\n" +
                "������������������������: 0" + "\n" +
                "// ����: ��� ���� ����������")));
            var expected = new BillGenerator(view, billforexpected).GetBill();
            var actual = new BillGenerator(view, billforactual).GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TXTSource_UsualBillReaderTestWithBonuses()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            FileSourceFactory filesourceFactory = new FileSourceFactory();
            IView view = new TxtView();
            IFileSource filesource = filesourceFactory.Create("TXT");
            BillFactory factory = new BillFactory(filesource);
            var billforexpected = new Bill(new Customer("Test", 10));
            billforexpected.addGoods(new Item(goodsFactory.Create("REG", "Cola"), 6, 65));
            billforexpected.addGoods(new Item(goodsFactory.Create("SAL", "Pepsi"), 3, 50));
            billforexpected.addGoods(new Item(goodsFactory.Create("SPO", "Fanta"), 1, 35));
            var billforactual = factory.CreateBill(new StringReader(String.Format(
                "���������������: Test" + "\n" +
                "������������������: 10" + "\n" +
                "����������������������: 3 " + "\n" +
                "// ����: ��� ���(REG/SAL/SPO)" + "\n" +
                "1: Cola REG" + "\n" +
                "2: Pepsi SAL" + "\n" +
                "3: Fanta SPO" + "\n" +
                "������������������������: 3" + "\n" +
                "// ����: ��� ���� ����������" + "\n" +
                "1: 1 65 6" + "\n" +
                "2: 2 50 3" + "\n" +
                "3: 3 35 1")));
            var expected = new BillGenerator(view, billforexpected).GetBill();
            var actual = new BillGenerator(view, billforactual).GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TXTSource_UsualBillReaderTestWithoutBonuses()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            FileSourceFactory filesourceFactory = new FileSourceFactory();
            IView view = new TxtView();
            IFileSource filesource = filesourceFactory.Create("TXT");
            BillFactory factory = new BillFactory(filesource);
            var billforexpected = new Bill(new Customer("Test", 0));
            billforexpected.addGoods(new Item(goodsFactory.Create("REG", "Cola"), 6, 65));
            billforexpected.addGoods(new Item(goodsFactory.Create("SAL", "Pepsi"), 3, 50));
            billforexpected.addGoods(new Item(goodsFactory.Create("SPO", "Fanta"), 1, 35));
            var billforactual = factory.CreateBill(new StringReader(String.Format(
                "���������������: Test" + "\n" +
                "������������������: 0" + "\n" +
                "����������������������: 3 " + "\n" +
                "// ����: ��� ���(REG/SAL/SPO)" + "\n" +
                "1: Cola REG" + "\n" +
                "2: Pepsi SAL" + "\n" +
                "3: Fanta SPO" + "\n" +
                "������������������������: 3" + "\n" +
                "// ����: ��� ���� ����������" + "\n" +
                "1: 1 65 6" + "\n" +
                "2: 2 50 3" + "\n" +
                "3: 3 35 1")));
            var expected = new BillGenerator(view, billforexpected).GetBill();
            var actual = new BillGenerator(view, billforactual).GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TXTSource_ReaderTestWithBonusesForREG()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            FileSourceFactory filesourceFactory = new FileSourceFactory();
            IView view = new TxtView();
            IFileSource filesource = filesourceFactory.Create("TXT");
            BillFactory factory = new BillFactory(filesource);
            var billforexpected = new Bill(new Customer("Test", 10));
            billforexpected.addGoods(new Item(goodsFactory.Create("REG", "Cola"), 6, 65));
            var billforactual = factory.CreateBill(new StringReader(String.Format(
                "���������������: Test" + "\n" +
                "������������������: 10" + "\n" +
                "����������������������: 1 " + "\n" +
                "// ����: ��� ���(REG/SAL/SPO)" + "\n" +
                "1: Cola REG" + "\n" +
                "������������������������: 1" + "\n" +
                "// ����: ��� ���� ����������" + "\n" +
                "1: 1 65 6")));
            var expected = new BillGenerator(view, billforexpected).GetBill();
            var actual = new BillGenerator(view, billforactual).GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TXTSource_ReaderTestWithoutBonusesForREG()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            FileSourceFactory filesourceFactory = new FileSourceFactory();
            IView view = new TxtView();
            IFileSource filesource = filesourceFactory.Create("TXT");
            BillFactory factory = new BillFactory(filesource);
            var billforexpected = new Bill(new Customer("Test", 0));
            billforexpected.addGoods(new Item(goodsFactory.Create("REG", "Cola"), 6, 65));
            var billforactual = factory.CreateBill(new StringReader(String.Format(
                "���������������: Test" + "\n" +
                "������������������: 0" + "\n" +
                "����������������������: 1 " + "\n" +
                "// ����: ��� ���(REG/SAL/SPO)" + "\n" +
                "1: Cola REG" + "\n" +
                "������������������������: 1" + "\n" +
                "// ����: ��� ���� ����������" + "\n" +
                "1: 1 65 6")));
            var expected = new BillGenerator(view, billforexpected).GetBill();
            var actual = new BillGenerator(view, billforactual).GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TXTSource_ReaderTestWithBonusesForSAL()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            FileSourceFactory filesourceFactory = new FileSourceFactory();
            IView view = new TxtView();
            IFileSource filesource = filesourceFactory.Create("TXT");
            BillFactory factory = new BillFactory(filesource);
            var billforexpected = new Bill(new Customer("Test", 10));
            billforexpected.addGoods(new Item(goodsFactory.Create("SAL", "Pepsi"), 3, 50));
            var billforactual = factory.CreateBill(new StringReader(String.Format(
                "���������������: Test" + "\n" +
                "������������������: 10" + "\n" +
                "����������������������: 1 " + "\n" +
                "// ����: ��� ���(REG/SAL/SPO)" + "\n" +
                "1: Pepsi SAL" + "\n" +
                "������������������������: 1" + "\n" +
                "// ����: ��� ���� ����������" + "\n" +
                "1: 1 50 3")));
            var expected = new BillGenerator(view, billforexpected).GetBill();
            var actual = new BillGenerator(view, billforactual).GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TXTSource_ReaderTestWithoutBonusesForSAL()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            FileSourceFactory filesourceFactory = new FileSourceFactory();
            IView view = new TxtView();
            IFileSource filesource = filesourceFactory.Create("TXT");
            BillFactory factory = new BillFactory(filesource);
            var billforexpected = new Bill(new Customer("Test", 0));
            billforexpected.addGoods(new Item(goodsFactory.Create("SAL", "Pepsi"), 3, 50));
            var billforactual = factory.CreateBill(new StringReader(String.Format(
                "���������������: Test" + "\n" +
                "������������������: 0" + "\n" +
                "����������������������: 1 " + "\n" +
                "// ����: ��� ���(REG/SAL/SPO)" + "\n" +
                "1: Pepsi SAL" + "\n" +
                "������������������������: 1" + "\n" +
                "// ����: ��� ���� ����������" + "\n" +
                "1: 1 50 3")));
            var expected = new BillGenerator(view, billforexpected).GetBill();
            var actual = new BillGenerator(view, billforactual).GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TXTSource_ReaderTestWithBonusesForSPO()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            FileSourceFactory filesourceFactory = new FileSourceFactory();
            IView view = new TxtView();
            IFileSource filesource = filesourceFactory.Create("TXT");
            BillFactory factory = new BillFactory(filesource);
            var billforexpected = new Bill(new Customer("Test", 10));
            billforexpected.addGoods(new Item(goodsFactory.Create("SPO", "Fanta"), 1, 35));
            var billforactual = factory.CreateBill(new StringReader(String.Format(
                "���������������: Test" + "\n" +
                "������������������: 10" + "\n" +
                "����������������������: 1 " + "\n" +
                "// ����: ��� ���(REG/SAL/SPO)" + "\n" +
                "1: Fanta SPO" + "\n" +
                "������������������������: 1" + "\n" +
                "// ����: ��� ���� ����������" + "\n" +
                "1: 1 35 1")));
            var expected = new BillGenerator(view, billforexpected).GetBill();
            var actual = new BillGenerator(view, billforactual).GetBill();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TXTSource_ReaderTestWithoutBonusesForSPO()
        {
            GoodsFactory goodsFactory = new GoodsFactory();
            FileSourceFactory filesourceFactory = new FileSourceFactory();
            IView view = new TxtView();
            IFileSource filesource = filesourceFactory.Create("TXT");
            BillFactory factory = new BillFactory(filesource);
            var billforexpected = new Bill(new Customer("Test", 0));
            billforexpected.addGoods(new Item(goodsFactory.Create("SPO", "Fanta"), 1, 35));
            var billforactual = factory.CreateBill(new StringReader(String.Format(
                "���������������: Test" + "\n" +
                "������������������: 0" + "\n" +
                "����������������������: 1 " + "\n" +
                "// ����: ��� ���(REG/SAL/SPO)" + "\n" +
                "1: Fanta SPO" + "\n" +
                "������������������������: 1" + "\n" +
                "// ID: GID PRICE QTY" + "\n" +
                "1: 1 35 1")));
            var expected = new BillGenerator(view, billforexpected).GetBill();
            var actual = new BillGenerator(view, billforactual).GetBill();
            Assert.AreEqual(expected, actual);
        }
    }
}