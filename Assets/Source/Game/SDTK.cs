using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// main program entry point
/// </summary>
public class SDTK : MonoBehaviour
{

    public CameraManager cm;
    // the player container object
    GameObject player = null;
    public int score;
    public Text scoreText;
    // initialze the game
    void Start()
    {
        // create player
        Utilities.Instance.CreateGameObject("player", "Prefabs/Submarine_Test");
        Utilities.Instance.InstantiateGameObject(ref player, "player");
        player.GetComponent<Submarine>().ShipsHealth = 100f;
        // set the AI target to the player
        transform.GetComponent<Skynet>().SetPlayer(player);

        cm.focusTarget = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        scoreText.text = score.ToString(); 
    }


    public void incrementScore(int scoreAdd)
    {
        score += scoreAdd;
    }


}
