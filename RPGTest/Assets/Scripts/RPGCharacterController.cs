using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGCharacterController : MonoBehaviour
{

    [SerializeField]
    protected Constants.CharacterAttackTypes _Attacktype;

    protected Constants.CharacterStates _state = Constants.CharacterStates.alive;

    protected float _health = Constants.MaxCharacterHealth;
    protected int _level = 1;
    protected float _attackDamage = 0;
    protected float _attackRange = 0;
    protected float _healAmount = 0;
    protected float _velocity = 0;
    protected int _characterId;

    public Constants.CharacterStates State { get => _state; }
    public int Level { get => _level; }
    public Constants.CharacterAttackTypes Attacktype { get => _Attacktype; }
    public int CharacterId { get => _characterId; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ReciveDamage(float damage)
    {
        if (_state == Constants.CharacterStates.alive)
        {
            _health -= damage;

            if (_health < 0)
            {
                _health = 0;
                _state = Constants.CharacterStates.dead;
            }
        }
    }

}
