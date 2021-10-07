using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer: MonoBehaviour
{

    public Timer()
    {
        timeLeft = 0;
    }

    private float timeLeft;
    public float TimeLeft
    {
        get => this.timeLeft;
        set => this.timeLeft = value;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else timeLeft = 0;
    }
}