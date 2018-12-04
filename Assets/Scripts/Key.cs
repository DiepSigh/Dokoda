using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour {

    public float distance;

    public GameObject player;
    public GameObject interactDisplay;
    public GameObject interactText;
    public GameObject text;
    public GameObject key;

    void Update()
    {
        //Get distance from target in PlayerCast script.
        distance = PlayerCast.distanceFromTarget;
    }

    private void OnMouseOver()
    {
        //Only display if in reasonable distance.
        if (distance <= 3)
        {
            interactDisplay.SetActive(true);
            interactText.SetActive(true);
        }
        else if (distance >= 3)
        {
            interactDisplay.SetActive(false);
            interactText.SetActive(false);
        }

        if (Input.GetButtonDown("Interact"))
        {
            if (distance <= 3)
            {
                //Enable flashlight use on player.
                player.GetComponent<PlayerStats>().hasKey = true;

                interactDisplay.SetActive(false);
                interactText.SetActive(false);

                //Tooltip display.
                text.GetComponent<Text>().text = "Picked up key.";
                text.GetComponent<Animation>().Play("TextFadeAnim");

                key.SetActive(false);
            }
        }
    }

    private void OnMouseExit()
    {
        interactDisplay.SetActive(false);
        interactText.SetActive(false);
    }
}
