using System;
using System.Collections.Generic;

namespace csharp
{
    public class GildedRoseRefactoredOLD
    {
        IList<Item> Items;
        public GildedRoseRefactoredOLD(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                UpdateItemQuality(Items[i]);
            }
        }
        
        private void UpdateItemQuality(Item item)
        {
            switch (item.Name)
            {
                case "Sulfuras, Hand of Ragnaros":
                    UpdateSulfuras(item);
                    break;
                case "Aged Brie":
                    UpdateAgedBrie(item);
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    UpdateQualityBackstagePasses(item);
                    break;
                case "Conjured Mana Cake":
                    UpdateQualityConjured(item);
                    break;
                default:
                    UpdateNormalItem(item);
                    break;
            }
        }
        
        private void UpdateQualityConjured(Item item)
        {
            item.SellIn = item.SellIn - 1;
            item.Quality = item.Quality - 2;

            if (item.SellIn < 0)
                item.Quality = item.Quality - 2;
            
            ApplyQualityLimits(item);
        }

        private void UpdateQualityBackstagePasses(Item item)
        {
            item.SellIn = item.SellIn - 1;
            item.Quality = item.Quality + 1;

            if (item.SellIn < 10)
                item.Quality = item.Quality + 1;

            if (item.SellIn < 5)
                item.Quality = item.Quality + 1;

            if (item.SellIn < 0)
                 item.Quality = 0;
            
            ApplyQualityLimits(item);
        }
        
        private void UpdateAgedBrie(Item item)
        {

            item.SellIn = item.SellIn - 1;
            item.Quality = item.Quality + 1;

            if (item.SellIn < 0)
                item.Quality = item.Quality + 1;
                 
            ApplyQualityLimits(item);
        }

        private void UpdateSulfuras(Item item)
        {
            item.Quality = Math.Max(0, item.Quality);
        }

        private void UpdateNormalItem(Item item)
        {
            item.SellIn = item.SellIn - 1;
            item.Quality = item.Quality - 1;
            
            if (item.SellIn < 0)
                item.Quality = item.Quality - 1;

            ApplyQualityLimits(item);
       }
        
        
        private static void ApplyQualityLimits(Item item)
        {
            item.Quality = Math.Min(50, item.Quality);
            item.Quality = Math.Max(0, item.Quality);
        }

    }
}
