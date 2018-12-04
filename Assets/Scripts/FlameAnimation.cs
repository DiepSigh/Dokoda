using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameAnimation : MonoBehaviour {

    public int lightMode; //Mode = Animation to play.
    public GameObject FlameLight;
	
	// Update is called once per frame
	void Update () {
		if (lightMode == 0)
        {
            StartCoroutine(AnimateLight());
        }
	}

    //IEnumerator delays script.
    IEnumerator AnimateLight ()
    {
        //Select random animation. 
        lightMode = Random.Range(1, 4);
        switch (lightMode)
        {
            case 1:
                FlameLight.GetComponent<Animation>().Play("TorchAnim");
                break;
            case 2:
                FlameLight.GetComponent<Animation>().Play("TorchAnim2");
                break;
            case 3:
                FlameLight.GetComponent<Animation>().Play("TorchAnim3");
                break;
            default:
                FlameLight.GetComponent<Animation>().Play("TorchAnim");
                break;
        }

        //Let animation complete.
        yield return new WaitForSeconds(0.09f);

        //Reset back to 0 after random animation plays.
        lightMode = 0;
    }
}
