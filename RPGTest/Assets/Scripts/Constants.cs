using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants 
{
    public enum CharacterStates
    {
        alive,
        dead
    }

    public enum CharacterAttackTypes
    {
        melee ,
        ranged 
    }

   
    public const float MaxCharacterHealth = 1000;


}
