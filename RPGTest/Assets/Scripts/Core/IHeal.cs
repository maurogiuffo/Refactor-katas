namespace Core
{
    public interface IHeal
    {
        void Heal(Attackable healer, Attackable target, float health);
    }
}