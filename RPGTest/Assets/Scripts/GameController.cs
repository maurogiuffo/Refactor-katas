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


    private List<NonPlayerCharacterController> Characters { get; set; }



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
        Characters = new List<NonPlayerCharacterController>(characters);

        
        for (int i = 0; i < Characters.Count; i++)
        {
            if(Characters[i].AttackType == Constants.CharacterAttackTypes.melee)
            {
                Characters[i].Init(_meleeAttackDamage,_healAmount);
            }
            else
            {
                Characters[i].Init( _rangedAttackDamage, _healAmount);

            }
        }

        FindObjectOfType<PlayerCharacterController>().Init();

        Debug.Log("Characters initialized.");

    }

    void SetTargets()
    {
        foreach (var item in Characters)
        {
            if (item.isDead()) continue;
            
            if ( !object.Equals(item.Target,null) && !item.Target.isDead()) continue;

            NonPlayerCharacterController nearTarget = null;
            foreach (var possibleTarget in Characters)
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
