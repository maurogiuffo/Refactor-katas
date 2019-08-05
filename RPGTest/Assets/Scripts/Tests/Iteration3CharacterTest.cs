using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Core;

namespace Tests
{
    public class Iteration3CharacterTest
    {
        [Test]
        public void MeleeFighterAttackRange()
        {
            var character = new GameObject().AddComponent<Character>();
            var target = new GameObject().AddComponent<Character>();

            character.Init();
            target.Init();

            character.SetAttackType(Constants.CharacterAttackTypes.melee);
            
            character.DealDamage(target,100,3);
            Assert.AreEqual(1000,target.Health);
            
            character.DealDamage(target,100,2);
            Assert.AreEqual(900,target.Health);
        }
        
        [Test]
        public void RangedFighterAttackRange()
        {
            var character = new GameObject().AddComponent<Character>();
            var target = new GameObject().AddComponent<Character>();

            character.Init();
            target.Init();

            character.SetAttackType(Constants.CharacterAttackTypes.ranged);
            
            character.DealDamage(target,100,21);
            Assert.AreEqual(1000,target.Health);
            
            character.DealDamage(target,100,20);
            Assert.AreEqual(900,target.Health);
        }

    }
}