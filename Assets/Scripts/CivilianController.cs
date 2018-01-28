using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class CivilianController : UnitController {  
    private Vector2 _spawnPoint;
    private EnemyController _target;
    public Vector2 SpawnPoint
    {
        get
        {
            return _spawnPoint;
        }
        set
        {
            _spawnPoint = value;
        }
    }
    // Use this for initialization
    void Start () {
        _spawnPoint = transform.position;
        controller = GameObject.FindWithTag("MainCamera").GetComponent<GlobalController>();
        _target = GetClosestEnemy(controller.Enemies);
        _attackSpeed = 3f;

    }
	
	// Update is called once per frame
	void Update () {
        _attackSpeed -= Time.deltaTime;
        //acquire new target
        if(controller.Enemies.Count == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, _spawnPoint, 0.3f);
            if(Vector2.Distance(transform.position, _spawnPoint) < 1f)
            {
                controller.Friendlies.Remove(this);
                Debug.Log(controller.Friendlies.Count);
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("I am not exactly at my spawn point. My spawn point is " + SpawnPoint.x + ", " + SpawnPoint.y + ". I am at " + transform.position.x+", "+transform.position.y);
            }
        }
        else if (_target == null)
        {
            _target = GetClosestEnemy(controller.Enemies);
        }
        //move towards target until close enough to attack
        else if(Vector2.Distance(_target.transform.position, transform.position) < 10)
        {
            Vector2.MoveTowards(transform.position, transform.position, 0f);
            if (_attackSpeed <= 0)
            {
                Attack(_target);
                _attackSpeed = 3f;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, 0.3f);
        }
    }
    public CivilianController(string unitType, int damageValue, int healthValue, int attackSpeed, int speedValue, int rangeValue) : base
        (unitType: unitType, damageValue: damageValue, healthValue: healthValue, attackSpeed: attackSpeed, speedValue: speedValue, rangeValue: rangeValue)
    {
    }
    //find closest enemy by comparing transform.position of all enemies stored in the GlobalController's _enemies arraylist
    EnemyController GetClosestEnemy(List<EnemyController> enemies)
    {
        EnemyController closest = null;
        float minDist = Mathf.Infinity;
        Vector2 currentpos = transform.position;
        foreach (EnemyController e in enemies)
        {
            if (e != null) { 
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
    void Attack(EnemyController other)
    {
        other.HealthValue = other.HealthValue - _damageValue;
    }
    protected override void CheckForDeath()
    {
        if (_healthValue <= 0)
        {
            controller.Friendlies.Remove(this);
            Destroy(gameObject);
        }
    }

    //   private void OnCollisionEnter2D(Collision2D collision)
    //   {
    //       EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
    //  }
}
