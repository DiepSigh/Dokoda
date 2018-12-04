using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public GameObject key;
    public GameObject flashlight;

    public GameObject player;
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<PlayerStats>().hasKey)
        {
            key.SetActive(true);
        }
        if (player.GetComponent<FlashlightToggle>().gotFlashlight)
        {
            flashlight.SetActive(true);
        }
	}
}
