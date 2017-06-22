using System.Collections;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public int health = 100;
    public int scoreOnHit = 5;
    public int scoreOnDestroy = 30;
    public float MovementSpeed = 4.0f;
    public bool MovementEnabled = true;
    public string MoveAlong {
        get { return mMoveAlong; }
        set {
            mMoveAlong = value;
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
    }
    private string mMoveAlong = "Path1";
    [HideInInspector]
    private int currentWayPoint = 0;
    private Transform[] Waypoints;
    private Transform targetWayPoint;
    
    void Start()
    {

    }

    void Update()
    {
        // check if we have somewere to move
        if (MovementEnabled && (currentWayPoint < this.Waypoints.Length))
        {
            if (targetWayPoint == null)
                targetWayPoint = Waypoints[currentWayPoint];
            Move();
        }
    }


    private void Move()
    {
        // rotate towards the target
        //transform.LookAt(targetWayPoint.transform); not smooth enough so use this:
        var rotate = Quaternion.LookRotation(targetWayPoint.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime * MovementSpeed * 4);

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
        health -= damage;
        ScoreLogic.Score += scoreOnHit;
        
        if (health <= 0)
        {
            StartCoroutine(DestroySelf());
            ScoreLogic.Score += scoreOnDestroy;
        }
    }

    private IEnumerator DestroySelf()
    {
        // Dont show anymore
        GetComponent<Renderer>().enabled = false;
        MovementEnabled = false;

        //Play Destruction Animation
        GetComponentInChildren<ParticleSystem>().Play();

        yield return new WaitForSeconds(1f);
        Destroy(gameObject);

        SpawnScript.enemiesAlives--;
    }
}
