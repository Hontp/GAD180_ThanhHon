using UnityEngine;

public class Agent : MonoBehaviour
{
    private Collider2D sensor;

    private DecisionTree<Behaviour> decisionTree = new DecisionTree<Behaviour>();

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private Behaviour current;


    private void OnEnable()
    {
        if (transform.GetComponent<Collider2D>() != null)
        {
            SetSensor(transform.GetComponent<Collider2D>());
        }
        else
        {
            Debug.Log("Agent Sensor Object not found");
            return;
        }
    }

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

    public DecisionTree<Behaviour> DecisionTree
    {
        get
        {
            return decisionTree;
        }
        set
        {
            decisionTree = value;
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
    public virtual void SetSensor( Collider2D sensor) { }
    public virtual void Execute() { }
  
}
