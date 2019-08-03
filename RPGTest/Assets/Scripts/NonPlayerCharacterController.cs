using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;

public class NonPlayerCharacterController : Character
{

    public Attackable Target { get; set; }

    private float _targetDistance;
    private float AttackDamage { get; set; }
    private float HealAmount { get; set; }

  
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
        if (isDead()) return;
        
        if (Target != null)
        {
            _targetDistance = Vector3.Distance(this.transform.position, Target.transform.position);
        }
        else
        {
            _targetDistance = 0;
        }
    }

    private void Move()
    {
        if (isDead()) return;
       
        if (Target == null) return;
        
        this.transform.LookAt(Target.transform);

        if (_targetDistance <= AttackRange) return;
           
        this.transform.position+=(
            this.transform.forward * Time.deltaTime );
        
    }

    private void AttackEnemy()
    {
        if (isDead()) return;
        
        if(Target == null || Target.isDead()) return;
        
        if (_targetDistance > AttackRange) return;
        
        var damage = AttackDamage * Time.deltaTime;
        DealDamage(Target,damage,_targetDistance);

        if (!Target.isDead()) return;
        
        Level++;
        Debug.Log(string.Format("{0} killed {1} ",
            this.gameObject.name,Target.gameObject.name ));
        
        
    }

    private void HealHimself()
    {
        Heal(HealAmount);
    }
  

    //Public

    public void Init(float attackRange, float attackDamage,float healAmount)
    {
        Health = Constants.MaxCharacterHealth;
        Level = 1;
        AttackDamage = attackDamage;
        AttackRange = attackRange;
        HealAmount = healAmount;

    }

    public void SetTarget(Attackable target)
    {
        Target = target;
    }


}
