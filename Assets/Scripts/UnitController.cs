using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour {
    protected string _unitType;
    protected int _damageValue, _healthValue;
    protected float _attackSpeed, _speedValue, _rangeValue;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		    
	}
    public UnitController(string unitType, int damageValue, int healthValue, int attackSpeed, int speedValue, int rangeValue) 
    {
        _unitType = unitType;
        _damageValue = damageValue;
        _healthValue = healthValue;
        _attackSpeed = attackSpeed;
        _speedValue = speedValue;
        _rangeValue = rangeValue;
    }
}
