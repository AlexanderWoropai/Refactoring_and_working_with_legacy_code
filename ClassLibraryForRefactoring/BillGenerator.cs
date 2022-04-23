using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryForRefactoring
{
    public class BillGenerator
    {
        private Bill _somebill;
        private IView _View;
        public BillGenerator(IView View, Bill somebill)
        {
            this._View = View;
            this._somebill = somebill;
        }
        public String GetBill()
        {
            var billforprint = _somebill.Process();

            List<ItemSummary>.Enumerator items = billforprint.GetItems().GetEnumerator();
            String result = _View.GetHeader(billforprint.GetCustomerName());

            while (items.MoveNext())
            {
                ItemSummary each = (ItemSummary)items.Current;

                result += _View.GetItemString(each);
            }
            //добавить нижний колонтитул
            result += _View.GetFooter(billforprint.GetTotalAmount(), billforprint.GetTotalBonus());

            return result;
        }
        public void SetView(IView View)
        {
            _View = View;
        }
    }
}
