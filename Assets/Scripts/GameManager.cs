using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson; //Reference components of first person character.

public class GameManager : MonoBehaviour {

    public GameObject player;
    public GameObject endScreen;

    public GameObject text;
    public GameObject buttonText;
    public bool win;

	public void restartLevel()
    {
        //Reset values and hide end screen stuff.
        SceneManager.LoadScene("Smile");
        Time.timeScale = 1;
        endScreen.SetActive(false);
        Cursor.visible = false;
    }
	
    public void gameover()
    {
        if (win)
        {
            text.GetComponent<Text>().text = "You have escaped the nightmare!";
            buttonText.GetComponent<Text>().text = "Play Again";
        }
        else
        {
            text.GetComponent<Text>().text = "How did this happen to me...";
            buttonText.GetComponent<Text>().text = "Try Again?";
        }

        endScreen.SetActive(true);

        //Stop game.
        Time.timeScale = 0;

        //Disable camera movement and cursor lock.
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player.GetComponent<FirstPersonController>().m_MouseLook.lockCursor = false;
        player.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = 0;
        player.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = 0;
    }

}
