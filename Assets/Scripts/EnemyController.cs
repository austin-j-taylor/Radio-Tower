using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : UnitController {
    private UnitController _obstacle;
    // Use this for initialization
    void Start () {
        controller = GameObject.FindWithTag("MainCamera").GetComponent<GlobalController>();
        controller.Enemies.Add(this);
        _attackSpeed = 3f;
	}
	
	// Update is called once per frame
	void Update () {
        _attackSpeed -= Time.deltaTime; 
       if(_healthValue <=0)
       {
            CheckForDeath();
       }
        else if (_obstacle != null)
        {
            Vector2.MoveTowards(transform.position, transform.position, 0f);
            if (_attackSpeed < 0)
            {
                Vector3 targetPostition = new Vector3(_obstacle.transform.position.x, _obstacle.transform.position.y, transform.position.z);
                this.transform.LookAt(targetPostition);
                Attack(_obstacle);
                _attackSpeed = 3f;
                Debug.Log("I have attacked something! Its remaining health is " + _obstacle.HealthValue);
            }
        }
        else
        {
            
            transform.LookAt(new Vector3(0, 0, transform.position.z));
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(0,0), _speedValue);
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
        if (collision.gameObject.name.Contains("Barricade"))
        {
            _obstacle = collision.gameObject.GetComponent<UnitController>();
        }
    }
    void Attack(UnitController other)
    {
        other.HealthValue = other.HealthValue - _damageValue;
    }
    protected override void CheckForDeath()
    {
        if (_healthValue <= 0)
        {
            controller.Enemies.Remove(this);
            Debug.Log(controller.Enemies.Count);
            Destroy(gameObject);
        }
    }
}
