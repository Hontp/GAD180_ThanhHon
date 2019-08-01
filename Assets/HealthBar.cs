using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Gradient g;
    public RectTransform rt;
    private Submarine sub;
    public float health;
    public float initialWidth;
    private Image image;
    public float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        rt = GetComponent<RectTransform>();
        initialWidth = rt.rect.width;
        sub = Utilities.Instance.GetCollection["player"].GetComponent<Submarine>();
        maxHealth = sub.ShipsHealth;
    }

    // Update is called once per frame
    void Update()
    {
        health = sub.ShipsHealth;

        rt.sizeDelta = new Vector2((health / maxHealth) * initialWidth,100);
        image.color = g.Evaluate(1-(health / maxHealth));
    }
}
