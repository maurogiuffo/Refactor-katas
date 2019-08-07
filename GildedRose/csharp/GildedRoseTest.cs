using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
       
        [Test]
        public void LowerItemValues()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            foreach (var item in Items)
            {
                Assert.AreEqual(9, item.SellIn);
                Assert.AreEqual(9, item.Quality);
            }
            
        }


        [Test]
        public void DegradeTwiceAsFast()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            foreach (var item in Items)
            {
                Assert.AreEqual(8, item.Quality);
            }
        }
        
        [Test]
        public void QualityNeverNegative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            foreach (var item in Items)
            {
                Assert.AreEqual(0, item.Quality);
            }
        }
        
        
        [Test]
        public void AgedBrieIncreasesQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            foreach (var item in Items)
            {
                Assert.AreEqual(11, item.Quality);
            }
        }
        
        
        [Test]
        public void QualityNeverMore50()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 80 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            foreach (var item in Items)
            {
                Assert.AreEqual(50, item.Quality);
            }
        }
        
        [Test]
        public void SulfurasNeverHasToBeSold()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            foreach (var item in Items)
            {
                Assert.AreEqual(10, item.SellIn);
            }
        }
     
        [Test]
        public void SulfurasNotDecreasesQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            foreach (var item in Items)
            {
                Assert.AreEqual(10, item.Quality);
            }
        }
        
        [Test]
        public void BackstagePassesIncreases2QualityLess10Days()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            foreach (var item in Items)
            {
                Assert.AreEqual(12, item.Quality);
            }
        }
        
        
        [Test]
        public void BackstagePassesIncreases3QualityLess5Days()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            foreach (var item in Items)
            {
                Assert.AreEqual(13, item.Quality);
            }
        }

         
        [Test]
        public void BackstagePassesDropsTo0QualityAfterSellIn()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            foreach (var item in Items)
            {
                Assert.AreEqual(0, item.Quality);
            }
        }
        
        [Test]
        public void ConjuredDegradeQualityTwiceAsFast()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 10, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            foreach (var item in Items)
            {
                Assert.AreEqual(8, item.Quality);
            }
        }
        
        [Test]
        public void ConjuredDegradeQualityTwiceAsFastLower0()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = -1, Quality = 10 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();

            foreach (var item in Items)
            {
                Assert.AreEqual(6, item.Quality);
            }
        }
    }
}
