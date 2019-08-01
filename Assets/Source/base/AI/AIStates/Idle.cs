using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : Behaviour
{
    public Idle()
    {
        Name = "Idle";
        detectionRange = 5f;
        attackRange = 1f;
        agent = null;
    }

    public Idle(string name, Agent driver, float activeRange = 0, float attkRange = 0)
    {
        Name = name;
        detectionRange = activeRange;
        attackRange = attkRange;
        agent = driver;
    }
    public override void Execute(ref Behaviour behaviour, Transform target)
    {
        base.Execute(ref behaviour, target);
    }

    
}
