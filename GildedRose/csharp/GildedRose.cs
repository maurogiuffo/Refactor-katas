using System;
using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        readonly IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                var isBackstage = Items[i].Name == "Backstage passes to a TAFKAL80ETC concert";
                var isAgedBrie = Items[i].Name == "Aged Brie";
                var isSulfuras = Items[i].Name == "Sulfuras, Hand of Ragnaros";
                var isConjured = Items[i].Name == "Conjured Mana Cake";
                
                if (isSulfuras) continue;

                if (isAgedBrie)
                {
                    UpdateAgedBrie(i);
                    continue;
                }

                if (isBackstage)
                {
                    UpdateBackstage(i);
                    continue;
                }

                if (isConjured)
                {
                    UpdateConjured(i);
                    continue;
                }
                
                UpdateNormal(i);
            }

        }


        private void UpdateAgedBrie(int i)
        {
            IncreaseQualityBy(i,1);
            DecreaseSellIn(i);
            if (Items[i].SellIn >= 0) return;
            IncreaseQualityBy(i,1);
        }
        
        private void UpdateBackstage(int i)
        {
            IncreaseQualityBy(i,GetBackstageIncreaseQualityValue(i));
            DecreaseSellIn(i);
            if (Items[i].SellIn >= 0) return;
            DecreaseQualityBy(i,Items[i].Quality);
        }
        
        private void UpdateConjured(int i)
        {
            DecreaseQualityBy(i, 2);
            DecreaseSellIn(i);
            if (Items[i].SellIn >= 0)  return ;
            DecreaseQualityBy(i, 2);
        }

        private void UpdateNormal(int i)
        {
            DecreaseQualityBy(i, 1);
            DecreaseSellIn(i);
            if (Items[i].SellIn >= 0)  return ;
            DecreaseQualityBy(i, 1);
        }

        private void DecreaseSellIn(int i)
        {
            Items[i].SellIn = Items[i].SellIn - 1;
        }

        private int GetBackstageIncreaseQualityValue(int i)
        {
            return Items[i].SellIn < 6? 3 : Items[i].SellIn < 11 ? 2 : 1;
        }

        private void DecreaseQualityBy(int index,int value)
        {
            Items[index].Quality = Math.Max( Items[index].Quality - value,0);
        }

        private void IncreaseQualityBy(int index,int value)
        {
            Items[index].Quality = Math.Min( Items[index].Quality + value, 50);
        }
    }
}
