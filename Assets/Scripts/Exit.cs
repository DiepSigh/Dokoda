using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour {

    public float distance;

    public GameManager gm;
    public GameObject player;
    public GameObject interactDisplay;
    public GameObject interactText;
    public GameObject exit;
    public GameObject text;
    public GameObject floors;

    private void OnMouseOver()
    {
        //Only display if in reasonable distance.
        if (distance <= 2)
        {
            interactDisplay.SetActive(true);
            interactText.SetActive(true);
        }
        else if (distance >= 2)
        {
            interactDisplay.SetActive(false);
            interactText.SetActive(false);
        }

        if (Input.GetButtonDown("Interact"))
        {
            if (distance <= 2)
            {
                interactDisplay.SetActive(false);
                interactText.SetActive(false);

                if (player.GetComponent<PlayerStats>().hasKey == false)
                {
                    //Tooltip display.
                    text.GetComponent<Text>().text = "The door is locked.";
                    text.GetComponent<Animation>().Play("TextFadeAnim");
                }
                else
                {
                    //Game ends.
                    exit.GetComponent<Animation>().Play("DoorExitAnim");
                    this.GetComponent<BoxCollider>().enabled = false;
                    floors.SetActive(false);
                    text.GetComponent<Text>().text = "You fall into the darkness.";
                    text.GetComponent<Animation>().Play("TextFadeAnim");

                    StartCoroutine("FallIntoDarkness");
                    
                }
            }
        }
    }

    IEnumerator FallIntoDarkness()
    {
        yield return new WaitForSeconds(5.0f);
        gm.win = true;
        gm.gameover();
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
