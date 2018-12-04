using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public GameObject player;
    public GameObject enemy;
    public float speed = 0.01f;
    public bool isAttacking = false;
    public bool inRange = false;
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(player.transform);
        if (!isAttacking)
        {
            //Walk in direction of player when not talking regardless of obstacles.
            speed = 0.01f;
            enemy.GetComponent<Animation>().Play("Walking");
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed);
        }

        //Attack when in range. Not avoidable.
        if (inRange && !isAttacking) {
            speed = 0;
            enemy.GetComponent<Animation>().Play("Swing");
            StartCoroutine(DeductHP());
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inRange = false;
        }
    }

    //Wait for animation before deducting HP.
    IEnumerator DeductHP()
    {
        isAttacking = true;
        yield return new WaitForSeconds(1.1f);
        PlayerStats.currentHP -= 4;
        yield return new WaitForSeconds(0.2f);
        isAttacking = false;
    }
}
