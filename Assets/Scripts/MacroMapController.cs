using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MacroMapController : MonoBehaviour {

    public GlobalController controller;
    public GameObject cRTScreen;
    public Image forestImage;
    public Image constructionImage;

    private AudioSource[] mapSounds;

    private Animator anim;
    private LocationButton[] buttons;
    private Image[] threatStickies;
    private Text[] threatValues;
    private ArrayList microButtons;
    private bool isIn;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        isIn = false;
        anim.SetBool("IsIn", isIn);
        buttons = GetComponentsInChildren<LocationButton>();
        mapSounds = GetComponents<AudioSource>();

        Image[] allImages = GetComponentsInChildren<Image>();

        for (int i = 1; i <= buttons.Length; i++) {
            buttons[i - 1].SetLocation(i);
        }

        threatStickies = new Image[4];
        threatValues = new Text[4];

        for (int i = 2; i < allImages.Length; i += 2) {
            threatStickies[(i - 2) / 2] = allImages[i];
            threatValues[(i - 2) / 2] = threatStickies[(i - 2) / 2].GetComponentInChildren<Text>();
        }

        microButtons = new ArrayList();
        foreach (Button button in cRTScreen.GetComponentsInChildren<Button>()) {
            microButtons.Add(button);
        }

    }
    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            isIn = !isIn;
            anim.SetBool("IsIn", isIn);

            if(isIn) {
                mapSounds[0].Play();
            } else {
                mapSounds[1].Play();
            }

        }
        for (int i = 0; i < threatStickies.Length; i++) {
            int threat = (int)(controller.Locations[i + 1].ThreatLevel * 100);
            if (threat == 0) {
                threatStickies[i].enabled = false;
                threatValues[i].enabled = false;
            } else {
                threatStickies[i].enabled = true;
                threatValues[i].enabled = true;
                threatValues[i].text = "THREAT:\n" + threat + "%";
            }
        }
        // make image dark if energy < 50
        Color forestColor = forestImage.color;
        Color constructionColor = constructionImage.color;
        if(controller.Power < 50) {
            forestColor.a = .2f;
            constructionColor.a = .2f;
        } else {
            forestColor.a = 1f;
            constructionColor.a = 1f;
        }
        constructionImage.color = constructionColor;
        forestImage.color = forestColor;
    }

    public void SetMicroMapControl(int enable) {
        foreach (Button button in microButtons) {
            button.interactable = (enable == 1);
        }
    }
}
