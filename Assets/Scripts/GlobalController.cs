using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalController : MonoBehaviour {
    //initialization of variables
    private int wood, power, food;
    private int numElectr, numScav, numBuild, numLogger;
    private float checkTime;
    private int maxChecks;
    private Location broadcastLocation;
	// Use this for initialization
	void Start () {
        //instantiate private variables
        wood = 0;
        power = 0;
        food = 0;
        numElectr = 0;
        numScav = 0;
        numLogger = 0;
        checkTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        checkTime += Time.deltaTime;
        //when to perform checks for resource gathering, people joining, threat level rise/decay, etc.
        if(checkTime % 5 == 0)
        {
            PerformCheck(5);
        }
        else if(checkTime % 10 == 0)
        {
            PerformCheck(10);
        }
        else if(checkTime % 20 == 0)
        {
            PerformCheck(20);
            checkTime = 0;
        }
	}
    void PerformCheck(int checkNum)
    {
        Random personChecker = new Random();
        switch(checkNum)
        {
            //checks that exist: check for people increment. .3+.7*threat level every 5 seconds
            //woodgathering: +1*numLumber every 10 seconds
            case 5:
                //TODO: Create individual threat level holders.
                if(Random.value <= .3/* + threat level*.7 */)
                {
                    //TODO: Uptick population based on current location
                }
                goto case 10; //yeah I'm using a goto, you wanna make something of it? Fallthroughs in C# being illegal is dumb.
            case 10:
                wood+=numLogger;
                break;
            
        }
    }
}
