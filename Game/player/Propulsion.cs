using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propulsion : ShipComponent
{
    [SerializeField]
    private int health;

    [SerializeField]
    private int speed;

    [SerializeField]
    private int power;

    [SerializeField]
    private int handling;

    [SerializeField]
    Engine subEngine;

    public void SetEngine( Engine engine)
    {
        subEngine = engine;
    }

    public Engine Engine()
    {
        return subEngine;
    }
}
