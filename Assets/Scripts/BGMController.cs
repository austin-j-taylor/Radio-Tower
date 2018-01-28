using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour {

    AudioSource[] sources;

	// Use this for initialization
	void Start () {
        sources = GetComponents<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
