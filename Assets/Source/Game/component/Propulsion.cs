using UnityEngine;

public class Propulsion : ShipComponent
{
    [SerializeField]
   private Engine subEngine;

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
