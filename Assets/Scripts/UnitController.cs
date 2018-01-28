using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour {
    [SerializeField]
    protected GlobalController controller;
    protected string _unitType;
    [SerializeField]
    protected int _damageValue, _healthValue;
    protected float _attackSpeed, _speedValue, _rangeValue;
    public int HealthValue
    {
        get
        {
            return _healthValue;
        }
        set
        {
            _healthValue = value;
        }
    }
    public int DamageValue
    {
        get
        {
            return _damageValue;
        }
        set
        {
            _damageValue = value;
        }
    }
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
