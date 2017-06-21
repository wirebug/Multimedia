using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    private Transform objectToOrbit;
    public Vector3 orbitAxis = Vector3.up;
    public float orbitRadius = 3.0f;
    public float orbitRadiusCorrectionSpeed = 10.0f;
    public float orbitRotationSpeed = 20.0f;

    private Transform ship;
    private Vector3 orbitDesiredPosition;

    void Start()
    {
        ship = transform;
        objectToOrbit = GameObject.FindWithTag("center").transform;
    }

    void Update()
    {
        ship.RotateAround(objectToOrbit.position, orbitAxis, orbitRotationSpeed * Time.deltaTime);
        orbitDesiredPosition = (ship.position - objectToOrbit.position).normalized * orbitRadius + objectToOrbit.position;
        ship.position = Vector3.Slerp(ship.position, orbitDesiredPosition, Time.deltaTime * orbitRadiusCorrectionSpeed);
    }
}
