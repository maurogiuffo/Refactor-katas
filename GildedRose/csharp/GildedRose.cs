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
                if(IsSulfuras(i)) continue;
                if(UpdateAgedBrie(i)) continue;
                if(UpdateBackstage(i)) continue;
                if(UpdateConjured(i)) continue;
                UpdateNormal(i);
            }
        }
        
        private bool IsAgedBrie(int i)
        {
            return Items[i].Name == "Aged Brie";
        }
        
        private bool IsConjured(int i)
        {
            return Items[i].Name == "Conjured Mana Cake";
        }

        private bool IsSulfuras(int i)
        {
            return Items[i].Name == "Sulfuras, Hand of Ragnaros";
        }

        private bool IsBackstage(int i)
        {
            return Items[i].Name == "Backstage passes to a TAFKAL80ETC concert";
        }

        private bool UpdateAgedBrie(int i)
        {
            if (!IsAgedBrie(i)) return false;
            IncreaseQualityBy(i,1);
            DecreaseSellIn(i);
            if (Items[i].SellIn >= 0) return true;
            IncreaseQualityBy(i,1);
            return true;
        }


        private bool UpdateBackstage(int i)
        {
            if (!IsBackstage(i)) return false;
            IncreaseQualityBy(i,GetBackstageIncreaseQualityValue(i));
            DecreaseSellIn(i);
            if (Items[i].SellIn >= 0) return true;
            DecreaseQualityBy(i,Items[i].Quality);
            return true;
        }
        
        private bool UpdateConjured(int i)
        {
            if(!IsConjured(i)) return false;
            DecreaseQualityBy(i, 2);
            DecreaseSellIn(i);
            if (Items[i].SellIn >= 0)  return true ;
            DecreaseQualityBy(i, 2);
            return true;
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
