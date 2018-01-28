using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour {
    [SerializeField]
    protected GlobalController controller;
    protected string _unitType;
    //serialized to be editable in inspector
    [SerializeField]
    protected int _damageValue, _healthValue;
    [SerializeField]
    protected float _speedValue;
    protected float _attackSpeed, _rangeValue;
    //getters, setters
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
        controller = GameObject.FindWithTag("MainCamera").GetComponent<GlobalController>();
	}
	
	// Update is called once per frame
	void Update () {
        CheckForDeath();
	}
    //custom constructor
    public UnitController(string unitType, int damageValue, int healthValue, float attackSpeed, float speedValue, float rangeValue) 
    {
        _unitType = unitType;
        _damageValue = damageValue;
        _healthValue = healthValue;
        _attackSpeed = attackSpeed;
        _speedValue = speedValue;
        _rangeValue = rangeValue;
    }
    protected virtual void CheckForDeath()
    {
        if(_healthValue <= 0 )
        { 
            Destroy(gameObject);
        }
    }
}
