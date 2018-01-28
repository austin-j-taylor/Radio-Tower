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
        Vector3 dir = transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
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
                Vector3 dir = transform.position-_obstacle.transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                Quaternion targetrotation = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetrotation, Time.deltaTime);
                Attack(_obstacle);
                _attackSpeed = 3f;
                Debug.Log("I have attacked something! Its remaining health is " + _obstacle.HealthValue);
            }
        }
        else
        {

            Vector3 dir = transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion targetrotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetrotation, Time.deltaTime);
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
        if (collision.gameObject.name.Contains("Barricade") || collision.gameObject.name.Contains("RadioTowerCollider"))
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
