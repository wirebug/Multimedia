using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float ShootRate = 0.75f;
    public float MaxRange = 150f;
    public WaitForSeconds duration = new WaitForSeconds(0.25f);
    private LineRenderer line;
    private Camera cam;
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
            if (!IsBackButtonClicked())
            {
                Fire();
            }
        }
    }

    private bool IsBackButtonClicked()
    {
        GameObject[] backButtons = GameObject.FindGameObjectsWithTag("BackButton");

        foreach (GameObject backButton in backButtons)
        {
            RectTransform backButtonRt = (RectTransform)backButton.transform;
            Vector3 middle = backButtonRt.position;
            Vector2 size = new Vector2(backButtonRt.rect.width, backButtonRt.rect.height);
            float halfWidth = size.x / 2.0f;
            float halfHeight = size.y / 2.0f;
            Vector2 backButtonTopLeft = new Vector2(middle.x - halfWidth, middle.y + halfHeight);
            Vector2 backButtonBottomRight = new Vector2(middle.x + halfWidth, middle.y - halfHeight);

            Vector3 mousePos = Input.mousePosition;

            if (
                    mousePos.x >= backButtonTopLeft.x &&
                    mousePos.x <= backButtonBottomRight.x &&
                    mousePos.y <= backButtonTopLeft.y &&
                    mousePos.y >= backButtonBottomRight.y
                )
            {
                return true;
            }
        }

        return false;
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
                var laserhit = GetComponentInChildren<ParticleSystem>();
                if (laserhit != null)
                {
                    laserhit.transform.position = line.GetPosition(1);
                    laserhit.Play();
                }
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
