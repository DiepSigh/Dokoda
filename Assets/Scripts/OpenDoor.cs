using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour {

    public float distance;

    public GameObject interactDisplay;
    public GameObject interactText;
    public GameObject door;

    public AudioSource creak;

    public bool closed = true;
    bool animating = false;

	// Update is called once per frame
	void Update () {
        //Get distance from target in PlayerCast script.
        distance = PlayerCast.distanceFromTarget;
	}

    private void OnMouseOver()
    {
        //Only display if in reasonable distance.
        if (distance <= 2 && !animating)
        {
            interactDisplay.SetActive(true);
            interactText.SetActive(true);
        //Turn off if walked away.
        }else if (distance >= 2){
            interactDisplay.SetActive(false);
            interactText.SetActive(false);
        }

        if (Input.GetButtonDown("Interact") && !animating)
        {
            if (distance <= 2)
            {
                //Disable collider when door is open.
                this.GetComponent<BoxCollider>().enabled = false;

                //Turn off since door is open
                interactDisplay.SetActive(false);
                interactText.SetActive(false);

                //Open door if closed and close if open. Coroutine to delay for animation to complete.
                if (closed)
                {
                    door.GetComponent<Animation>().Play("DoorAnim");
                    StartCoroutine(DoorAnimating());
                    closed = false;
                }
                else
                {
                    door.GetComponent<Animation>().Play("DoorCloseAnim");
                    StartCoroutine(DoorAnimating());
                    closed = true;
                }
                creak.Play();
                this.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }

    //Avoid spamming interaction.
    IEnumerator DoorAnimating()
    {
        animating = true;
        yield return new WaitForSeconds(1.5f);
        animating = false;
    }

    private void OnMouseExit()
    {
        interactDisplay.SetActive(false);
        interactText.SetActive(false);
    }
}
