namespace Core
{
    public class House : Attackable
    {
        public void Init()
        {
            base.Init(Constants.MaxHouseHealth,1);
        }
    }
}