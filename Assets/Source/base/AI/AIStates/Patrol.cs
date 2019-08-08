using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : Behaviour
{
    public Patrol()
    {
        Name = "Patrol";
        detectionRange = 5f;
        attackRange = 1.5f;
        agent = null;

    }

    public Patrol(string name, Agent driver, float activeRange = 0, float attkRange = 0)
    {
        Name = name;
        detectionRange = activeRange;
        attackRange = attkRange;
        agent = driver;

    }

    public override void Execute(Transform target)
    {
        float dist = Vector2.Distance(target.transform.position, agent.transform.position);

        if (!checkBehaviour())
            return;

      /*  if (dist <= detectionRange)
        {
            agent.Move(target.position, dist);
        }
        else if (dist <= attackRange)
        {
            agent.Attack();
        }*/

        base.Execute(target);
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
