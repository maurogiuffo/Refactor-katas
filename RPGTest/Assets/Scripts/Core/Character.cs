using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core
{
    
    public class Character : Attackable 
    {

        [SerializeField]
        protected Constants.CharacterAttackTypes attackType;

        public Constants.CharacterAttackTypes AttackType
        {
            get => attackType;
         
        }

        [SerializeField]
        public float AttackRange { get; set; }
     


        private DealDamageBehavior dealDamage { get; set; } = new DealDamageBehavior();
        private HealBehavior heal { get; set; } = new HealBehavior();
        
        public void Init()
        {
            base.Init(Constants.MaxCharacterHealth,1);
        }
        
        public void SetAttackType(Constants.CharacterAttackTypes attackType)
        {
            this.attackType = attackType;

            switch (attackType)
            {
                case Constants.CharacterAttackTypes.melee:
                    AttackRange = 2;
                    break;
                case Constants.CharacterAttackTypes.ranged:
                    AttackRange = 20;
                    break;
            }
            
        }
       

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