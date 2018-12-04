using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCast : MonoBehaviour {

    public static float distanceFromTarget;
    public float toTarget;
	
	// Update is called once per frame
	void Update () {
        RaycastHit Hit;

        //Output raycast forward to Hit and set variables.
        if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), out Hit))
        {
            toTarget = Hit.distance;
            distanceFromTarget = toTarget;
        }
	}
}
