using GildedRose.Domain;
using GildedRose.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Business.Strategies
{
    public class BasicStrategy : IUpdateQualityStrategy
    {
        public void UpdateQuality(Item item)
        {
            if (item.Quality == 0)
                return;
            else if (item.SellIn > 0)
                item.Quality -= 1;
            else if (item.SellIn == 0)
                item.Quality -= 2;
        }
    }
}
