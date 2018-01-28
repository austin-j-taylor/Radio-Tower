using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHealthSlider : MonoBehaviour {

    public Slider slider;
    private UnitController controller;

	// Use this for initialization
	void Start () {
        controller = GetComponent<UnitController>();
        slider.maxValue = 100;
	}
	
	// Update is called once per frame
	void Update () {
        slider.value = controller.HealthValue;
        //if(controller.HealthValue == 0) {

        //}
	}
}
