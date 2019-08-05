using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Core;


namespace Tests
{
    
    public class Iteration2CharacterTest
    {

        [Test]
        public void PlayerCanDealDamageOnlyEnemies()
        {
            var character = new GameObject().AddComponent<Character>();
            var target = new GameObject().AddComponent<Character>();

            character.Init();
            target.Init();
            
            character.DealDamage(target,100,0);
            Assert.AreEqual(900,target.Health);
            
            character.DealDamage(character,100,0);
            Assert.AreEqual(1000,character.Health);
        }
        
        [Test]
        public void PlayerCanHealOnlyHimself()
        {
            var character = new GameObject().AddComponent<Character>();
            var target = new GameObject().AddComponent<Character>();

            character.Init();
            target.Init();
            
            character.Health = 900;
            target.Health = 900;

            var healBehavior = new HealBehavior();
            
            healBehavior.Heal(character,character,100);
            Assert.AreEqual(1000,character.Health);
            
            healBehavior.Heal(character,target,100);
            Assert.AreEqual(900,target.Health);

        }

        [Test]
        public void LevelBoostDamage()
        {
            var character = new GameObject().AddComponent<Character>();
            var target = new GameObject().AddComponent<Character>();

            character.Init();
            target.Init();
            
            character.Level = 6;
            target.Level = 1;

            character.DealDamage(target,100,0);
            Assert.AreEqual(1000 - (100 * 1.5f),target.Health);

        }

        [Test]
        public void LevelReduceDamage()
        {
            var character = new GameObject().AddComponent<Character>();
            var target = new GameObject().AddComponent<Character>();

            character.Init();
            target.Init();
            
            character.Level = 1;
            target.Level = 6;

            character.DealDamage(target,100,0);
            Assert.AreEqual(1000 - (100 * 0.5f),target.Health);

        }

    }
}