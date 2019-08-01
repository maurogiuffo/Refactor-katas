using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGCharacterController : MonoBehaviour
{
    private float _health = Constants.MaxCharacterHealth;

    private int _level = 1;

    [SerializeField]
    private Constants.CharacterAttackTypes _Attacktype ;


    private RPGCharacterController _target = null;

    private int _characterId;
    private float _attackDamage = 0;
    private float _attackRange = 0;
    private float _healAmount = 0;
    private float _velocity = 0;

    private Constants.CharacterStates _state = Constants.CharacterStates.alive;

    private float _targetDistance;

    public int CharacterId { get => _characterId; }
    public Constants.CharacterStates State { get => _state;}
    public RPGCharacterController Target { get => _target; }
    public int Level { get => _level; }
    public Constants.CharacterAttackTypes Attacktype { get => _Attacktype; }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CalculateTargetDistance();
        Move();
        AttackEnemy();
        HealHimself();
    }


    private void CalculateTargetDistance()
    {
        if (_state == Constants.CharacterStates.alive)
        {
            if (_target != null)
            {
                _targetDistance = Vector3.Distance(this.transform.position, _target.transform.position);
            }
            else
            {
                _targetDistance = 0;
            }
        }
    }

    private void Move()
    {
        if (_state == Constants.CharacterStates.alive)
        {
            if (_target != null)
            {
                this.transform.LookAt(_target.transform);

                if (_targetDistance > _attackRange)
                {
                   
                    this.transform.position+=(
                        this.transform.forward * Time.deltaTime * _velocity);

                }
            }
        }
    }

    private void AttackEnemy()
    {
        if (_state == Constants.CharacterStates.alive)
        {
            if(_target != null && _target.State == Constants.CharacterStates.alive)
            {
                if (_targetDistance <= _attackRange)
                {
                    var damage = _attackDamage * Time.deltaTime;

                    if (this.Level + 5 > _target.Level)
                        damage *= 1.5f;
                    else
                        if (this.Level - 5 < _target.Level)
                            damage *= 0.5f;

                    _target.ReciveDamage(damage);

                    if (_target.State == Constants.CharacterStates.dead)
                    {
                        _level++;
                        Debug.Log(string.Format("CharacterId({0}) killed CharacterId({1}) ",_characterId,_target.CharacterId));
                    }
                }
            }
        }
    }

    private void HealHimself()
    {
        if (_state == Constants.CharacterStates.alive)
        {
            _health += _healAmount * Time.deltaTime;

            if (_health > Constants.MaxCharacterHealth)
                _health = Constants.MaxCharacterHealth;
        }
    }
    
   

    //Public

    public void Init(int characterId,float attackRange, float attackDamage,float healAmount,float velocity)
    {
        _characterId = characterId;
        _health = Constants.MaxCharacterHealth;
        _state = Constants.CharacterStates.alive;
        _level = 1;
        _attackDamage = attackDamage;
        _attackRange = attackRange;
        _healAmount = healAmount;
        _velocity = velocity;

        this.gameObject.name = string.Format("Character({0})",_characterId);
    }

    public void SetTarget(RPGCharacterController target)
    {
        _target = target;
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
