using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TitleScreen : MonoBehaviour {

    public AudioMixer mixer;

    private AudioMixerSnapshot first;

    private void Start() {
        first = mixer.FindSnapshot("Overworld");
    }

    public void CloseTitle() {
        Destroy(gameObject);
        first.TransitionTo(.5f);
    }
}
