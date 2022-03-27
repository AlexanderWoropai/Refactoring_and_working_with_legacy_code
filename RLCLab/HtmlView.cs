﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLCLab
{
    public class HtmlView : IView
    {
        public string GetFooter(double totalAmount, int totalBonus)
        {
            string result = "";
            result += String.Format("<p>Сумма счета составляет {0}</p>" +
                "<p>Вы заработали {1} бонусных баллов</p>", totalAmount, totalBonus);
            return result;
        }

        public string GetHeader(Customer _customer)
        {
            string result = "<style>.field{width: 100px; float: left;}</style>";
            result += String.Format("<p>Счет для {0}</p>" +
                "<div class='field'>Название</div>" +
                "<div class='field'>Цена</div>" +
                "<div class='field'>Кол-во</div>" +
                "<div class='field'>Стоимость</div>" +
                "<div class='field'>Скидка</div>" +
                "<div class='field'>Сумма</div>" +
                "<div class='field'>Бонус</div><br>", _customer.getName());
            return result;
        }

        public string GetItemString(Item item, double usedBonus)
        {
            string result = "<style>.field{width: 100px; float: left;}</style>";
            result += String.Format("<div class='field'>{0}</div>" +
                "<div class='field'>{1}</div>" +
                "<div class='field'>{2}</div>" +
                "<div class='field'>{3}</div>" +
                "<div class='field'>{4}</div>" +
                "<div class='field'>{5}</div>" +
                "<div class='field'>{6}</div><br>", 
                item.getGoods().getTitle(),
                item.getPrice(),
                item.getQuantity(),
                (item.GetSum()).ToString(),
                item.GetDiscount().ToString(),
                (item.GetSum() - item.GetDiscount() - usedBonus).ToString(),
                item.GetBonus().ToString());
            return result;
        }
    }
}
