using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryForRefactoring
{
    public class BillSummary
    {
        double _TotalAmount;
        string _CustomerName;
        int _TotalBonus;
        List<ItemSummary> _items;
        public BillSummary()
        {
            _items = new List<ItemSummary>();
        }
        public double GetTotalAmount()
        {
            return _TotalAmount;
        }
        public void SetTotalAmount(double _TotalAmount) 
        {
            this._TotalAmount = _TotalAmount;
        }
        public string GetCustomerName() 
        {
            return _CustomerName;
        }
        public void SetCustomerName(string _CustomerName) 
        {
            this._CustomerName = _CustomerName;
        }
        public int GetTotalBonus() 
        {
            return _TotalBonus;
        }
        public void SetTotalBonus(int _TotalBonus) 
        {
            this._TotalBonus = _TotalBonus;
        }
        public List<ItemSummary> GetItems() 
        {
            return _items;
        }
        public void AddItems(ItemSummary someitem) 
        {
            this._items.Add(someitem);
        }
    }
}
