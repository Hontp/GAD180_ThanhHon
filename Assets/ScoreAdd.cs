using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAdd : MonoBehaviour
{
    // Start is called before the first frame update
    public int scoreIncrement;
    public SDTK gameManager;
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<SDTK>();

        gameManager.incrementScore(scoreIncrement);

    }

    



}
