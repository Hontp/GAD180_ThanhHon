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

    public override void Execute(Vector3 target, float cooldownTime)
    {
        float dist = Vector2.Distance(target, agent.transform.position);

        if (!checkBehaviour())
            return;

        if (cooldownTime > 0)
            return;

        if (dist != 0)
        {         
            agent.Move(target, dist);
        }

        base.Execute(target, cooldownTime);
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
