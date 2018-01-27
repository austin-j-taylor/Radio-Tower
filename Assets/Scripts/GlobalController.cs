using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalController : MonoBehaviour {
    //initialization of variables
    private int _wood, _power, _food;
    private int _numElectr, _numScav, _numBuild, _numLogger;
    private float _checkTime5, _checkTime10, _checkTime20;
    private int _maxChecks;
    [SerializeField]
    private Location _broadcastLocation;
    [SerializeField]
    private Location[] _locations;
	// Use this for initialization
	void Start () {
        //instantiate private variables
        _wood = 0;
        _power = 0;
        _food = 10;
        _numElectr = 0;
        _numScav = 0;
        _numLogger = 0;
        _checkTime5 = 5f;
        _checkTime10 = 10f;
        _checkTime20 = 20f;
        _locations = new Location[4];
        Debug.Log("Global Controller initialized.");
	}
	
	// Update is called once per frame
	void Update () {
        float timeChange = Time.deltaTime;
        float timeNow = Time.time;
        //when to perform checks for resource gathering, people joining, threat level rise/decay, etc.
        if (timeNow - _checkTime5 > 0)
        {
            _checkTime5 = timeNow + 5;
            PerformCheck(5);
        }
        else if(timeNow - _checkTime10 > 0)
        {
            _checkTime10 = timeNow + 10;
            PerformCheck(10);
        }
        else if(timeNow - _checkTime20 > 0)
        {
            _checkTime20 = timeNow + 20;
            PerformCheck(20);
        }
	}
    void PerformCheck(int checkNum)
    {
        if (checkNum == 5)
        {
            //Roll chance to gain more population and update population numbers.
            float roll = Random.value;
            if (_food > 0 && roll <= .3 + (_broadcastLocation.ThreatLevel * .7))
            {
                Debug.Log("Successful roll for new population, roll was " + roll + " against a " + (.3 + (_broadcastLocation.ThreatLevel * .7)) * 100 + " percent chance");
                switch (_broadcastLocation.FriendlyType)
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
                _wood += _numLogger;
                Debug.Log("Increasing wood stores. Total wood rests at " + _wood);
            }
        }
        else if (checkNum == 10)
        {
            _wood += _numLogger;
            Debug.Log("Increasing wood stores. Total wood rests at " + _wood);
        }      
    }
}
