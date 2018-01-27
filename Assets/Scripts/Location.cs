using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour {
    
    private string _title, _friendlyType, _enemyType;
    private float _threatDownTick, _threatUpTick;
    private bool _selected;
    public bool selected
    {
        //reset timers on location selection change
        get { return _selected; }
        set 
        {
            if (_selected == false)
            {
                _threatUpTick = 5f;
            }
            else
            {
                _threatDownTick = 10f;
            }
        }
    }
    private float _threatLevel;
    //make threatLevel publicly accessible, it's kinda important.
    public float threatLevel
    {
        get { return _threatLevel; }
        set
        {
            _threatLevel = value;
        }
    }
    
	// Use this for initialization
	void Start () {
        _threatLevel = 0;
        _threatDownTick = 20f;
        _threatUpTick = 5f;
        _selected = false;
	}
	
	// Update is called once per frame
	void Update () {
        //upticks threat level after 5 seconds
	    if(_selected)
        {
            _threatUpTick -= Time.deltaTime;
            if(_threatUpTick <= 0f)
            {
                _threatUpTick = 5f;
                _threatLevel += 0.01f;
            }
        }
        //downticks threat level after 5 seconds
        else
        {
            _threatDownTick -= Time.deltaTime;
            if(_threatDownTick <= 0f)
            {
                _threatDownTick = 10f;
                _threatLevel -= 0.01f;
            }
        }
       
	}
}
