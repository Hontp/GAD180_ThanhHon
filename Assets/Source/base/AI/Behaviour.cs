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

    public virtual void Execute(Transform target) { }
    public virtual bool checkBehaviour() { return false; }
}
