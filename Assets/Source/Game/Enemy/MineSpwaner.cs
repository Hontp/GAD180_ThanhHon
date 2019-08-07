using System.Collections.Generic;
using UnityEngine;

public class MineSpwaner :Spawner
{
    public int MaxSpawn = 9;
    public float SpwanTime = 10.0f;

    private Timer spawnTimer = new Timer();

    public override void Start()
    {
        spawnTimer.Init();
        spawnTimer.Count = SpwanTime;

        base.Start();
    }

    public override void Update()
    {

        if (spawnTimer.Count <= 0 && spwanCount <= MaxSpawn)
        {
            int rand = Random.Range(0, 6);

            if (currentSpwanObject != null)
                Utilities.Instance.InstantiateGameObject(currentSpwanObject, spawnPoints[rand].position, transform.rotation);

            foreach (KeyValuePair<string, GameObject> mine in Utilities.Instance.GetCollection)
            {
                if (mine.Value.GetComponent<Mine>() != null)
                    mine.Value.GetComponent<Mine>().Target = Utilities.Instance.GetCollection["player"];
            }

            spwanCount++;

            spawnTimer.Count = SpwanTime;
        }

        spawnTimer.Update();

        base.Update();
    }
}
