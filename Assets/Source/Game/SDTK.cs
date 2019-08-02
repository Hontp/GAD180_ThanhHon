using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// main program entry point
/// </summary>
public class SDTK : MonoBehaviour
{

    public CameraManager cm;

    public int score;
    public Text scoreText;
    // initialze the game
    void Start()
    {
        // load the prefab
        Utilities.Instance.LoadPrefab("player", "Prefabs/Submarine_Test");

        //create an instance of the player
        Utilities.Instance.InstantiateGameObject("player");

        Utilities.Instance.GetCollection["player"].GetComponent<Submarine>().ShipsHealth = 100f;

        // set the AI target to the player
        transform.GetComponent<Skynet>().SetPlayer(Utilities.Instance.GetCollection["player"]);

        cm.focusTarget = Utilities.Instance.GetCollection["player"].GetComponent<Rigidbody2D>();
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
