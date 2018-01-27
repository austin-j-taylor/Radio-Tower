using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationButton : MonoBehaviour {

    public GlobalController controller;

    private Button button;
    [HideInInspector]
    public int location;

	void Start () {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
	}

    void OnClick() {
        controller.SelectLocation(location);
    }

    public void SetLocation(int loc) {
        location = loc;
    }
}
