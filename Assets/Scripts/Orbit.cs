using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform centerRock;
    public float orbitSpeed = 20f;
    public float orbitRadius = 5f;

    private Vector3 axis;

    // Start is called before the first frame update
    void Start()
    {
        axis = transform.position - centerRock.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(centerRock.position, axis, orbitSpeed * Time.deltaTime);
        Vector3 positionToMove = (transform.position - centerRock.position).normalized * orbitRadius + centerRock.position;
        transform.position = Vector3.MoveTowards(transform.position, positionToMove, orbitSpeed * Time.deltaTime);
    }
}
