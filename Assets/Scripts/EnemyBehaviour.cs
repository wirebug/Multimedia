using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour {

    public int Health = 100;

    public float MovementSpeed = 4f;
    public string MoveAlong = "Path1";
    private Transform[] Waypoints;

    [HideInInspector]
    public int currentWayPoint = 0;
    Transform targetWayPoint;


    // Use this for initialization
    void Start()
    {
        var path = GameObject.Find(MoveAlong);
        if (path != null)
        {
            Waypoints = new Transform[path.transform.childCount];
            for (int i = 0; i < Waypoints.Length; i++)
            {
                Waypoints[i] = path.transform.GetChild(i);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // check if we have somewere to walk
        if (currentWayPoint < this.Waypoints.Length)
        {
            if (targetWayPoint == null)
                targetWayPoint = Waypoints[currentWayPoint];
            move();
        }
    }

    void move()
    {
        // rotate towards the target
        transform.LookAt(targetWayPoint.transform); 

        //TODO: Schiffboden zur Erde gerichtet


        // move towards the target
        transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, MovementSpeed * Time.deltaTime);

        if (transform.position == targetWayPoint.position)
        {
            currentWayPoint++;
            if (currentWayPoint < this.Waypoints.Length)
            {
                targetWayPoint = Waypoints[currentWayPoint];
            }
            else
            {
                currentWayPoint = 0;
                targetWayPoint = Waypoints[currentWayPoint];
            }
        }
    }

    public void Hit(int damage)
    {
        Health -= damage;
        
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
}
