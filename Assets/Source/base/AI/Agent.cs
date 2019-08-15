using UnityEngine;

public class Agent : MonoBehaviour
{

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private Behaviour current;

    [SerializeField]
    private Behaviour previous;

    [SerializeField]
    private float coolDown = 0f;

    private void Start()
    {
        Initialize();
    }

    public GameObject Target
    {
        get
        {
            return target;
        }
        set
        {
            target = value;
        }
    }

    public Behaviour CurrentBehaviour
    {
        get
        {
            return current;
        }
        set
        {
            current = value;
        }
    }

    public Behaviour PreviousBehaviour
    {
        get
        {
            return previous;
        }
        set
        {
            previous = value;
        }
    }

    public float SetCoolDown
    {
        set
        {
            coolDown = value;
        }
    }

    public virtual void Update()
    {
        
        if (current != null)
        {
            Execute();
        }

    }

    public virtual void Move( Vector2 target, float distance) { }
    public virtual void Attack() { }
    public virtual void Initialize() {}
    public virtual void Execute() { }
  
}
