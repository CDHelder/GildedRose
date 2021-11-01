using GildedRose.Business.Strategies;
using GildedRose.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Business
{
    public class ItemService
    {
        public UpdateQualityStrategyHandler strategyHandler;
        public ItemService()
        {
            strategyHandler = new UpdateQualityStrategyHandler();
        }
        public void UpdateQuality(List<Item> items)
        {
            foreach (var item in items)
            {
                strategyHandler.UpdateQuality(item);
                if(item.SellIn != 0)
                    item.SellIn -= 1;
            }
        }
    }
}
