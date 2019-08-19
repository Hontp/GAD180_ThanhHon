using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ImageSelection : MonoBehaviour
{
    public Image SelectionImage;
    public List<Sprite> ItemList = new List<Sprite>();
    public int itemSpot;
    SoundManager _soundManager;

    public void RightSelection()
    {
        Debug.Log("Right");
        if (itemSpot < ItemList.Count - 1)
        {            
            itemSpot++;
            SelectionImage.sprite = ItemList[itemSpot];
            Debug.Log(itemSpot + " " + ItemList[itemSpot].name);
            //Debug.Log(itemSpot + " = THIS ONE!!");
            _soundManager._menuClick.start();
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
            _soundManager._menuClick.start();
        }
    }


    

    // Start is called before the first frame update
    void Start()
    {
        _soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void WeaponSelect()
    {
        _soundManager._playerWeapon = itemSpot;
    }
}
