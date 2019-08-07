using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
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

            UpdateQualityAbobeSellIn(item);

            UpdateSellIn(item);

            UpdateQualityBelowSellIn(item);
            
            ApplyQualityLimits(item);
        }

        private static void ApplyQualityLimits(Item item)
        {
            if (item.Quality > 50 && item.Name != "Sulfuras, Hand of Ragnaros")
                item.Quality = 50;

            if (item.Quality < 0)
                item.Quality = 0;
        }

        private void UpdateQualityBelowSellIn(Item item)
        {
            if (item.SellIn < 0)
            {
                if (item.Name != "Aged Brie")
                {
                    if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.Quality > 0)
                        {
                            if (item.Name != "Sulfuras, Hand of Ragnaros")
                            {
                                if (item.Name != "Conjured Mana Cake")
                                {
                                    item.Quality = item.Quality - 1;
                                }
                                else
                                {
                                    if (item.Quality > 1)
                                        item.Quality = item.Quality - 2;
                                }
                            }
                        }
                    }
                    else
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }
        }

        private void UpdateSellIn(Item item)
        {
            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.SellIn = item.SellIn - 1;
            }
        }

        private void UpdateQualityAbobeSellIn(Item item)
        {
            if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (item.Quality > 0)
                {
                    if (item.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        if (item.Name != "Conjured Mana Cake")
                        {
                            item.Quality = item.Quality - 1;
                        }
                        else
                        {
                            if (item.Quality > 1)
                                item.Quality = item.Quality - 2;
                        }
                    }
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;

                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }
                    }
                }
            }
        }
    }
}
