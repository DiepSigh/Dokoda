using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson; //Reference components of first person character.

public class Intro_01 : MonoBehaviour {

    public GameObject player;
    public GameObject text;
    public GameObject fade;

    // Use this for initialization
    void Start () {
        player.GetComponent<FirstPersonController>().enabled = false;
        StartCoroutine(Story());
	}
	
    IEnumerator Story()
    {
        //Load Screen
        text.GetComponent<Text>().text = "WASD to move, you can hold shift to run.";
        yield return new WaitForSeconds(4.0f);

        //Pause for a bit as screen fades in.
        yield return new WaitForSeconds(1.5f);

        //fade.SetActive(false);
        fade.GetComponent<Animation>().Play("FadeScreenAnim");
        text.GetComponent<Text>().text = "I need to leave.";
        text.GetComponent<Animation>().Play("TextFadeAnim");

        //Enable controller for character.
        yield return new WaitForSeconds(2.0f);
        player.GetComponent<FirstPersonController>().enabled = true;
    }


}
