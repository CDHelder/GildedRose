using GildedRose.Business;
using GildedRose.Domain;
using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests
{
    public class TestAssemblyTests
    {
        private ItemService itemService;

        public TestAssemblyTests()
        {
            itemService = new ItemService();
        }

        [Theory]
        [InlineData(0,9,19)]
        [InlineData(1,1,1)]
        [InlineData(2,4,6)]
        [InlineData(3,0,80)]
        [InlineData(4,14,21)]
        [InlineData(5,2,5)]
        public void TestTheTruth(int index, int sellInValue, int qualityValue)
        {
            itemService.UpdateQuality();
            var item = itemService.Items[index];
            Assert.True(item.SellIn == sellInValue && item.Quality == qualityValue);
        }
    }
}