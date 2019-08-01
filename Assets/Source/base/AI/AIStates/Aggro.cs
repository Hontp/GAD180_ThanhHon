using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aggro : Behaviour
{

    public Aggro()
    {
        Name = "Aggro";
        detectionRange = 10;
        attackRange = 5f;
        agent = null;

    }

    public Aggro (string name, Agent driver, float activeRange = 0, float attkRange = 0)
    {
        Name = name;
        detectionRange = activeRange;
        attackRange = attkRange;
        agent = driver;
    }
   
    public override void Execute(ref Behaviour behaviour, Transform target)
    {
        float dist = Vector2.Distance(target.transform.position, agent.transform.position);

        if (!checkBehaviour())
            return;

        if ( dist >= detectionRange)
        {
            agent.Move(target.position, dist);
        }
        else if ( dist < detectionRange)
        {
            if (dist <= attackRange)
                agent.Attack();
            else
                agent.Move(target.position, dist);
        }

        base.Execute(ref behaviour, target); 
    }

    public override bool checkBehaviour()
    {
        if (agent.GetComponent<SpriteRenderer>().isVisible)
        {
            return true;
        }

        return false;

    }
}
