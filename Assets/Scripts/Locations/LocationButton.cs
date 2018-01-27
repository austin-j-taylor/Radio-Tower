using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationButton : MonoBehaviour {

    public Location location;
    public GlobalController controller;

    private Button button;

	// Use this for initialization
	void Start () {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
	}
	
	void OnClick() {
        //controller set location mine
    }
}
