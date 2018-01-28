using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalController : MonoBehaviour {
    //initialization of variables
    private int _wood, _power, _food;
    private int _numElectr, _numScav, _numBuild, _numLogger;
    private float _checkTime5, _checkTime10, _checkTime20;
    private int _broadcastLocation;
    private Location[] _locations;
    private List<EnemyController> _enemies;
    private List<CivilianController> _friendlies;
    //getters, setters
    public int Wood {
        get
        {
            return _wood;
        }
        set
        {
            _wood = value;
        }
    }
    public int Power
    {
        get
        {
            return _power;
        }
        set
        {
            _power = value;
        }
    }
    public int Food
    {
        get
        {
            return _food;
        }
        set
        {
            _food = value;
        }
    }
    public int NumElectr
    {
        get
        {
            return _numElectr;
        }
    }
    public int NumScav
    {
        get
        {
            return _numScav;
        }
    }
    public int NumBuild
    {
        get
        {
            return _numBuild;
        }
    }
    public int NumLogger
    {
        get
        {
            return _numLogger;
        }
    }
    public List<EnemyController> Enemies
    {
        get
        {
            return _enemies;
        }
        set
        {
            _enemies = value;
        }
    }
    public List<CivilianController> Friendlies
    {
        get
        {
            return _friendlies;
        }
        set
        {
            _friendlies = value;
        }
    }
    public Location[] Locations
    {
        get
        {
            return _locations;
        }
        set
        {
            _locations = value;
        }
    }
    // Use this for initialization
    void Start () {
        //instantiate private variables
        _wood = 0;
        _power = 0;
        _food = 0;
        _numElectr = 0;
        _numScav = 10;
        _numLogger = 15;
        _checkTime5 = 5f;
        _checkTime10 = 10f;
        _checkTime20 = 20f;
        _enemies = new List<EnemyController>();
        _friendlies = new List<CivilianController>();
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
        //update locations as non-monobehaviour classes do not update automatically
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
            //if no food is available, you can still gain scavengers. Additionally, you are more likely to gain scavengers than other civilians.
            if (_locations[_broadcastLocation] != null && _locations[_broadcastLocation].Title.Equals("Supermarket") &&
                roll <= .5 + (_locations[_broadcastLocation].ThreatLevel * .7))
            {
                Debug.Log("Successful roll for new population, roll was " + roll * 100 + " against a " + (.3 + (_locations[_broadcastLocation].ThreatLevel * .7)) * 100 + " percent chance");
                _numScav++;
                Debug.Log("Adding scavenger to population count.");
                _food += 2;
            }
            //standard chance for other civvies
            else if (_locations[_broadcastLocation] != null && _food > 0 && roll <= .3 + (_locations[_broadcastLocation].ThreatLevel * .7) )
            {
                Debug.Log("Successful roll for new population, roll was " + roll*100 + " against a " + (.3 + (_locations[_broadcastLocation].ThreatLevel * .7))* 100 + " percent chance");
                switch (_locations[_broadcastLocation].FriendlyType)
                {
                    case "Logger":
                        _numLogger++;
                        Debug.Log("Adding logger to population count.");
                        _food--;
                        break;
                    case "Electrician":
                        _numElectr++;
                        _power += 5;
                        Debug.Log("Adding electrician to population count.");
                        _food--;
                        break;
                    case "Builder":
                        _numBuild++;
                        Debug.Log("Adding builder to population count.");
                        _food--;
                        break;
                }
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
    //called when a location button is pressed
    public void SelectLocation(int locationIndex)
    {
        //if no location is selected, select clicked location
        if(_broadcastLocation == 0)
        {
            _locations[locationIndex].Selected = true;
            _broadcastLocation = locationIndex;
        }
        //if currently selected location is reselected, deselect location
        else if(locationIndex == _broadcastLocation )
        {
            _locations[_broadcastLocation].Selected = false;
            _broadcastLocation = 0;
        }
        //if currently selected location is the construction site or the forest, require extra power
        else if (locationIndex == 3 || locationIndex == 4)
        {
            if(_power >= 50)
            {
                _locations[_broadcastLocation].Selected = false;
                _locations[locationIndex].Selected = true;
                _broadcastLocation = locationIndex;
            }
        }
        //default
        else if(locationIndex == 2 || locationIndex == 1)
        {
            _locations[_broadcastLocation].Selected = false;
            _locations[locationIndex].Selected = true;
            _broadcastLocation = locationIndex;
        }
    }
    //add locations to controller object
    void CreateLocations()
    {
        GameObject locationController = GameObject.FindGameObjectWithTag("LocationController");
        Location supermarket = locationController.AddComponent<Location>();
        supermarket.InitLocation("Supermarket", "Scavenger", "Weasel");
        Location town = locationController.AddComponent<Location>();
        town.InitLocation("Abandoned Town", "Electrician", "Weasel");
        Location forest = locationController.AddComponent<Location>();
        forest.InitLocation("Forest", "Logger", "Weasel");
        Location construction = locationController.AddComponent<Location>();
        construction.InitLocation("Construction Site", "Builder", "Weasel");
        _locations[1] = supermarket;
        _locations[2] = town;
        _locations[3] = forest;
        _locations[4] = construction;
        _locations[0] = null;
    }
    public Location GetLocation()
    {
        return _locations[_broadcastLocation];
    }
}
