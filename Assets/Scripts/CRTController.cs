using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CRTController : MonoBehaviour {

    public GlobalController controller;
    public GameObject towerOrder;
    public GameObject barricadeSpawn;
    public GameObject barricade;
    public Animator towerOrderAnimator;
    public Animator barricadeOrderAnimator;
    public Button towerButton;
    public Button barricadeButton;
    public Canvas barricadesCanvas;

    public RectTransform[] barricadePositions;
    private bool isInTower;
    private bool isInBarricade;
    private int currentlyBuilding;


    // Use this for initialization
    void Start () {
        Button[] buttons = GetComponentsInChildren<Button>();
        RectTransform[] allTransforms = barricadeSpawn.GetComponentsInChildren<RectTransform>();
        barricadePositions = new RectTransform[16];

        for (int i = 1; i < allTransforms.Length; i += 2) {
            barricadePositions[(i - 1) / 2] = allTransforms[i];
        }
        
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

        // do resource check, grey out box or un grey out box
        towerButton.interactable = true;
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
        currentlyBuilding = location;


        // do resource check, grey out box or un grey out box
        barricadeButton.interactable = true;
    }

    public void CancelBarricadeOrder() {
        isInBarricade = false;
        barricadeOrderAnimator.SetBool("IsIn", isInBarricade);
    }

    public void ExecuteBarricadeOrder() {
        isInBarricade = false;
        barricadeOrderAnimator.SetBool("IsIn", isInBarricade);

        //controller.Wood = controller.Wood - 15;
        GameObject newBarricade = Instantiate(barricade, barricadePositions[currentlyBuilding].position, Quaternion.identity);
        //newBarricade.transform.SetParent(barricadesCanvas.transform, true);

    }
}
