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

        //[Theory]
        //[InlineData(3, 100)]
        //public void SulfarusNeverDecreasesQuality(int index, int iterations)
        //{
        //    var neverChanged = true;
        //    var item = itemService.Items[index];
        //    var consItemValue = item.Quality;

        //    for (int i = 0; i < iterations; i++)
        //    {
        //        itemService.UpdateQuality();
        //        if (item.Quality != consItemValue)
        //            neverChanged = false;
        //    }

        //    Assert.True(neverChanged);
        //}

        [Theory]
        [InlineData(2, 0, "Aged Brie")]
        [InlineData(15, 20, "Backstage passes to a TAFKAL80ETC concert")]
        [InlineData(0, 80, "Sulfuras, Hand of Ragnaros")]
        public void ItemQualityNeverHigherThen50True(int startSellValue, int startQualityValue, string name)
        {
            var neverHigherThen50 = true;
            List<Item> items = new List<Item> { new Item { Name = name, Quality = startQualityValue, SellIn = startSellValue } };

            for (int i = 0; i < 50; i++)
            {
                itemService.UpdateQuality(items);
                if (items[0].Quality > 50)
                    neverHigherThen50 = false;
            }

            Assert.True(neverHigherThen50);
        }

        [Theory]
        [InlineData(10, 20, "+5 Dexterity Vest")]
        [InlineData(5, 7, "Elixir of the Mongoose")]
        [InlineData(3, 6, "Conjured Mana Cake")]
        public void ItemQualityNeverHigherThen50False(int startSellValue, int startQualityValue, string name)
        {
            var neverHigherThen50 = true;
            List<Item> items = new List<Item> { new Item { Name = name, Quality = startQualityValue, SellIn = startSellValue } };

            for (int i = 0; i < 50; i++)
            {
                itemService.UpdateQuality(items);
                if (items[0].Quality > 50)
                    neverHigherThen50 = false;
            }

            Assert.False(neverHigherThen50);
        }

        [Theory]
        [InlineData(2, 0, "Aged Brie")]
        public void AgedBrieIncreasesValueTrue(int startSellValue, int startQualityValue, string name)
        {
            List<Item> items = new List<Item> { new Item { Name = name, Quality = startQualityValue, SellIn = 0 } };
            bool valueChanged = false;

            for (int i = 0; i < 50; i++)
            {
                itemService.UpdateQuality(items);
                if (items[0].Quality != startQualityValue)
                    valueChanged = true;
            }

            Assert.True(valueChanged);
        }

        //TODO: Gericht op edge cases de Tests maken
        [Theory]
        [InlineData(10, 20, "+5 Dexterity Vest")]
        [InlineData(2, 0, "Aged Brie")]
        [InlineData(5, 7, "Elixir of the Mongoose")]
        [InlineData(0, 80, "Sulfuras, Hand of Ragnaros")]
        [InlineData(15, 20, "Backstage passes to a TAFKAL80ETC concert")]
        [InlineData(3, 6, "Conjured Mana Cake")]
        public void TestQualityNeverNegative(int startSellValue, int startQualityValue, string name)
        {
            List<Item> items = new List<Item> { new Item { Name = name, Quality = startQualityValue, SellIn = 0 } };
            var valueNegative = items[0].Quality >= 0;

            for (int i = 0; i < 50; i++)
            {
                itemService.UpdateQuality(items);
                if (items[0].Quality < 0)
                    valueNegative = false;
            }

            Assert.True(valueNegative);
        }

        [Theory]
        [InlineData(20, "+5 Dexterity Vest")]
        [InlineData(7, "Elixir of the Mongoose")]
        [InlineData(6, "Conjured Mana Cake")]
        public void TestSaleDatePassedQualityDegradesTwiceAsFastTrue(int startQualityValue, string name)
        {
            List<Item> items = new List<Item> { new Item { Name = name, Quality = startQualityValue, SellIn = 0 } };
            var qualityValue = items[0].Quality - 2;

            itemService.UpdateQuality(items);

            Assert.True(items[0].Quality == qualityValue);
        }

        [Theory]
        [InlineData(0, "Aged Brie")]
        [InlineData(80, "Sulfuras, Hand of Ragnaros")]
        [InlineData(20, "Backstage passes to a TAFKAL80ETC concert")]
        public void TestSaleDatePassedQualityDegradesTwiceAsFastFalse(int startQualityValue, string name)
        {
            List<Item> items = new List<Item> { new Item { Name = name, Quality = startQualityValue, SellIn = 0 } };
            var qualityValue = items[0].Quality - 2;

            itemService.UpdateQuality(items);

            Assert.False(items[0].Quality == qualityValue);
        }

        [Theory]
        [InlineData(10, 20,"+5 Dexterity Vest", 9, 19)]
        [InlineData(2, 0,"Aged Brie", 1, 1)]
        [InlineData(5, 7, "Elixir of the Mongoose", 4, 6)]
        [InlineData(0, 80, "Sulfuras, Hand of Ragnaros", 0, 80)]
        [InlineData(15, 20, "Backstage passes to a TAFKAL80ETC concert", 14, 21)]
        [InlineData(3, 6, "Conjured Mana Cake", 2, 5)]
        public void TestAllConditionsOnce(int startSellValue, int startQualityValue ,string name, int sellInValue, int qualityValue)
        {
            List<Item> items = new List<Item> { new Item { Name = name, Quality = startQualityValue, SellIn = startSellValue } };

            itemService.UpdateQuality(items);

            Assert.True(items[0].SellIn == sellInValue && items[0].Quality == qualityValue);
        }
    }
}