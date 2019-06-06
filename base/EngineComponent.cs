using UnityEngine;

// <summary>
/// the EngineComponent class is a container thats stores a reference to the Transform, SpriteRenderer and the Sprite
/// of this particular part of the engine
/// </summary>
public class EngineComponent
{

    private SpriteRenderer componentRenderer;
    private Transform componentTransform;
    private Sprite componentSprite;
    
    /// <summary>
    /// get /set the renderer for this component
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
    /// get / set the the transform for this component
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
