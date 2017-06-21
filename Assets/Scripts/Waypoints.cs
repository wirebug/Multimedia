using UnityEngine;

public class Waypoints : MonoBehaviour {
    public static Transform[] waypoints;

    // put the points from unity interface
    public Transform[] wayPointList;

    public int currentWayPoint = 0;
    Transform targetWayPoint;

    public float speed = 4f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // check if we have somewere to walk
        if (currentWayPoint < this.wayPointList.Length)
        {
            if (targetWayPoint == null)
                targetWayPoint = wayPointList[currentWayPoint];
            move();
        }
    }

    void move()
    {
        // rotate towards the target
        //transform.LookAt(targetWayPoint.transform); not smooth enough so use this:
        Vector3 direction = targetWayPoint.transform.position - transform.position;
        Quaternion toRotation = Quaternion.FromToRotation(transform.forward, direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 0.02f * speed * Time.time);
        
        //TODO: Schiffboden zur Erde gerichtet


        // move towards the target
        transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, speed * Time.deltaTime);

        if (transform.position == targetWayPoint.position)
        {
            currentWayPoint++;
            if (currentWayPoint < this.wayPointList.Length)
            {
                targetWayPoint = wayPointList[currentWayPoint];
            }
            else
            {
                currentWayPoint = 0;
                targetWayPoint = wayPointList[currentWayPoint];
            }
        }
    }
}
