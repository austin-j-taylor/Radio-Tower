using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if(gameObject.name == "RadioTowerCollider")
        {
            Debug.Log("Collider attack speed set!");
            _attackSpeed = 5f;
            _rangeValue = 20f;
        }
        controller = GameObject.FindWithTag("MainCamera").GetComponent<GlobalController>();
	}
	
	// Update is called once per frame
	void Update () {
        EnemyController e = GetClosestEnemy(controller.Enemies);
        _attackSpeed -= Time.deltaTime;
        if (e != null && Vector2.Distance(e.gameObject.transform.position,transform.position) < _rangeValue && gameObject.name == "RadioTowerCollider" && _attackSpeed < 0)
        {
            Debug.Log("Found enemy. Laser time.");
            Attack(e);
            _attackSpeed = 5f;
        }
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
        if(gameObject.name.Contains("RadioTowerCollider") && _healthValue <= 0)
        {
            //currently resets game
            SceneManager.LoadScene("Main");
            Destroy(gameObject);
        }
        else if(_healthValue <= 0 )
        { 
            Destroy(gameObject);
        }
    }
    EnemyController GetClosestEnemy(List<EnemyController> enemies)
    {
        EnemyController closest = null;
        float minDist = Mathf.Infinity;
        Vector2 currentpos = transform.position;
        foreach (EnemyController e in enemies)
        {
            if (e != null)
            {
                float dist = Vector2.Distance(e.transform.position, currentpos);
                if (dist < minDist)
                {
                    closest = e;
                    minDist = dist;
                }
            }
        }
        return closest;
    }
    protected virtual void Attack(UnitController other)
    {
        
    }
}
