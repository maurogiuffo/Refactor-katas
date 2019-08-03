using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

public class RPGCharacterController : Attackable 
{

    [SerializeField]
    protected Constants.CharacterAttackTypes _Attacktype;
    
    [SerializeField]
    public float AttackRange { get; set; }

    private IDealDamage dealDamage { get; set; } = new DealDamageBehavior();
    private IHeal heal { get; set; } = new HealBehavior();
    
    
    

    //public float _attackDamage = 0;

 
   
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
