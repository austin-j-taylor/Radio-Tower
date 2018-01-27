using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationButton : MonoBehaviour {

    public int location;
    public GlobalController controller;

    private Button button;

	// Use this for initialization
	void Start () {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
	}
	
	void OnClick() {
        controller.SelectLocation(location);
        Debug.Log("now targeting location " + location);
    }
}
