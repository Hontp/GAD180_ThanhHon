using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponCooldownBar : MonoBehaviour
{
    public Gradient g;
    public RectTransform rt;
    private SubmarineFire sub;
    public float health;
    public float initialWidth;
    private Image image;
    public float maxCool;


    //Sound Stuff
    //private SoundManager _soundManager;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        rt = GetComponent<RectTransform>();
        initialWidth = rt.rect.width;
        sub = Utilities.Instance.GetCollection["player"].GetComponent<SubmarineFire>();
        maxCool = 1f;

        //Sound Stuff
        //_soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Camera.main.WorldToScreenPoint( sub.transform.position);

        health = sub.fireCooldownPercent;

        rt.sizeDelta = new Vector2((health / maxCool) * 100, 5);
        image.color = g.Evaluate( (health / maxCool));
    }
}
