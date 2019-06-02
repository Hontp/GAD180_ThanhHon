 using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    // stores the components for all ship parts
    private  Dictionary<string, ShipComponent> shipComponents = new Dictionary<string, ShipComponent>();

    //ships HP
    [SerializeField]
    private float shipHP = 0;

    /// <summary>
    /// this start method is private, it initializes the all ships parts renderers, pariticle systems 
    /// then calls the Initialize method, any ship code should go in Initialize instead 
    /// </summary>
    private void Start()
    {
        // get sprite renderer and transform component from the all parts of the ship
        foreach ( Transform part in transform)
        {
            // skip to next loop if the part render is already present in this collection
            if (shipComponents.ContainsKey(part.name))
                break;
                          
            if (part.name  == "hull")
            {
                ShipComponent comp = new ShipComponent
                {
                    ComponentTransform = part,
                    ComponentRenderer = part.GetComponent<SpriteRenderer>()
                };

                shipComponents.Add("hull", comp);
            }
            else if (part.name == "weapon")
            {
                ShipComponent comp = new ShipComponent
                {
                    ComponentTransform = part,
                    ComponentRenderer = part.GetComponent<SpriteRenderer>()
                };

                shipComponents.Add("weapon", comp);
            }
            else if ( part.name == "propulsion")
            {
                ShipComponent comp = new ShipComponent
                {
                    ComponentTransform = part,
                    ComponentRenderer = part.GetComponent<SpriteRenderer>()
                };

                shipComponents.Add("propulsion", comp);
            }
        }

        Initialize();
    }

   

    /// <summary>
    /// Get the Renderer for the ship part returns null if doesnt exist
    /// </summary>
    /// <param name="renderer">the reference to the renderer</param>
    /// <param name="rendererName">the renderer's name</param>
    public void GetRenderer(ref ShipComponent renderer, string rendererName)
    {
        renderer = null;

        if (shipComponents.ContainsKey(rendererName))
        {
            renderer = shipComponents[rendererName];
        }
    }

     
    /// <summary>
    /// Set the part sprite for the ship
    /// </summary>
    /// <param name="partName">set the name for this sprite</param>
    /// <param name="partPath">set the image of this part</param>
    public void SetSprite(string partName, string partPath)
    {        
        if (shipComponents.ContainsKey(partName))
        {
            // if the part entry already exists then assign the new value to it
            shipComponents[partName].ComponentSprite = 
                Utilities.Instance.CreateSprite(partPath);
        }
        else
        {
            // create a new part entry if it doesnt exists
            ShipComponent comp = new ShipComponent
            {
                ComponentSprite = Utilities.Instance.CreateSprite(partPath)
            };

            // add entry to the collection
            shipComponents.Add(partName, comp);

        }
    }

    /// <summary>
    /// Get the ship component
    /// </summary>
    /// <param>return the ship component</param>
    public ShipComponent GetShipComponent(string partName)
    {
        
        ShipComponent part = null;

        if (shipComponents.ContainsKey(partName))
        {
            part = shipComponents[partName];
        }

        return part;
        
    }

    /// <summary>
    /// Get the transform of a specific component in the ship
    /// </summary>
    /// <param name="partName">the name of the component</param>
    /// <returns>rfeturn component if it exists</returns>
    public Transform GetChildTransform(string partName)
    {
        Transform comp = null;

        foreach (Transform part in transform)
        {
            if (part.name == partName)
                comp = part;         
        }

        return comp;
    }

    /// <summary>
    /// Get or Set the ships health
    /// </summary>
    public float ShipsHealth
    {
        get
        {
            return shipHP;
        }
        set
        {
            shipHP = value;
        }
    }

    /// <summary>
    /// Initialize any ship code in this method
    /// </summary>
    public virtual void Initialize() { }

    /// <summary>
    /// Update the sprite and renderers
    /// </summary>
    public virtual void Update()
    {
        // assign all ship parts to the renderer
        foreach (KeyValuePair<string, ShipComponent> renderer in shipComponents)
        {
            if (shipComponents.ContainsKey(renderer.Key) && 
                renderer.Value.ComponentRenderer != null)
            {
                renderer.Value.ComponentRenderer.sprite = shipComponents[renderer.Key].ComponentSprite;
            }
        }
    }

}

