using UnityEngine;

public class Timer
{
    [SerializeField]
    private float coolDown = 5.0f;

    public void SetTime( float timer)
    {
        coolDown = timer;
    }

    public float GetDownTime()
    {
        coolDown -= Time.deltaTime;

        return coolDown;
    }
}
