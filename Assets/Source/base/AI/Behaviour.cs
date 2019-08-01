using UnityEngine;

public abstract class Behaviour
{

    [SerializeField]
    protected string Name;

    [SerializeField]
    protected float detectionRange = 0;

    [SerializeField]
    protected float attackRange = 0;

    [SerializeField]
    protected Agent agent = null;

    protected Vector3 heading = default;
    protected Vector3 direction = default;
    protected float dist = 0;

    public void setAgent(Agent driver)
    {
        this.agent = driver;
    }

    public bool CheckRange()
    {
        bool inRange = false;

        if ( heading.sqrMagnitude < detectionRange * detectionRange)
        {
            inRange = true;
        }

        return inRange;
    }

    public Vector2 Direction()
    {
        return heading / (heading.magnitude);
    }

    public string BehaviourName
    {
        get
        {
            return Name;
        }
        set
        {
            Name = value;
        }
    }
    public float DetectionRange
    {
        get
        {
            return detectionRange;
        }
        set
        {
            detectionRange = value;
        }
    }

    public float Distance
    {
        get
        {
            return dist;
        }
        set
        {
            dist = value;
        }
    }

    public virtual void Execute(ref Behaviour behaviour, Transform target)
    {
        dist = Vector2.Distance(target.transform.position, agent.transform.position);

        if (dist < detectionRange)
        {
            if (dist <= attackRange)
                agent.Attack();
            else
                agent.Move(target.position, dist);
        }
    }

    public virtual bool checkBehaviour()
    {
        if (agent.GetComponent<SpriteRenderer>().isVisible)
        {
            return true;
        }

        return false;
    }
}
