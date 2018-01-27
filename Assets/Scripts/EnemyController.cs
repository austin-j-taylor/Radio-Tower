using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : UnitController {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
	}
    public EnemyController(string unitType, int damageValue, int healthValue, int attackSpeed, int speedValue, int rangeValue) : base
        (unitType: unitType, damageValue: damageValue, healthValue: healthValue, attackSpeed: attackSpeed, speedValue: speedValue, rangeValue: rangeValue)
    {
    }
    UnitController GetClosestEnemy(UnitController[] enemies)
    {
        UnitController closest = null;
        float minDist = Mathf.Infinity;
        Vector2 currentpos = transform.position;
        foreach (UnitController u in enemies)
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
}
