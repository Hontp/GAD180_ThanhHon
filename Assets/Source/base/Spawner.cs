using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    protected List<Transform> spawnPoints = new List<Transform>();

    protected int spwanCount = 0;

    [SerializeField]
    protected string currentSpwanObject = null;

    public virtual void Start()
    {        
        foreach ( Transform point in transform)
        {
            spawnPoints.Add(point);
        }
    }

    public void Spawn(string name)
    {
        currentSpwanObject = name;
    }

    public virtual void Update(){ }
}
