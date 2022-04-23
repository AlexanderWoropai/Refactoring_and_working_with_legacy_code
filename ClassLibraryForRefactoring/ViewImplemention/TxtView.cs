using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryForRefactoring
{
    public class TxtView : IView
    {
        public string GetFooter(double totalAmount, int totalBonus)
        {
            return "Сумма счета составляет " + totalAmount.ToString() + "\n" +
            "Вы заработали " + totalBonus.ToString() + " бонусных балов";
        }

        public string GetHeader(string _customerName) 
        {
            return "Счет для " + _customerName + "\n" +
            "\t" + "Название" + "\t" + "Цена" +
            "\t" + "Кол-во" + "Стоимость" + "\t" + "Скидка" +
            "\t" + "Сумма" + "\t" + "Бонус" + "\n";
        }

        public string GetItemString(ItemSummary item)
        {
            return "\t" + item.GetName() + "\t" +
                "\t" + item.GetPrice() + 
                "\t" + item.GetQuantity() +
                "\t" + item.GetSum() +
                "\t" + item.GetDiscount() + 
                "\t" + item.GetTotalPrice() +
                "\t" + item.GetBonus() + "\n";
        }
    }
}
