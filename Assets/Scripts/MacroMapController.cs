using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MacroMapController : MonoBehaviour {

    public GlobalController controller;

    private Animator anim;
    private LocationButton[] buttons;
    public Image[] threatStickies;
    public Text[] threatValues; 
    private bool isIn;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        isIn = true;
        anim.SetBool("IsIn", isIn);
        buttons = GetComponentsInChildren<LocationButton>();

        Image[] allImages = GetComponentsInChildren<Image>();


        for(int i = 2; i < allImages.Length; i += 2) {
            threatStickies[(i - 2) / 2] = allImages[i];
            threatValues[(i - 2) / 2] = threatStickies[(i - 2) / 2].GetComponentInChildren<Text>();
        }

        for (int i = 1; i <= buttons.Length; i++) {
            buttons[i - 1].SetLocation(i);
        }
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Tab)) {
            isIn = !isIn;
            anim.SetBool("IsIn", isIn);
        }
        for(int i = 0; i < threatStickies.Length; i++) {
            int threat = (int)(controller.Locations[i + 1].ThreatLevel * 100);
            if (threat == 0) {
                threatStickies[i].enabled = false;
            } else {
                threatStickies[i].enabled = true;
                threatValues[i].text = "THREAT:\n" + threat + "%";
            }
        }
	}
}
