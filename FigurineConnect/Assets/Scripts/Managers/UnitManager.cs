using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour {

    public GameObject[] units;
	// Use this for initialization
	void Start () {
        units = GameObject.FindGameObjectsWithTag("Unit");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void UnitSelection() {
        foreach (GameObject item in units) {
            item.GetComponent<BaseUnit>().SetUnitSelection(false);
        }
    }
}
