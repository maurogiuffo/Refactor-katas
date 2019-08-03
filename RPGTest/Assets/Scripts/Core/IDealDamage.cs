using UnityEngine.Rendering;

namespace Core
{
    public interface IDealDamage
    {
         void DealDamage(Attackable attacker, Attackable target, float damage,float distance,float range);
    }
}