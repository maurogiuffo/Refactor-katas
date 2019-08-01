using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                _characters[i].Init(i,_meleeAttackRange,_meleeAttackDamage,_healAmount, _characterVerlocity);
            }
            else
            {
                _characters[i].Init(i, _rangedAttackRange, _rangedAttackDamage, _healAmount, _characterVerlocity);

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

                    NonPlayerCharacterController nearTarget = null;
                    foreach (var possibleTarget in _characters)
                    {
                        if (possibleTarget.State == Constants.CharacterStates.alive
                                && item.CharacterId != possibleTarget.CharacterId)
                        {

                            if ((nearTarget == null) || (Vector3.Distance(possibleTarget.transform.position, item.transform.position)<
                                Vector3.Distance(nearTarget.transform.position, item.transform.position)))
                                nearTarget = possibleTarget;

                        }
                    }

                    item.SetTarget(nearTarget);
                }
            }
        }

    }


}
