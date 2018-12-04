using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightToggle : MonoBehaviour {

    public GameObject flashlight;

    public bool gotFlashlight = false;
    bool ON = false;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Flashlight") && gotFlashlight)
        {
            //Toggle flashlight.
            if (!ON)
            {
                flashlight.SetActive(true);
                ON = true;
            }
            else
            {
                flashlight.SetActive(false);
                ON = false;
            }
        }

    }
}
