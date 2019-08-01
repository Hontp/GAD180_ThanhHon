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

    public void setAgent(Agent driver)
    {
        this.agent = driver;
    }

    public void setRange(float val)
    {
        detectionRange = 0;
    }

    public float Distance()
    {
         return heading.magnitude;
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
        return heading / Distance();
    }

    public virtual void Execute(ref Behaviour behaviour, Transform target) { }
    public virtual bool checkBehaviour() { return false; }
}
