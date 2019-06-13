using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submarine : Ship
{
    public override void Initialize()
    {
        // load sprites for sub components
        SetSprite("hull", "Art/shipParts/hull_1");
        SetSprite("weapon", "Art/shipParts/Weap_1");
        SetSprite("propulsion", "Art/shipParts/Prop_1");

        // scale the submarine
        transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);

        base.Initialize();
    }

    public override void Update()
    {

        base.Update();
    }
}
