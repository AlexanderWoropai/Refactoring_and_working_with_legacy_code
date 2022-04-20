using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLCLab
{
    public class GoodsFactory
    {
        Config BonusConfigREG;
        Config BonusConfigSAL;
        Config BonusConfigSPO;
        Config DiscountConfigREG;
        Config DiscountConfigSAL;
        Config DiscountConfigSPO;
        public GoodsFactory(AllConfigs _configFile) 
        {
            BonusConfigREG = _configFile.DataForBonusREG_SAL_SPO[0];
            BonusConfigSAL = _configFile.DataForBonusREG_SAL_SPO[1];
            BonusConfigSPO = _configFile.DataForBonusREG_SAL_SPO[2];
            DiscountConfigREG = _configFile.DataForDiscountREG_SAL_SPO[0];
            DiscountConfigSAL = _configFile.DataForDiscountREG_SAL_SPO[1];
            DiscountConfigSPO = _configFile.DataForDiscountREG_SAL_SPO[2];
        }
        public Goods Create(string type,string title) 
        {
            IBonusStrategy BonusStrategy;
            IDiscountStrategy DiscountStrategy;
            Config _thisConfigBonus;
            Config _thisConfigDiscount;
            var _strategyFactory = new StrategyFactory();
            if (type == "REG") 
            {
                _thisConfigBonus = BonusConfigREG;
                _thisConfigDiscount = DiscountConfigREG;
                BonusStrategy = _strategyFactory.BonusStrategyCreate(_thisConfigBonus.TypeOfStrategy, _thisConfigBonus.value_to_return, _thisConfigBonus.limitation);
                DiscountStrategy = _strategyFactory.DiscountStrategyCreate(_thisConfigDiscount.TypeOfStrategy, _thisConfigDiscount.value_to_return, _thisConfigDiscount.limitation);
                return new REG(title, BonusStrategy, DiscountStrategy); 
            }
            if (type == "SAL") 
            {
                _thisConfigBonus = BonusConfigSAL;
                _thisConfigDiscount = DiscountConfigSAL;
                BonusStrategy = _strategyFactory.BonusStrategyCreate(_thisConfigBonus.TypeOfStrategy, _thisConfigBonus.value_to_return, _thisConfigBonus.limitation);
                DiscountStrategy = _strategyFactory.DiscountStrategyCreate(_thisConfigDiscount.TypeOfStrategy, _thisConfigDiscount.value_to_return, _thisConfigDiscount.limitation);
                return new SAL(title, BonusStrategy, DiscountStrategy);
            };
            if (type == "SPO") 
            {
                _thisConfigBonus = BonusConfigSPO;
                _thisConfigDiscount = DiscountConfigSPO;
                BonusStrategy = _strategyFactory.BonusStrategyCreate(_thisConfigBonus.TypeOfStrategy, _thisConfigBonus.value_to_return, _thisConfigBonus.limitation);
                DiscountStrategy = _strategyFactory.DiscountStrategyCreate(_thisConfigDiscount.TypeOfStrategy, _thisConfigDiscount.value_to_return, _thisConfigDiscount.limitation);
                return new SPO(title, BonusStrategy, DiscountStrategy);
            };
            return null;
        }
    }
}
