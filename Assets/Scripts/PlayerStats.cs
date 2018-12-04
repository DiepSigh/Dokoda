using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson; //Reference components of first person character.

public class PlayerStats : MonoBehaviour {

    public GameManager gm;
    public GameObject player;

    public Slider healthBar;
    public Slider staminaBar;

    //Progression related.
    public bool hasKey = false;

    //Stats.
    public int maxHP = 20;
    public static int currentHP;
    public int HP = 20;
    public float stamina = 1;
    float runSpeed;

    //Audio.
    public AudioSource hurt1;
    public AudioSource hurt2;
    public AudioSource hurt3;

    int randomHurt;
    public GameObject hurtScreen;

    private void Start()
    {
        currentHP = maxHP;
        healthBar.value = ActualHealth();
        staminaBar.value = stamina;
        runSpeed = player.GetComponent<FirstPersonController>().m_RunSpeed;
    }

    // Update is called once per frame
    void Update () {
        if (currentHP != HP)
        {
            //Randommly generate sound when damage is taken.
            randomHurt = Random.Range(1, 4);
            hurtScreen.GetComponent<Animation>().Play("RedScreenAnim");
            switch (randomHurt)
            {
                case 1:
                    hurt1.Play();
                    break;
                case 2:
                    hurt2.Play();
                    break;
                case 3:
                    hurt3.Play();
                    break;
                default:
                    hurt1.Play();
                    break;
            }
            if (currentHP <= 0)
            {
                gm.gameover();
            }
        }

        //Update HP.
        HP = currentHP;
        healthBar.value = ActualHealth();

        if (HP != 0 && HP <= 12)
        {
            hurtScreen.GetComponent<Animation>().Play("RedBlinkAnim");
        }else if (HP <= 0)
        {
            hurtScreen.GetComponent<Animation>().Play("RedScreenAnim");
        }

        staminaBar.value = stamina;
    }

    private void FixedUpdate()
    {
        //Stamina
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (stamina > 0)
            stamina -= 0.005f;
        }
        else if (stamina < 1)
        {
            stamina += 0.0025f;
        }

        //Change run speed if player tries to run with no stamina;
        if (stamina < 0.05)
        {
            player.GetComponent<FirstPersonController>().m_RunSpeed = 2;
        }else
        {
            player.GetComponent<FirstPersonController>().m_RunSpeed = runSpeed;
        }
    }

    float ActualHealth()
    {
        //Cannot divide ints; convert to floats and return.
        float temp = currentHP;
        float temp2 = maxHP;
        return temp / temp2;
    }
}
