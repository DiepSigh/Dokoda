using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//3rd trigger where Tyrone falls down and mini jumpscare occurs.
public class Trigger2_03 : MonoBehaviour {

    public AudioSource slam;
    public AudioSource music;
    public GameObject tyrone;
    public GameObject door;
    public GameObject text;
    public GameObject colliderObj;

	void OnTriggerEnter () {
        GetComponent<BoxCollider>().enabled = false;
        colliderObj.GetComponent<OpenDoor>().enabled = true;
        door.GetComponent<Animation>().Play("DoorAnim");

        //Story and audio stuff.
        slam.Play();
        tyrone.SetActive(true);
        text.GetComponent<Text>().text = "?!";  
        text.GetComponent<Animation>().Play("TextFadeAnim");
        music.Play();
    }
}
