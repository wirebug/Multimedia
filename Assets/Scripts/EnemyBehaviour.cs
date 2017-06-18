using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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

        //Play Destruction Animation
        GetComponentInChildren<ParticleSystem>().Play();

        ScoreLogic.LastScore++;

        yield return new WaitForSeconds(1f);
        Destroy(gameObject);

        SpawnScript.enemiesAlives--;
    }
    public Transform goal;

    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }
    /*public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }
    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }
    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }*/
}
