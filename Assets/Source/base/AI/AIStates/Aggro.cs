using UnityEngine;

public class Aggro : Behaviour
{

    public Aggro()
    {
        Name = "Aggro";
        detectionRange = 3f;
        attackRange = 1.5f;
        agent = null;

    }

    public Aggro (string name, Agent driver, float activeRange = 0, float attkRange = 0)
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

        if ( dist < detectionRange && dist > attackRange)
        {
            agent.Move(target, dist);            
        }
        else if ( dist <= attackRange )
        {
            agent.Attack();            
        }
        else
        {
            agent.PreviousBehaviour.Execute(target, cooldownTime);
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
