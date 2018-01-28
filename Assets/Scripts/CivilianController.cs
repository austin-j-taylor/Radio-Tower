using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
public class CivilianController : UnitController {
    
    private EnemyController target;
    // Use this for initialization
    void Start () {
        target = GetClosestEnemy(controller.Enemies);
        _attackSpeed = 3f;
    }
	
	// Update is called once per frame
	void Update () {
        _attackSpeed -= Time.deltaTime;
        if (target == null)
        {
            target = GetClosestEnemy(controller.Enemies);
        }
        else if(Vector2.Distance(target.transform.position, transform.position) < 100)
        {
            Vector2.MoveTowards(this.transform.position, this.transform.position, 0f);
            if (_attackSpeed <= 0)
            {
                Attack(target);
                _attackSpeed = 3f;
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, 0.3f);
        }
    }
    public CivilianController(string unitType, int damageValue, int healthValue, int attackSpeed, int speedValue, int rangeValue) : base
        (unitType: unitType, damageValue: damageValue, healthValue: healthValue, attackSpeed: attackSpeed, speedValue: speedValue, rangeValue: rangeValue)
    {
    }
    EnemyController GetClosestEnemy(List<EnemyController> enemies)
    {
        EnemyController closest = null;
        float minDist = Mathf.Infinity;
        Vector2 currentpos = transform.position;
        foreach (EnemyController e in enemies)
        {
            float dist = Vector2.Distance(e.transform.position, currentpos);
            if (dist < minDist)
            {
                closest = e;
                minDist = dist;
            }
        }
        return closest;
    }
    void Attack(EnemyController other)
    {
        other.HealthValue = other.HealthValue - _damageValue;
    }
 //   private void OnCollisionEnter2D(Collision2D collision)
 //   {
 //       EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
 //  }
}
