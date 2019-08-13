using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerSound : MonoBehaviour
{

    FMODUnity.StudioEventEmitter propEmitter;

    bool propState;
    public bool fire;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<FMODUnity.StudioEventEmitter>().Play();
        GetComponent<FMODUnity.StudioEventEmitter>().Stop();


        propEmitter = GetComponent<FMODUnity.StudioEventEmitter>();

        
        propState = false;
        fire = false;
    }

    // Update is called once per frame
    void Update()
    {
        PropCheck();
    }


    void PropCheck()
    {
        if(Input.GetKey("w"))
        {
            if (propState != true)
            {
                propEmitter.SetParameter("PlayerProp", 0);
                propEmitter.Play();
                propState = true;
            }
        }
        else
        {
            if (propState != false)
            {
                propEmitter.SetParameter("PlayerProp", 1);
                propState = false;
                Debug.Log("Did it stop?!");
            }
        }
    }

    void FireCheck()
    {
        if(fire == true)
        {

        }
    }
}
