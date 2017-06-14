using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shoot : MonoBehaviour
{

    public float ShootRate = 0.75f;
    public float MaxRange = 150f;
    public WaitForSeconds duration = new WaitForSeconds(0.25f);

    private LineRenderer line;
    Camera cam;

    private float canShootAgainTime;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > canShootAgainTime)
        {
            Fire();
        }
    }

    private void Fire()
    {
        canShootAgainTime = Time.time + ShootRate;

        line.SetPosition(0, cam.transform.position + transform.up * -2f + transform.right * 1.5f + transform.forward * -1f);

        RaycastHit hit;

        // Checks if we hit something
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, MaxRange))
        {
            line.SetPosition(1, hit.point);

            EnemyBehaviour enemy = hit.collider.GetComponent<EnemyBehaviour>();
            if (enemy != null)
            {
                enemy.Hit(34);
            }
        }
        else
        {
            line.SetPosition(1, cam.transform.position + cam.transform.forward * MaxRange);
        }
        StartCoroutine(ShowLaser());
    }

    private IEnumerator ShowLaser()
    {
        line.enabled = true;
        yield return duration;
        line.enabled = false;
    }
}
