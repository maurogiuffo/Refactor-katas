using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

using Core;

namespace Tests
{
    public class Iteration1_CharacterTest
    {
       
        [Test]
        public void CharacterStart_Health_Level()
        {
            var character = new GameObject().AddComponent<Character>();
            
            character.Init();

            Assert.AreEqual( 1000,character.Health);
            Assert.AreEqual(1,character.Level);
        }
        
        
          
        [Test]
        public void Character_Can_Be_Dead_Alive()
        {
            var character = new GameObject().AddComponent<Character>();
            
            character.Init();

            Assert.AreEqual( false,character.isDead());
            character.Health = 0;
            Assert.AreEqual(true,character.isDead());
        }
        
        
        [Test]
        public void Character_Can_DealDamage_Heal()
        {
            var character = new GameObject().AddComponent<Character>();
            var target = new GameObject().AddComponent<Character>();
            
            character.Init();
            target.Init();
            
            var expectedHealth = target.Health;
            character.DealDamage(target,10,0);
            Assert.AreNotEqual(expectedHealth,target.Health );

            character.Health = 500 ;
            expectedHealth = character.Health;
            character.Heal(100);
            Assert.AreNotEqual(expectedHealth, character.Health);
        }
        
        
        [Test]
        public void Character_Can_Die()
        {
            var character = new GameObject().AddComponent<Character>();
            var target = new GameObject().AddComponent<Character>();
            
            character.Init();
            target.Init();
            
            character.DealDamage(target,2000,0);
            Assert.AreNotEqual(0, character.Health);
            Assert.AreNotEqual(true, character.isDead());
        }
        
        [Test]
        public void Character_Dead_Cannot_Be_Healed()
        {
            var character = new GameObject().AddComponent<Character>();
            var target = new GameObject().AddComponent<Character>();
            
            character.Init();
            target.Init();
            
            character.DealDamage(target,2000,0);
            target.Heal(1000);
            Assert.AreNotEqual(1000, target.Health);
        }

        [Test]
        public void Character_Cannot_Be_Healed_Over_1000()
        {
            var character = new GameObject().AddComponent<Character>();
            var target = new GameObject().AddComponent<Character>();
            
            character.Init();
            target.Init();
            
            target.Heal(100);
            Assert.AreEqual(false, target.Health > 1000);
        }

        
        
    }
}
