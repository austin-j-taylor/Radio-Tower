using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CRTController : MonoBehaviour {
    
    public GameObject towerOrder;
    public GameObject barricadeSpawn;
    public Animator towerOrderAnimator;
    public Animator barricadeOrderAnimator;

    private Transform[] barricadePositions;
    private bool isInTower;
    private bool isInBarricade;


    // Use this for initialization
    void Start () {
        Button[] buttons = GetComponentsInChildren<Button>();

        barricadePositions = barricadeSpawn.GetComponentsInChildren<RectTransform>();
        
        isInTower = false;
        isInBarricade = false;
        towerOrderAnimator.SetBool("IsIn", isInTower);
        barricadeOrderAnimator.SetBool("IsIn", isInBarricade);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenTowerOrder() {
        isInTower = true;
        towerOrderAnimator.SetBool("IsIn", isInTower);
    }

    public void CancelTowerOrder() {
        isInTower = false;
        towerOrderAnimator.SetBool("IsIn", isInTower);
    }

    public void ExecuteTowerOrder() {
        isInTower = false;
        towerOrderAnimator.SetBool("IsIn", isInTower);
    }

    public void BuildBarricade(int location) {
        isInBarricade = true;
        barricadeOrderAnimator.SetBool("IsIn", isInBarricade);
    }

    public void CancelBarricadeOrder() {
        isInBarricade = false;
        barricadeOrderAnimator.SetBool("IsIn", isInBarricade);
    }

    public void ExecuteBarricadeOrder() {
        isInBarricade = false;
        barricadeOrderAnimator.SetBool("IsIn", isInBarricade);
    }
}
