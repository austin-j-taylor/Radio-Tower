using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CRTTextController : MonoBehaviour {

    public GlobalController controller;

    public Text[] textFields;

	// Use this for initialization
	void Start () {
        textFields = GetComponentsInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        textFields[0].text = "+" + controller.Food;
        textFields[1].text = "+" + controller.Power;
        textFields[2].text = "" + controller.Wood;
        textFields[3].text = "" + controller.NumBuild;
        textFields[4].text = "" + controller.NumLogger;
        textFields[5].text = "" + controller.NumElectr;
        textFields[6].text = "" + controller.NumScav;
        textFields[7].text = (controller.GetLocation() == null) ? "" : controller.GetLocation().Title;
    }
}
