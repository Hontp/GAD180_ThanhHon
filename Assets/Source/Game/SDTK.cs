using UnityEngine;

/// <summary>
/// main program entry point
/// </summary>
public class SDTK : MonoBehaviour
{
    // the player container object
    GameObject player = null;

    // initialze the game
    private void Start()
    {
        // create player
        Utilities.Instance.CreateGameObject("player", "Prefabs/Submarine_Test");
        Utilities.Instance.InstantiateGameObject(ref player, "player");

    }

}
