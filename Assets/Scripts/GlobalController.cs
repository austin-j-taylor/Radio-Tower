using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalController : MonoBehaviour {
    //initialization of variables
    private int _wood, _power, _food;
    private int _numElectr, _numScav, _numBuild, _numLogger;
    private float _checkTime5, _checkTime10, _checkTime20, _checkTimeEnemy;
    private int _maxChecks;
    private int _broadcastLocation;
    private Location[] _locations;
    private List<UnitController> enemies, friendlies;
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
        _checkTimeEnemy = 20f;
        enemies = new List<UnitController>();
        friendlies = new List<UnitController>();
        _locations = new Location[5];
        CreateLocations();
        Debug.Log("Global Controller initialized.");
	}

    // Update is called once per frame
    void Update()
    {
        float timeChange = Time.deltaTime;
        float timeNow = Time.time;
        //when to perform checks for resource gathering, people joining, threat level rise/decay, etc.
        if (timeNow - _checkTime10 > 0)
        {
            _checkTime10 = timeNow + 10;
            PerformCheck(10);
        }
        if (timeNow - _checkTime5 > 0)
        {
            _checkTime5 = timeNow + 5;
            PerformCheck(5);
        }
        if (timeNow - _checkTime20 > 0)
        {
            _checkTime20 = timeNow + 20;
            PerformCheck(20);
        }
        for(int x = 1; x < 5; x++)
        {
            _locations[x].Update();
        }
    }
    void PerformCheck(int checkNum)
    {
        if (checkNum == 5)
        {
            //Roll chance to gain more population and update population numbers.
            float roll = Random.value;
            if (_locations[_broadcastLocation] != null && _food > 0 && roll <= .3 + (_locations[_broadcastLocation].ThreatLevel * .7) )
            {
                Debug.Log("Successful roll for new population, roll was " + roll*100 + " against a " + (.3 + (_locations[_broadcastLocation].ThreatLevel * .7))* 100 + " percent chance");
                switch (_locations[_broadcastLocation].FriendlyType)
                {
                    case "Logger":
                        _numLogger++;
                        Debug.Log("Adding logger to population count.");
                        break;
                    case "Electrician":
                        _numElectr++;
                        _power = _numElectr;
                        Debug.Log("Adding electrician to population count.");
                        break;
                    case "Scavenger":
                        _numScav++;
                        Debug.Log("Adding scavenger to population count.");
                        _food = _numScav * 3;
                        break;
                    case "Builder":
                        _numBuild++;
                        Debug.Log("Adding builder to population count.");
                        break;
                }
                _food--;
                Debug.Log("Increasing wood stores. Total wood rests at " + _wood);
            }
            else if(_locations[_broadcastLocation] != null)
            {
                Debug.Log("Failed RNG roll. Current threat level is "+_locations[_broadcastLocation].ThreatLevel*100+"%");
            }
        }
        else if (checkNum == 10)
        {
            _wood += _numLogger;
            Debug.Log("Increasing wood stores. Total wood rests at " + _wood);
        }      
    }
    public void SelectLocation(int locationIndex)
    {
        if(_broadcastLocation == 0)
        {
            _locations[locationIndex].Selected = true;
            _broadcastLocation = locationIndex;
        }
        else if(locationIndex == _broadcastLocation)
        {
            _locations[_broadcastLocation].Selected = false;
            _broadcastLocation = 0;
        }
        else 
        {
            _locations[_broadcastLocation].Selected = false;
            _locations[locationIndex].Selected = true;
            _broadcastLocation = locationIndex;
        }
    }
    void CreateLocations()
    {
        Location supermarket = new Location("Supermarket", "Scavenger", "Weasel");
        Location town = new Location("Abandoned Town", "Electrician", "Weasel");
        Location forest = new Location("Forest", "Logger", "Weasel");
        Location construction = new Location("Construction Site", "Builder", "Weasel");
        _locations[1] = supermarket;
        _locations[2] = town;
        _locations[3] = forest;
        _locations[4] = construction;
        _locations[0] = null;
    }
}
