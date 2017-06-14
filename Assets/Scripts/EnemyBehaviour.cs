using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public int Health = 100;

    public void Hit(int damage)
    {
        Health -= damage;
        //Todo: Play some hit animation
        if (Health <= 0)
        {
            StartCoroutine(DestroySelf());
        }
    }

    private IEnumerator DestroySelf()
    {
        // Dont show anymore
        GetComponent<Renderer>().enabled = false;

        //Todo: Play some destruction animation
        //wait before destroy so effects are played correctly
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);

        SpawnScript.enemiesAlives--;
    }
}
