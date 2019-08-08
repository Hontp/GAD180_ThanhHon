using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skynet : MonoBehaviour
{
    [SerializeField]
    private GameObject player = null;

    public List<GameObject> enmenies = new List<GameObject>();
    Timer timer;

    private void Start()
    {
        Utilities.Instance.LoadPrefab("mine", "Prefabs/Mine");
        
    }

    public void SetPlayer( GameObject target)
    {
       if ( target != null)
        {
            for (int i = 0; i < enmenies.Count; i++)
            {
                enmenies[i].GetComponent<Agent>().Target = target;
            }
        }
    }

   public Vector3 GenerateRandom(Camera cam)
    {
        Vector3 randVec = new Vector3(Random.Range(-cam.pixelWidth, cam.pixelWidth), 
            Random.Range(-cam.pixelHeight, cam.pixelHeight));


        return cam.ScreenToWorldPoint(randVec);
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (player != null)
            SetPlayer(player);
    }
}
