using UnityEngine;

public class Propulsion : ShipComponent
{
    [SerializeField]
   private Engine subEngine;



    void Start()
    {
        reload();
    }



    public Engine SubEngine
    {
        get
        {
            return subEngine;
        }
        set
        {
            subEngine = value;
        }
    }
}
