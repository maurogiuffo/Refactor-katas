using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    List<RPGCharacterController> _characters = null;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        SetTargets();
    }


    void Init()
    {
        var characters = GameObject.FindObjectsOfType<RPGCharacterController>();
        _characters = new List<RPGCharacterController>(characters);

        
        for (int i = 0; i < _characters.Count; i++)
        {
            if(_characters[i].Attacktype == Constants.CharacterAttackTypes.melee)
            {
                _characters[i].Init(i,2,50,5);
            }
            else
            {
                _characters[i].Init(i, 20, 5, 5);

            }
        }

        Debug.Log("Characters initialized.");

    }

    void SetTargets()
    {
        foreach (var item in _characters)
        {
            if (item.State == Constants.CharacterStates.alive)
            {
                if (item.Target == null || item.Target.State == Constants.CharacterStates.dead)
                {
                    foreach (var target in _characters)
                    {
                        if (target.State == Constants.CharacterStates.alive
                                && item.CharacterId != target.CharacterId)
                            item.SetTarget(target);
                    }
                }
            }
        }

    }


}
