using GildedRose.Domain;
using GildedRose.Domain.Interfaces;

namespace GildedRose.Business.Strategies
{
    public class BackstagePassesStrategy : IUpdateQualityStrategy
    {
        public void UpdateQuality(Item item)
        {
            if (item.SellIn > 10)
                if (item.Quality + 1 < 50)
                    item.Quality += 1;
            else if (item.SellIn <= 10 && item.SellIn > 5)
                if (item.Quality + 2 < 50)
                    item.Quality += 2;
            else if (item.SellIn <= 5)
                if (item.Quality + 3 < 50)
                    item.Quality += 3;
            else if (item.SellIn == 0)
                item.Quality = 0;
        }
    }
}