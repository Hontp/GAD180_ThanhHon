using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : Agent
{
    List<Behaviour> listBehaviour = new List<Behaviour>();

    [SerializeField]
    float speed = 1.0f;

    [SerializeField]
    float activeRange = 5f;

    [SerializeField]
    float attackRange = 1f;

    public override void Initialize()
    {
        listBehaviour.Add(new Aggro("Aggro", this, activeRange, attackRange));
        listBehaviour.Add(new Idle("Idle", this, 0, 0));

        CurrentBehaviour = listBehaviour[1];

        base.Initialize();  
    }

    public override void Execute()
    {
       
        if (CurrentBehaviour != null)
        {
            Transform playerTransform = Target.transform;
            Behaviour aiBehaviour = listBehaviour[1];

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

    public int Comparator(int left, int right)
    {
        if ( left < right)
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }

    public override void Update()
    {
        if (Target != null)
        {
            Execute();
        }
    }
}
