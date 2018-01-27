using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour {
    private int threatLevel;
    private string title, friendlyType, enemyType;
    private float threatDownTick, threatUpTick;
    private bool selected
    {
        //reset timers on location selection change
        get { return selected; }
        set 
        {
            if (selected == false)
            {
                threatUpTick = 5f;
            }
            else
            {
                threatDownTick = 10f;
            }
        }
    }
	// Use this for initialization
	void Start () {
        threatLevel = 0;
        threatDownTick = 20f;
        threatUpTick = 5f;
        selected = false;
	}
	
	// Update is called once per frame
	void Update () {
        //upticks threat level after 5 seconds
	    if(selected)
        {
            threatUpTick -= Time.deltaTime;
            if(threatUpTick <= 0f)
            {
                threatUpTick = 5f;
                threatLevel++;
            }
        }
        //downticks threat level after 5 seconds
        else
        {
            threatDownTick -= Time.deltaTime;
            if(threatDownTick <= 0f)
            {
                threatDownTick = 10f;
                threatLevel--;
            }
        }
       
	}
}
