using System.Collections.Generic;
using UnityEngine;

public class Utilities : Singleton<Utilities>
{
    // all game objects are stoed in this collection
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
    /// Creates a game object from a prefab
    /// </summary>
    /// <param name="objectName">the name for the game object</param>
    /// <param name="prefabPath"> the path to the prefab</param>
    public void CreateGameObject(string objectName, string prefabPath)
    {
        GameObject obj = null;

        obj = Resources.Load(prefabPath, typeof(GameObject)) as GameObject;

        if (obj != null)
        {

            objectCollection.Add(objectName, obj);

        }
        else
        {
            Debug.Log("Unable to create game object" +"\nName: " + objectName + "\nPath: " + prefabPath);
        }
    }

    /// <summary>
    /// Instantiate and return a reference to the game object
    /// will return null if the object doesnt exist
    /// </summary> 
    /// <param name="gameObj"> the reference to the game object</param>
    /// <param name="objName"> the name of the game object</param>
    /// <param name="position"> the name of the game object</param>
    /// /// <param name="rotation"> the rotation of the game object</param>
    public void InstantiateGameObject(ref GameObject gameObj, string objName, 
        Vector2 position = default, Quaternion rotation = default)
    {
        gameObj = null;

        if (objectCollection.ContainsKey(objName))
        {
           gameObj = Object.Instantiate(objectCollection[objName], 
               new Vector3(position.x, position.y, 0), 
               rotation);
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
