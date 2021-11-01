using GildedRose.Domain;
using GildedRose.Domain.Interfaces;

namespace GildedRose.Business.Strategies
{
    public class ConjuredStrategy : IUpdateQualityStrategy
    {
        public void UpdateQuality(Item item)
        {
            if (item.Quality == 0)
                return;
            else if (item.SellIn > 0)
                item.Quality -= 2;
            else if (item.SellIn == 0)
                item.Quality -= 4;
        }
    }
}