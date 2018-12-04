using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TyroneInteract : MonoBehaviour {

    public float distance;

    public GameObject interactDisplay;
    public GameObject interactText;
    public GameObject tyrone;
    public GameObject text;

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
                interactDisplay.SetActive(false);
                interactText.SetActive(false);

                //Tooltip display.
                text.GetComponent<Text>().text = "Is he OK?!";
                text.GetComponent<Animation>().Play("TextFadeAnim");
            }
        }
    }

    private void OnMouseExit()
    {
        interactDisplay.SetActive(false);
        interactText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Get distance from target in PlayerCast script.
        distance = PlayerCast.distanceFromTarget;
    }
}
