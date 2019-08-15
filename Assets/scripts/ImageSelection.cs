using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ImageSelection : MonoBehaviour
{
    public Image SelectionImage;
    public List<Sprite> ItemList = new List<Sprite>();
    public int itemSpot;

    public void RightSelection()
    {
        Debug.Log("Right");
        if (itemSpot < ItemList.Count - 1)
        {            
            itemSpot++;
            SelectionImage.sprite = ItemList[itemSpot];
            Debug.Log(itemSpot + " " + ItemList[itemSpot].name);
        }
    }

    public void LeftSelection()
    {
        Debug.Log("Left");
        if (itemSpot > 0)
        {
            itemSpot--;
            SelectionImage.sprite = ItemList[itemSpot];
            Debug.Log(itemSpot + " " + ItemList[itemSpot].name);
        }
    }


    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
