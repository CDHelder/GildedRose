using GildedRose.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GildedRose.Domain.Interfaces
{
    public interface IUpdateQualityStrategy
    {
        void UpdateQuality(Item item);
    }
}
