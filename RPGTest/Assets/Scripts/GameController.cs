using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Core;


public class GameController : MonoBehaviour
{
    [SerializeField]
    private float _characterVerlocity;

    [SerializeField]
    private float _meleeAttackDamage = 50;

    [SerializeField]
    private float _rangedAttackDamage = 5;


    [SerializeField]
    private float _meleeAttackRange = 2;

    [SerializeField]
    private float _rangedAttackRange = 20;

    [SerializeField]
    private float _healAmount = 5;


    List<NonPlayerCharacterController> _characters = null;



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
        var characters = GameObject.FindObjectsOfType<NonPlayerCharacterController>();
        _characters = new List<NonPlayerCharacterController>(characters);

        
        for (int i = 0; i < _characters.Count; i++)
        {
            if(_characters[i].Attacktype == Constants.CharacterAttackTypes.melee)
            {
                _characters[i].Init(_meleeAttackRange,_meleeAttackDamage,_healAmount);
            }
            else
            {
                _characters[i].Init(_rangedAttackRange, _rangedAttackDamage, _healAmount);

            }
        }

        Debug.Log("Characters initialized.");

    }

    void SetTargets()
    {
        foreach (var item in _characters)
        {
            if (item.isDead()) continue;
            
            if ( !object.Equals(item.Target,null) && !item.Target.isDead()) continue;

            NonPlayerCharacterController nearTarget = null;
            foreach (var possibleTarget in _characters)
            {
                if (possibleTarget.isDead() || object.Equals(item,possibleTarget)) continue;

                if ((object.Equals(nearTarget,null)) 
                    || (Vector3.Distance(possibleTarget.transform.position, item.transform.position)<
                    Vector3.Distance(nearTarget.transform.position, item.transform.position)))
                    nearTarget = possibleTarget;

                
            }

            item.SetTarget(nearTarget);
            
        }

    }


}
