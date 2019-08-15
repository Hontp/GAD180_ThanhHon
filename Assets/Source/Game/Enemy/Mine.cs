using UnityEngine;

public class Mine : Agent
{

    Timer cooldownTimer = new Timer();

    [SerializeField]
    Behaviour current;

    [SerializeField]
    float speed = 1.0f;

    [SerializeField]
    float activeRange = 5.5f;

    [SerializeField]
    float attackRange = 2.5f;

    [SerializeField]
    private float relativeRange = 4.5f;

    private Vector3 patrolPath;

    public override void Initialize()
    {
        current = new Patrol("patrol", this, activeRange, attackRange);
        CurrentBehaviour = current;
        PreviousBehaviour = CurrentBehaviour;

        cooldownTimer.SetTime(2.5f);

        patrolPath = GenerateRandom(Camera.main);

        base.Initialize();  
    }

    public override void Execute()
    {
       
        if (CurrentBehaviour != null)
        {
            Transform playerTransform = Target.transform;
            Behaviour aiBehaviour = current;

            float dist = Vector2.Distance(playerTransform.position, transform.position);

            if (CurrentBehaviour.GetType() == typeof(Aggro) && dist <= activeRange)
            {
                CurrentBehaviour.Execute(playerTransform.position);
            }
            else if (CurrentBehaviour.GetType() == typeof(Patrol) && dist <= activeRange)
            {
                CurrentBehaviour.Execute(patrolPath);

                if (Vector2.Distance(patrolPath, transform.position) <= relativeRange)
                {
                    patrolPath = GenerateRandom(Camera.main);

                    CurrentBehaviour.Execute(patrolPath, cooldownTimer.GetDownTime());

                    if (dist <= activeRange)
                    {
                        CurrentBehaviour = new Aggro("aggro", this, activeRange, attackRange);
                    }
                }

            }
        }
     
    }

    public Vector3 GenerateRandom(Camera cam)
    {
        Vector3 randVec = new Vector3(Random.Range(-cam.pixelWidth, cam.pixelWidth),
            Random.Range(-cam.pixelHeight, cam.pixelHeight));


        return cam.ScreenToWorldPoint(randVec);

    }

    public override void Move(Vector2 target, float distance)
    {

        transform.position = Vector2.MoveTowards(transform.position, target, distance * speed * Time.deltaTime);

        base.Move(target, distance);
    }

    public override void Attack()
    {
        Debug.Log(this.name + "is attacking the player");

        base.Attack();
    }

    public override void Update()
    {
        if (Target != null)
        {
            Execute();
        }
    }

   
}
