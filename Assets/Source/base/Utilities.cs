using System.Collections.Generic;
using UnityEngine;

public class Utilities : Singleton<Utilities>
{
    // all prefab are stored in this collection
    private Dictionary<string, GameObject> prefabCollection = new Dictionary<string, GameObject>();

    // all game objects instance are stored in this collection
    private Dictionary<string, GameObject> objectCollection = new Dictionary<string, GameObject>();

    /// <summary>
    /// public method creates the sprite from the image
    /// </summary>
    /// <param name="spritePath">the path to the image</param>
    /// <returns>returns the sprite</returns>
    public Sprite CreateSprite(string spritePath)
    {
        return Resources.Load<Sprite>(spritePath);
    }

    /// <summary>
    /// Load Prefab to Memory
    /// </summary>
    /// <param name="prefabName">the id of the prefab</param>
    /// <param name="prefabPath">the parth to the prefab</param>
    public void LoadPrefab(string prefabName, string prefabPath)
    {
        GameObject prefab = null;

        if (!prefabCollection.ContainsKey(prefabName))
        {
            prefab = Resources.Load(prefabPath, typeof(GameObject)) as GameObject;

            if (prefab != null)
            {
                prefabCollection.Add(prefabName, prefab);
            }
            else
            {
                Debug.Log("Prefab Does not exists" + "\nName:" + prefabName + "\nPath: " + prefabPath);
            }
        }
        else
        {
            Debug.Log("This Prefab already exists in collection " + prefabName);
        }
    }

    /// <summary>
    /// Instantiate a game object from the prefab collection
    /// </summary> 
    /// <param name="objName"> the name of the game object</param>
    /// <param name="position"> the name of the game object</param>
    /// <param name="rotation"> the rotation of the game object</param>
    public void InstantiateGameObject(string objName,
        Vector2 position = default, Quaternion rotation = default)
    {
       GameObject gameObj = null;

        if (prefabCollection.ContainsKey(objName))
        {
           gameObj = Object.Instantiate(prefabCollection[objName], 
               new Vector3(position.x, position.y, 0), 
               rotation);

            if (!objectCollection.ContainsKey(objName))
                objectCollection.Add(objName, gameObj);
        }
    }

    /// <summary>
    /// get the game object collection container
    /// </summary>
    public Dictionary<string, GameObject> GetCollection
    {
        get
        {
            return objectCollection;
        }
    }
}
