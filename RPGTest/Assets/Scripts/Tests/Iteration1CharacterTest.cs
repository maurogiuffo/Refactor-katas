using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Core;

namespace Tests
{
    public class Iteration1CharacterTest
    {
       
        [Test]
        public void CharacterStartHealthLevel()
        {
            var character = new GameObject().AddComponent<Character>();
            
            character.Init();

            Assert.AreEqual( 1000,character.Health);
            Assert.AreEqual(1,character.Level);
        }
        
        
          
        [Test]
        public void CharacterCanBeDeadAlive()
        {
            var character = new GameObject().AddComponent<Character>();
            
            character.Init();
            Assert.AreEqual( false,character.isDead());

            character.Health = 0;
            Assert.AreEqual(true,character.isDead());
        }
        
        
        [Test]
        public void CharacterCanDealDamageHeal()
        {
            var character = new GameObject().AddComponent<Character>();
            var target = new GameObject().AddComponent<Character>();
            
            character.Init();
            target.Init();
            
            character.DealDamage(target,10,0);
            Assert.AreEqual(990,target.Health );

            character.Health = 500 ;
            character.Heal(100);
            Assert.AreEqual(600, character.Health);
        }
        
        
        [Test]
        public void CharacterCanDie()
        {
            var character = new GameObject().AddComponent<Character>();
            var target = new GameObject().AddComponent<Character>();
            
            character.Init();
            target.Init();
            
            character.DealDamage(target,2000,0);
            Assert.AreEqual(true, target.isDead());
        }
        
        [Test]
        public void CharacterDeadCannotBeHealed()
        {
            var character = new GameObject().AddComponent<Character>();
            var target = new GameObject().AddComponent<Character>();
            
            character.Init();
            target.Init();
            
            character.DealDamage(target,2000,0);
            target.Heal(1000);
            Assert.AreEqual(0, target.Health);
        }

        [Test]
        public void CharacterCannotBeHealedOver1000()
        {
            var character = new GameObject().AddComponent<Character>();
            
            character.Init();
            
            character.Heal(100);
            Assert.AreEqual(false, character.Health > 1000);
        }

        
        
    }
}
