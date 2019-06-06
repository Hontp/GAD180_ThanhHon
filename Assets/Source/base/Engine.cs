using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    // store the components for the propulsion
    private Dictionary<string, EngineComponent> propComponents = new Dictionary<string, EngineComponent>();

    // engine particle system
    private ParticleSystem propParticles;

    /// <summary>
    /// this start method is private, it initializes the all engine component renderers, pariticle systems 
    /// then calls the Initialize method, any specific engine code should go in Initialize instead 
    /// </summary>
    private void Start()
    {
        // get the sprite renderer and transform for the main propulsion       
        EngineComponent engine = new EngineComponent
        {
            ComponentTransform = transform,
            ComponentRenderer = transform.GetComponent<SpriteRenderer>()
        };

        propComponents.Add("engine", engine);


        // get the sprite renderer and transform for the engine components
        foreach (Transform part in transform)
        {
            // get the engine effects renderer
            if (part.name == "engineEffect")
            {
                EngineComponent comp = new EngineComponent
                {
                    ComponentTransform = part,
                    ComponentRenderer = part.GetComponent<SpriteRenderer>()
                };

                propComponents.Add("engineEffect", comp);
            }
            // get the particle system for engine effects
            else if (part.name == "engineParticles")
            {
                propParticles = part.GetComponent<ParticleSystem>();

                // set the particle system to the off state
                ParticleSystem.EmissionModule emission = propParticles.emission;
                emission.enabled = false;

            }

        }

        Initialize();
    }

    /// <summary>
    /// Set the part sprite for the engine
    /// </summary>
    /// <param name="partName">set the name for this sprite</param>
    /// <param name="partPath">set the image of this part</param>
    public void SetSprite(string partName, string partPath)
    {
        if (propComponents.ContainsKey(partName))
        {
            // if the part entry already exists then assign the new value to it
            propComponents[partName].ComponentSprite =
                Utilities.Instance.CreateSprite(partPath);
        }
        else
        {
            // create a new part entry if it doesnt exists
            EngineComponent comp = new EngineComponent
            {
                ComponentSprite = Utilities.Instance.CreateSprite(partPath)
            };

            // add entry to the collection
            propComponents.Add(partName, comp);

        }
    }

    /// <summary>
    /// Set the state of the particle emitter
    /// </summary>
    /// <param name="state">toggle the emitter on / off</param>
    public void SetParticleEmitterActive(bool state)
    {
        ParticleSystem.EmissionModule emitter;

        if (propParticles != null)
        {
            emitter = propParticles.emission;

            emitter.enabled = state;
        }
    }

    /// <summary>
    /// Initialize any engine code in this method
    /// </summary>
    public virtual void Initialize() { }

    /// <summary>
    /// Render all engine components
    /// </summary>
    public virtual void Update()
    {
        foreach (KeyValuePair<string, EngineComponent> renderer in propComponents)
        {
            if (propComponents.ContainsKey(renderer.Key))
            {
                renderer.Value.ComponentRenderer.sprite =
                propComponents[renderer.Key].ComponentSprite;
            }
        }
    }
}
