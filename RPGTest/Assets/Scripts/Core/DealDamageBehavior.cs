using System;

namespace Core
{
    public class DealDamageBehavior
    {
        public void DealDamage(Attackable attacker, Attackable target, float damage, float distance,float range)
        {
            if(attacker == target) return;
            if(distance > range) return;
            damage *= hasHigherLevel(attacker, target, 5) ? 1.5f : 1;
            damage *= hasHigherLevel(target,attacker , 5) ? 0.5f : 1;
            target.Health = Math.Max(0, target.Health - damage);
        }

        bool hasHigherLevel(Attackable attacker, Attackable target, int difference)
        {
            return attacker.Level >= target.Level + difference;
        }
        
    }
}