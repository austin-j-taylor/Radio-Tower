using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : UnitController {
    private bool _moving;
    private UnitController obstacle;
    // Use this for initialization
    void Start () {
        controller.Enemies.Add(this);
        _moving = true;
	}
	
	// Update is called once per frame
	void Update () {
        _attackSpeed -= Time.deltaTime; 
       if(_healthValue <=0)
       {
            CheckForDeath();
       }
       else if(_moving)
       {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(0,0), _speedValue);
       }
       else 
       {
            Vector2.MoveTowards(this.transform.position, this.transform.position, 0f);
            if (_attackSpeed < 0)
            {
                Attack(obstacle);
                _attackSpeed = 3f;
            }
       }
       
	}
    public EnemyController(string unitType, int damageValue, int healthValue, float attackSpeed, float speedValue, float rangeValue) : base
        (unitType: unitType, damageValue: damageValue, healthValue: healthValue, attackSpeed: attackSpeed, speedValue: speedValue, rangeValue: rangeValue)
    {
    }
    UnitController GetClosestEnemy(UnitController[] friendlies)
    {
        UnitController closest = null;
        float minDist = Mathf.Infinity;
        Vector2 currentpos = transform.position;
        foreach (UnitController u in friendlies)
        {
            float dist = Vector2.Distance(u.transform.position, currentpos);
            if (dist < minDist)
            {
                closest = u;
                minDist = dist;
            }
        }
        return closest;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        obstacle = collision.gameObject.GetComponent<UnitController>();
        _moving = false;
        
    }
    void Attack(UnitController other)
    {
        other.HealthValue = other.HealthValue - _damageValue;
    }
}
