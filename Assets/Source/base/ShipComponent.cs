using UnityEngine;

/// <summary>
/// the ShipComponent class is a contianer thats stores a reference to the Transform, SpriteRenderer and the Sprite
/// of thisp particular part of the ship
/// </summary>
public class ShipComponent
{
    private GameObject componentObject;
    private Transform componentTransform;
    private SpriteRenderer componentRenderer;
    private Sprite componentSprite;
    public ComponentStats comp;

    [Header("Debugging Only")]

    [SerializeField]
    private int health;

    [SerializeField]
    private int speed;

    [SerializeField]
    private int power;

    [SerializeField]
    private int handling;

    public void reload()
    {
        Health = comp.health;
        Speed = comp.speed;
        Power = comp.power;
        Handling = comp.handling;
    }

    /// <summary>
    /// get / set health 
    /// </summary>
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }

    /// <summary>
    /// get /set speed 
    /// </summary>
    public int Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }

    /// <summary>
    /// get /set power
    /// </summary>
    public int Power
    {
        get
        {
            return power;
        }
        set
        {
            power = value;
        }
    }

    /// <summary>
    /// get / set handling
    /// </summary>
    public int Handling
    {
        get
        {
            return handling;
        }
        set
        {
            handling = value;
        }
    }

    /// <summary>
    /// get /set the ship component transform
    /// </summary>
    public Transform ComponentTransform
    {
        get
        {
            return componentTransform;
        }
        set
        {
            componentTransform = value;
        }
    }

    /// <summary>
    /// get set the component object
    /// </summary>
    public GameObject ComponentObject
    {
        get
        {
            return componentObject;
        }
        set
        {
            componentObject = value;
        }
    }

    /// <summary>
    /// get / set the renberer for this component
    /// </summary>
    public SpriteRenderer ComponentRenderer
    {
        get
        {
            return componentRenderer;
        }
        set
        {
            componentRenderer = value;
        }
    }

    /// <summary>
    /// get / set the sprite for this component
    /// </summary>
    public Sprite ComponentSprite
    {
        get
        {
            return componentSprite;
        }
        set
        {
            componentSprite = value;
        }
    }


}
