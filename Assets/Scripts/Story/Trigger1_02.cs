using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

//2nd trigger. Just displays text.
public class Trigger1_02 : MonoBehaviour {

    public GameObject text;
    public GameObject self;

    private void OnTriggerEnter()
    {
        text.GetComponent<Text>().text = "Where am I?";
        text.GetComponent<Animation>().Play("TextFadeAnim");
        self.SetActive(false);
    }

}
