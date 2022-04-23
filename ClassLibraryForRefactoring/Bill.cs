using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryForRefactoring
{
    public class Bill
    {
        private List<Item> _items;
        private Customer _customer;
        public Bill(Customer customer)
        {
            this._customer = customer;
            this._items = new List<Item>();
        }
        public void addGoods(Item arg)
        {
            _items.Add(arg);
        }
        public BillSummary Process()
        {
            double totalAmount = 0;
            int totalBonus = 0;
            var thisbill = new BillSummary();
            thisbill.SetCustomerName(_customer.getName());
            List<Item>.Enumerator items = _items.GetEnumerator();

            while (items.MoveNext())
            {
                var thisitem = new ItemSummary();
                Item each = (Item)items.Current;

                thisitem.SetName(each.getGoods().getTitle());
                thisitem.SetPrice(each.getPrice());
                thisitem.SetQuantity(each.getQuantity());
                thisitem.SetSum(each.GetSum());
                thisitem.SetDiscount(each.GetDiscount());
                thisitem.SetTotalPrice(each.GetSum() - each.GetDiscount() - each.GetUsedBonus(_customer));
                thisitem.SetBonus(each.GetBonus());

                totalAmount += thisitem.GetTotalPrice();
                totalBonus += thisitem.GetBonus();
                thisbill.AddItems(thisitem);
            }

            //Запомнить бонус клиента
            _customer.receiveBonus(totalBonus);
            thisbill.SetTotalAmount(totalAmount);
            thisbill.SetTotalBonus(totalBonus);

            return thisbill;
        }
    }
}
