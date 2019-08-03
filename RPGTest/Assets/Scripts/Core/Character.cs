using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

namespace Core
{
    
    public class Character : Attackable 
    {

        [SerializeField]
        protected Constants.CharacterAttackTypes _Attacktype;
        
        [SerializeField]
        public float AttackRange { get; set; }

        private IDealDamage dealDamage { get; set; } = new DealDamageBehavior();
        private IHeal heal { get; set; } = new HealBehavior();
        
        public void Init()
        {
            base.Init(Constants.MaxCharacterHealth,1);
        }
       
        public Constants.CharacterAttackTypes Attacktype { get => _Attacktype; }

        public void DealDamage(Attackable target, float damage, float distance)
        {
            dealDamage.DealDamage(this, target, damage,distance, AttackRange);
        }

        public void Heal(float health)
        {
            heal.Heal(this,this, health);
        }


    }
}