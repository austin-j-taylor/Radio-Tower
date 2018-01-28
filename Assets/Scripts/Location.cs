using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour{
    public GameObject weasel;
    private string _title, _friendlyType, _enemyType;
    private float _threatDownTick, _threatUpTick, _checkTimeEnemy, _spawnInterval; 
    private float _threatLevel;
    private bool _selected;
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
        weasel = Resources.Load("Weasel") as GameObject;
	}
    public Location(string title, string friendlyType, string enemyType)
    {
        _title = title;
        _friendlyType = friendlyType;
        _enemyType = enemyType;
        _threatLevel = 0;
        _threatDownTick = 20f;
        _threatUpTick = 5f;
        _selected = false;
        _checkTimeEnemy = 20f;
        Debug.Log(_title + " initialized. Selection status " + _selected);
    }
	// Update is called once per frame
	public void Update () {
        //upticks threat level after 5 seconds
        if (_threatLevel >=.05)
        {
            _checkTimeEnemy -= Time.deltaTime;
            if(Time.time - _checkTimeEnemy > 0)
            {
                
                _checkTimeEnemy = Time.time + Mathf.Lerp(3, 20, 1f - (ThreatLevel - .3f) / .7f);
            }
        }
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
                _threatDownTick = 20f;
                _threatLevel -= 0.01f;
                Debug.Log(_title + " threat level has downticked");
            }
        }  
	}
    public void SpawnEnemy()
    {
        switch (_title)
        {
            case "Supermarket":
                MonoBehaviour.Instantiate(weasel, new Vector3(-423.5f, 202.6f, 0), Quaternion.identity);
                Debug.Log("Spawning Supermarket enemy (top left)");
                break;
            case "Abandoned Town":
                MonoBehaviour.Instantiate(weasel, new Vector3(425.5f, 203f, 0), Quaternion.identity);
                Debug.Log("Spawning town enemy (top right)");
                break;
            case "Forest":
                MonoBehaviour.Instantiate(weasel, new Vector3(424.6f, -194f, 0), Quaternion.identity);
                Debug.Log("Spawning Forest enemy (bottom right)");
                break;
            case "Construction Site":
                MonoBehaviour.Instantiate(weasel, new Vector3(-425.5f, -194f, 0), Quaternion.identity);
                Debug.Log("Spawning Construction Site enemy (bottom left)");
                break;
        }
    }
}
