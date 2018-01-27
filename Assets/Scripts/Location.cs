﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location {
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
        _threatLevel = 0;
        _threatDownTick = 20f;
        _threatUpTick = 5f;
        _selected = false;
        _checkTimeEnemy = 20f;
        Debug.Log(_title + " initialized. Selection status " + _selected);
	}
    public Location(string title, string friendlyType, string enemyType)
    {
        _title = title;
        _friendlyType = friendlyType;
        _enemyType = enemyType;
    }
	// Update is called once per frame
	void Update () {
        //upticks threat level after 5 seconds
        if (_threatLevel >=.3)
        {
            _checkTimeEnemy -= Time.deltaTime;
            if(Time.time - _checkTimeEnemy > 0)
            {
                SpawnEnemy();
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
        
        //downticks threat level after 5 seconds
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
    void SpawnEnemy()
    {

    }
}
