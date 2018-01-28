using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CRTController : MonoBehaviour {

    //public Button radioTower;
    public GameObject towerOrder;


	// Use this for initialization
	void Start () {
        Button[] buttons = GetComponentsInChildren<Button>();

        //radioTower = buttons[0];
        //radioTower.onClick.AddListener(OpenTowerOrder);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenTowerOrder() {
        towerOrder.SetActive(true);
    }

    public void CancelTowerOrder() {
        towerOrder.SetActive(false);
    }

    public void ExecuteTowerOrder() {
        towerOrder.SetActive(false);
    }
}
