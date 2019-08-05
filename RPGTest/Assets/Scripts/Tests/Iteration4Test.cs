using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Core;


namespace Tests
{
    public class Iteration4Test
    {
        [Test]
        public void PlayerCanDamageNonCharacters()
        {
            var character = new GameObject().AddComponent<Character>();
            var target = new GameObject().AddComponent<House>();

            character.Init();
            target.Init();
            
            character.DealDamage(target,100,0);
            Assert.AreEqual(1900,target.Health);
        }
    }
}