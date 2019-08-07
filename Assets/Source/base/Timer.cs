using UnityEngine;

public class Timer : Singleton<Timer>
{

    private float timer = 5.0f;
    private float time = 0;

    public void Init()
    {
        time = timer;
    }

    public float Count
    {
        get
        {
            return time;
        }
        set
        {
            timer = value;
        }
    }

    public void Update()
    {
        time -= Time.deltaTime;
    }
}
