using GildedRose.Domain;
using GildedRose.Domain.Interfaces;

namespace GildedRose.Business.Strategies
{
    public class AgedBrieStrategy : IUpdateQualityStrategy
    {
        public void UpdateQuality(Item item)
        {
            if (item.Quality == 50)
                return;
            else if (item.Quality < 50)
                item.Quality += 1;
        }
    }
}