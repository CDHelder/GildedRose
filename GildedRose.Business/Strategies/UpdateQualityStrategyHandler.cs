using GildedRose.Domain;
using GildedRose.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Business.Strategies
{
    public class UpdateQualityStrategyHandler
    {
        //    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
        //    new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
        //    new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
        //    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
        //    new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
        //    new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}

        public BasicStrategy _basicStrategy;
        public AgedBrieStrategy _agedBrieStrategy;
        public BackstagePassesStrategy _backstagePassesStrategy;
        public ConjuredStrategy _conjuredStrategy;

        public void UpdateQuality(Item item)
        {
            if (item.Name == "+5 Dexterity Vest" || item.Name == "Elixir of the Mongoose")
                BasicStrategy.UpdateQuality(item);
            else if (item.Name == "Aged Brie")
                AgedBrieStrategy.UpdateQuality(item);
            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                BackstagePassesStrategy.UpdateQuality(item);
            else if (item.Name == "Conjured Mana Cake")
                ConjuredStrategy.UpdateQuality(item);
        }

        public BasicStrategy BasicStrategy
        {
            get => _basicStrategy ?? new BasicStrategy();
            private set => _basicStrategy = value;
        }
        public AgedBrieStrategy AgedBrieStrategy
        {
            get => _agedBrieStrategy ?? new AgedBrieStrategy();
            private set => _agedBrieStrategy = value;
        }
        public BackstagePassesStrategy BackstagePassesStrategy
        {
            get => _backstagePassesStrategy ?? new BackstagePassesStrategy();
            private set => _backstagePassesStrategy = value;
        }
        public ConjuredStrategy ConjuredStrategy
        {
            get => _conjuredStrategy ?? new ConjuredStrategy();
            private set => _conjuredStrategy = value;
        }

    }
}
