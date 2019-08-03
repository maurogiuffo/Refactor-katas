using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

namespace Core
{
    public abstract class Attackable: MonoBehaviour
    {
        public float Health { get; set; }
        public int Level { get; set;}

        public void Init(float healt, int level)
        {
            Health = healt;
            Level  = level;
        }
        
        public bool isDead()
        {
            return Health == 0;
        }

    }
}