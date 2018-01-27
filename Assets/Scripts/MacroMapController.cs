using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MacroMapController : MonoBehaviour {

    private Animator anim;
    private bool isIn;
    public LocationButton[] buttons;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        isIn = true;
        anim.SetBool("IsIn", isIn);
        buttons = GetComponentsInChildren<LocationButton>();
        for(int i = 0; i < buttons.Length; i++) {
            buttons[i].SetLocation(i);
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Tab)) {
            isIn = !isIn;
            anim.SetBool("IsIn", isIn);
        }
	}
}
