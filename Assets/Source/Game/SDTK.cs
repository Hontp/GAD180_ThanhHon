using UnityEngine;

/// <summary>
/// main program entry point
/// </summary>
public class SDTK : MonoBehaviour
{

    public CameraManager cm;
    // the player container object
    GameObject player = null;

    // initialze the game
    void Start()
    {
        // create player
        Utilities.Instance.CreateGameObject("player", "Prefabs/Submarine_Test");
        Utilities.Instance.InstantiateGameObject(ref player, "player");

        // set the AI target to the player
        transform.GetComponent<Skynet>().SetPlayer(player);

        cm.focusTarget = player.GetComponent<Rigidbody2D>();
    }

}
