using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour {
    private string _unitType;
    private int _damageValue, _healthValue;
    private float _attackSpeed, _speedValue, _rangeValue;
    bool _friendly;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		    
	}
    public UnitController()
    {

    }
    Transform GetClosestEnemy(Transform enemies)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector2 currentpos = transform.position;
        foreach(Transform t in enemies)
        {
            float dist = Vector2.Distance(t.position, currentpos);
            if(dist<minDist)
            {
                tMin = t;
                minDist = dist;
            }
        }
        return tMin;
        
    }
}
