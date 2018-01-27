using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalController : MonoBehaviour {
    //initialization of variables
    private int _wood, _power, _food;
    private int _numElectr, _numScav, _numBuild, _numLogger;
    private float _checkTime;
    private int _maxChecks;
    [SerializeField]
    private Location _broadcastLocation;
	// Use this for initialization
	void Start () {
        //instantiate private variables
        _wood = 0;
        _power = 0;
        _food = 10;
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
            Debug.Log("Performing 5-second check");
        }
        else if(_checkTime % 10 == 0)
        {
            PerformCheck(10);
            Debug.Log("Performing 10-second check");
        }
        else if(_checkTime % 20 == 0)
        {
            PerformCheck(20);
            _checkTime = 0;
            Debug.Log("performing 20-second check, resetting timer.");
        }
	}
    void PerformCheck(int checkNum)
    {
        switch(checkNum)
        {
            case 5:
                //Roll chance to gain more population and update population numbers.
                float roll = Random.value;
                if (_food > 0 && roll <= .3 + (_broadcastLocation.threatLevel * .7))
                {
                    Debug.Log("Successful roll for new population, roll was " + roll + " against a " + (.3 + (_broadcastLocation.threatLevel * .7))*100 + " percent chance");
                    switch(_broadcastLocation.friendlyType)
                    {
                        case "Logger":
                            _numLogger++;
                            Debug.Log("Adding logger to population count.");
                            break;
                        case "Electrician":
                            _numElectr++;
                            Debug.Log("Adding electrician to population count.");
                            break;
                        case "Scavenger":
                            _numScav++;
                            Debug.Log("Adding scavenger to population count.");
                            break;
                        case "Builder":
                            _numBuild++;
                            Debug.Log("Adding builder to population count.");
                            break;
                    }
                }
                goto case 10; //yeah I'm using a goto, you wanna make something of it? Fallthroughs in C# being illegal is dumb.
            case 10:
                _wood+=_numLogger;
                Debug.Log("Increasing wood stores");
                break;
            
        }
    }
}
