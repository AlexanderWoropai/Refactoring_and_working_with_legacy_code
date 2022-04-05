using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLCLab
{
    public class ItemSummary
    {
        string _Name;
        double _Price;
        double _Quantity;
        double _Sum;
        double _Discount;
        double _TotalPrice;
        int _Bonus;
        public string GetName() 
        {
            return _Name;
        }
        public void SetName(string _Name) 
        {
            this._Name = _Name;
        }
        public double GetPrice() 
        {
            return _Price;
        }
        public void SetPrice(double _Price) 
        {
            this._Price = _Price;
        }
        public double GetQuantity() 
        {
            return _Quantity;
        }
        public void SetQuantity(double _Quantity) 
        {
            this._Quantity = _Quantity;
        }
        public double GetSum() 
        {
            return _Sum;
        }
        public void SetSum(double _Sum) 
        {
            this._Sum = _Sum;
        }
        public double GetDiscount() 
        {
            return _Discount;
        }
        public void SetDiscount(double _Discount) 
        {
            this._Discount = _Discount;   
        }
        public double GetTotalPrice() 
        {
            return _TotalPrice;
        }
        public void SetTotalPrice(double _TotalPrice) 
        {
            this._TotalPrice = _TotalPrice;
        }
        public int GetBonus() 
        {
            return _Bonus;
        }
        public void SetBonus(int _Bonus) 
        {
            this._Bonus = _Bonus;
        }
    }
}
