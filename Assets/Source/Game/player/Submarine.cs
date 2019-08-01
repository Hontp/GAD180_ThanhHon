using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SubmarineFire))]
[RequireComponent(typeof(SubmarineMovement))]

public class Submarine : Ship
{
    private string[] s_hulls = { "Art/shipParts/Hull_1", "Art/shipParts/Hull_2", "Art/shipParts/Hull_3" };
    private string[] s_weapons = { "Art/shipParts/Weap_1", "Art/shipParts/Weap_2", "Art/shipParts/Weap_3" };
    private string[] s_propulsions = { "Art/shipParts/Prop_1", "Art/shipParts/Prop_2", "Art/shipParts/Prop_3"};

    [SerializeField]
    private ComponentStats[] hullStats = new ComponentStats[3];
    [SerializeField]
    private ComponentStats[] weaponStats = new ComponentStats[3];
    [SerializeField]
    private ComponentStats[] propulsionStats = new ComponentStats[3];

    public enum Comp { HULL,WEAPON,PROPULSION};

    [SerializeField]
    private int health;
    [SerializeField]
    private int speed;
    [SerializeField]
    private int power;
    [SerializeField]
    private int handling;

    public int ship;
    public int hull;
    public int prop;


    public override void Initialize()
    {
        // load sprites for sub components


        // scale the submarine
        // transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);

        setWeapon(ship);
        setHull(hull);
        setPropulsion(prop);

        base.Initialize();
    }

    // weapon is from 1 - 3
    // please dont put in a 0 we aren't friends if you do
    // Sets the Sprite and the stats associated with the submarine
    public void setWeapon(int weapon)
    {
        SetSprite("weapon", s_weapons[weapon - 1]);
        GetShipComponent("weapon").comp = weaponStats[weapon - 1];
        GetShipComponent("weapon").reload();
        setComponentStats();
    }

    // hull is from 1 - 3
    // please dont put in a 0 we aren't friends if you do
    // Sets the Sprite and the stats associated with the hull
    public void setHull(int hull)
    {
        SetSprite("hull", s_hulls[hull - 1]);
        GetShipComponent("hull").comp = hullStats[hull - 1];
        GetShipComponent("hull").reload();
        setComponentStats();
    }

    // weapon is from 1 - 3
    // please dont put in a 0 we aren't friends if you do
    // Sets the Sprite and the stats associated with the submarine
    public void setPropulsion(int propulsion)
    {
        SetSprite("propulsion", s_propulsions[propulsion - 1]);
        GetShipComponent("propulsion").comp = propulsionStats[propulsion - 1];
        GetShipComponent("propulsion").reload();
        setComponentStats();
    }





    // Call this when the configuration of the ship components changes
    public void setComponentStats()
    {

        health = GetShipComponent("hull").Health + GetShipComponent("weapon").Health + GetShipComponent("propulsion").Health;
        speed =    GetShipComponent("hull").Speed + GetShipComponent("weapon").Speed + GetShipComponent("propulsion").Speed;
        power =    GetShipComponent("hull").Power + GetShipComponent("weapon").Power + GetShipComponent("propulsion").Power;
        handling = GetShipComponent("hull").Handling + GetShipComponent("weapon").Handling + GetShipComponent("propulsion").Handling;

        //GetComponent<SubmarineFire>().setPower(power);
        GetComponent<SubmarineMovement>().setSpeed(speed);
        GetComponent<SubmarineMovement>().setHandling(handling);
        ShipsHealth = health * 25 + 100;

        //GetComponent<SubmarineFire>().projectileIndex = GetShipComponent("weapon").index;

    }

    public string getHullPath(int index)
    {
        return "";
    }
    public string getWeaponPath(int index)
    {
        return "";
    }
    public string getPropulsionPath(int index)
    {
        return "";
    }
    

    public override void Update()
    {

        if (ShipsHealth <= 0)
        {
            Destroy(gameObject);
        }
        base.Update();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Hit player");

        }
    }
}
