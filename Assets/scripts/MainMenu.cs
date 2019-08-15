using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class MainMenu : MonoBehaviour
{
    public string newGameScene;
    public GameObject sub;
    public GameObject p, w, h;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGame()
    {
        string path = Application.dataPath + "/save/save.txt";
        string[] thing = new string[1];
        thing[0] = (w.GetComponent<ImageSelection>().itemSpot+1).ToString() + "," + (h.GetComponent<ImageSelection>().itemSpot+1).ToString() + "," + (p.GetComponent<ImageSelection>().itemSpot+1).ToString();
        if(File.Exists(path))
        {
            File.Delete(path);
            //File.Create(path);
        }
        else
        {
            //File.Create(path);
        }
        File.WriteAllLines(path, thing);
        SceneManager.LoadScene(newGameScene);

    }

    public void Hanger()
    {
        SceneManager.LoadScene(newGameScene);
    }
    
    public void Menu()
    {
        SceneManager.LoadScene(newGameScene);
    }
    

    public void ExitGame()
        {
        Application.Quit();
        }
}
