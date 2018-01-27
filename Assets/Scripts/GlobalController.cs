using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalController : MonoBehaviour {
    //initialization of variables
    private int _wood, _power, _food;
    private int _numElectr, _numScav, _numBuild, _numLogger;
    private float _checkTime;
    private int _maxChecks;
    private Location _broadcastLocation;
	// Use this for initialization
	void Start () {
        //instantiate private variables
        _wood = 0;
        _power = 0;
        _food = 0;
        _numElectr = 0;
        _numScav = 0;
        _numLogger = 0;
        _checkTime = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        _checkTime += Time.deltaTime;
        //when to perform checks for resource gathering, people joining, threat level rise/decay, etc.
        if(_checkTime % 5 == 0)
        {
            PerformCheck(5);
        }
        else if(_checkTime % 10 == 0)
        {
            PerformCheck(10);
        }
        else if(_checkTime % 20 == 0)
        {
            PerformCheck(20);
            _checkTime = 0;
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
                if (Random.value <= .3 + (_broadcastLocation.threatLevel * .7))
                {
                    //TODO: Uptick population based on current location
                }
                goto case 10; //yeah I'm using a goto, you wanna make something of it? Fallthroughs in C# being illegal is dumb.
            case 10:
                _wood+=_numLogger;
                break;
            
        }
    }
}
