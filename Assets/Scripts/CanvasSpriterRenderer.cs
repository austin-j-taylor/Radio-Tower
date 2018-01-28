using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasSpriterRenderer : MonoBehaviour {

    RectTransform trans;
    
	// Use this for initialization
	void Start () {
        trans = GetComponent<RectTransform>();
        trans.localScale = new Vector2(100 / trans.sizeDelta.x, 60 / trans.sizeDelta.y);
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
