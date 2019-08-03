using UnityEngine;

namespace Core
{
    public class HealBehavior : IHeal
    {
        public void Heal(Attackable healer, Attackable target, float health)
        {
            if(target.isDead()) return;
            if(healer != target) return;
            target.Health = Mathf.Min(Constants.MaxCharacterHealth, target.Health + health);
        }
    }
}