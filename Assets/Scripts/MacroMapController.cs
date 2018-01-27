using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacroMapController : MonoBehaviour {

    private Animator anim;
    private bool isIn;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        isIn = true;
        anim.SetBool("IsIn", isIn);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Tab)) {
            isIn = !isIn;
            anim.SetBool("IsIn", isIn);
        }
	}
}
