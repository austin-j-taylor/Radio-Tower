using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour {
    public GameObject weasel;
    private string _title, _friendlyType, _enemyType;
    private float _threatDownTick, _threatUpTick, _checkTimeEnemy, _spawnInterval; 
    private float _threatLevel;
    private bool _selected;
    private float _globalEnemySpawn;
    //getters and setters
    public bool Selected
    {   
        //reset timers on location selection change
        get { return _selected; }
        set 
        {
            _selected = value;
            
            if (_selected == false)
            {
                _threatUpTick = 5f;
                Debug.Log(_title+" has been deselected! Resetting its uptick timer.");
            }
            else
            {
                _threatDownTick = 10f;
                Debug.Log(_title + " has been selected! Resetting its downtick timer.");
            }
        }
    }
    //getters, setters
    public float ThreatLevel
    {
        get { return _threatLevel; }
        set
        {
            _threatLevel = value;
        }
    }
    public string Title
    {
        get
        {
            return _title;
        }
        set
        {
            _title = value;
        }
    }
    public string FriendlyType
    {
        get
        {
            return _friendlyType;
        }
    }
    public string EnemyType
    {
        get
        {
            return _enemyType;
        }
    }
    // Use this for initialization
    void Start () {
        
	}
    //Init method to be used in place of constructor
    public void InitLocation(string title, string friendlyType, string enemyType)
    {
        _title = title;
        _friendlyType = friendlyType;
        _enemyType = enemyType;
        _threatLevel = 0;
        _threatDownTick = 10f;
        _threatUpTick = 5f;
        _selected = false;
        _globalEnemySpawn = 40f;
        _checkTimeEnemy = 40f;
        weasel = Resources.Load("Weasel", typeof(GameObject)) as GameObject;
        Debug.Log(_title + " initialized. Selection status " + _selected);
    }
	// Update is called once per frame
	public void Update () {
        _globalEnemySpawn -= Time.deltaTime;
        if(_globalEnemySpawn <= 0)
        {
            ConstantEnemySpawn();
        }
        //Spawns an enemy after a number of seconds based on the threat level when the last enemy was spawned.
        if (_threatLevel >=.25)
        {
            _checkTimeEnemy -= Time.deltaTime;
            if(Time.time - _checkTimeEnemy > 0)
            {
                SpawnEnemy();
                _checkTimeEnemy = Time.time + Mathf.Lerp(3, 40, 1f - (ThreatLevel - .3f) / .7f);
                Debug.Log(_checkTimeEnemy - Time.time);
            }
        }
        //upticks threat level after 5 seconds, provided that this location is selected
        if (_selected)
        {
            _threatUpTick -= Time.deltaTime;
            if(_threatUpTick <= 0f && _threatLevel < 1)
            {
                _threatUpTick = 5f;
                _threatLevel += 0.01f;
                Debug.Log(_title + " threat level has upticked");
            }
        }
        
        //downticks threat level after 20 seconds
        else
        {
            _threatDownTick -= Time.deltaTime;
            if(_threatDownTick <= 0f && ThreatLevel>0)
            {
                _threatDownTick = 10f;
                _threatLevel -= 0.01f;
                Debug.Log(_title + " threat level has downticked");
            }
        }  
	}
    //Instantiate enemy based on which location this is
    void SpawnEnemy()
    {
        switch(_title)
        {
            case "Supermarket":
                Instantiate(weasel, new Vector3(-45f, 20f, 0), Quaternion.identity);
                Debug.Log("Spawning Supermarket enemy (top left)");
                break;
            case "Abandoned Town":
                Instantiate(weasel, new Vector3(45f, 20f, 0), Quaternion.identity);
                Debug.Log("Spawning town enemy (top right)");
                break;
            case "Forest":
                Instantiate(weasel, new Vector3(45f, -20f, 0), Quaternion.identity);
                Debug.Log("Spawning Forest enemy (bottom right)");
                break;
            case "Construction Site":
                Instantiate(weasel, new Vector3(-45f, -20f, 0), Quaternion.identity);
                Debug.Log("Spawning Construction Site enemy (bottom left)");
                break;
        }
    }
    void ConstantEnemySpawn()
    {
        float roll = Random.value;
        if(roll <= 0.25f)
        {
            switch (_title)
            {
                case "Supermarket":
                    Instantiate(weasel, new Vector3(-45f, 20f, 0), Quaternion.identity);
                    Debug.Log("Spawning Supermarket enemy (top left)");
                    break;
                case "Abandoned Town":
                    Instantiate(weasel, new Vector3(45f, 20f, 0), Quaternion.identity);
                    Debug.Log("Spawning town enemy (top right)");
                    break;
                case "Forest":
                    Instantiate(weasel, new Vector3(45f, -20f, 0), Quaternion.identity);
                    Debug.Log("Spawning Forest enemy (bottom right)");
                    break;
                case "Construction Site":
                    Instantiate(weasel, new Vector3(-45f, -20f, 0), Quaternion.identity);
                    Debug.Log("Spawning Construction Site enemy (bottom left)");
                    break;
            }
        }
    }
}
