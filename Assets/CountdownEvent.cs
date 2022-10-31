//EZPZ Interaction Toolkit
//by Matt Cabanag
//created 25 Jul 2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class CountdownEvent : MonoBehaviour
{
    [Header("Clock Parameters")]
    private float clock;
    public bool looping = false;
    public UnityEvent onClockZero;
    public float[] timeIntervals = {1};
    private int currIndex = 0;

    // [Header("Display Parameters")]
    // public TextMeshPro textDisplay;

    private bool triggerFlag = false;

    private void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isActiveAndEnabled)
        {
            if (clock > 0)
            {
                clock -= Time.fixedDeltaTime;

                if (clock < 0)
                    clock = 0;
            }
            else
            {
                if (!triggerFlag)
                {
                    triggerFlag = true;
                    onClockZero.Invoke();
                }

                clock = 0;

                if(looping)
                {
                    currIndex += 1;
                    currIndex = currIndex % timeIntervals.Length;
                    Reset();
                }
            }
        }
        
    }

    public void Reset()
    {
        clock = timeIntervals[currIndex];
        triggerFlag = false;
    }
}
