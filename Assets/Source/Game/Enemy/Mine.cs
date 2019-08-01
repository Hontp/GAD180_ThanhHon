using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Agent
{

    [SerializeField]
    Aggro current;

    [SerializeField]
    float speed = 1.0f;


    [SerializeField]
    float activeRange = 20f;

    [SerializeField]
    float attackRange = 1f;

    public override void Initialize()
    {
        current = new Aggro("Aggro", this, activeRange, attackRange);
        CurrentBehaviour = current;

        base.Initialize();  
    }

    public override void Execute()
    {
       
        if (CurrentBehaviour != null)
        {
            Transform playerTransform = Target.transform;
            Behaviour aiBehaviour = current;

            CurrentBehaviour.Execute(ref aiBehaviour, playerTransform);
        }

    }

    public override void Move(Vector2 target, float distance)
    {

        transform.position = Vector2.MoveTowards(transform.position, target, distance * speed * Time.deltaTime);

        base.Move(target, distance);
    }

    public override void Attack()
    {
        Debug.Log(this.name + "is attacking the player");

        base.Attack();
    }

    public override void Update()
    {
        if (Target != null)
        {
            Execute();
        }
    }
}
