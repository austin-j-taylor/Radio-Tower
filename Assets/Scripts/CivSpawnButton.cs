using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CivSpawnButton : MonoBehaviour {
    public GlobalController controller; 
    public GameObject civilian;
    private Button _button;
    // Use this for initialization
    void Start () {
        civilian = Resources.Load("Civilian", typeof(GameObject)) as GameObject;
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
        controller = GameObject.FindWithTag("MainCamera").GetComponent<GlobalController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnClick()
    {
        if(controller.Friendlies.Count < (controller.NumBuild + controller.NumScav + controller.NumLogger + controller.NumElectr) / 10)
        {
            if(transform.position.y < 0)
            {
                GameObject newCiv = Instantiate(civilian, new Vector3(0, -17, 0), Quaternion.identity);
                newCiv.transform.parent = GameObject.Find("MicroMap").transform;
                //newCiv.transform.position = new Vector3(transform.position.x, transform.position.y - 10, 0);
                
            }
            else if(transform.position.y > 0)
            {
                GameObject newCiv = Instantiate(civilian, new Vector3(0, 17, 0), Quaternion.identity);
                newCiv.transform.parent = GameObject.Find("MicroMap").transform;
                //newCiv.transform.position = new Vector3(transform.position.x, transform.position.y + 10, 0);
                
            }
            else if(transform.position.x < 0)
            {
                GameObject newCiv = Instantiate(civilian, new Vector3(-30, 0, 0), Quaternion.identity);
                newCiv.transform.parent = GameObject.Find("MicroMap").transform;
                //newCiv.transform.position = new Vector3(transform.position.x, transform.position.x - 10, 0);
            }
            else
            {
                GameObject newCiv = Instantiate(civilian, new Vector3(30, 0, 0), Quaternion.identity);
                newCiv.transform.parent = GameObject.Find("MicroMap").transform;
                //newCiv.transform.position = new Vector3(transform.position.x, transform.position.x + 10, 0);
            }
            
            controller.Friendlies.Add(civilian.GetComponent<CivilianController>());
        } 
        else
        {
            Debug.Log("Not enough civilians");
        }
    }
}
