using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMovement : MonoBehaviour
{
    public float rotationSpeed = 30f;
    public float floatSpeed = 0.5f;
    public float floatHeight = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //constant rotation around axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        float yPos = Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.localPosition = new Vector3(transform.localPosition.x, yPos, transform.localPosition.z);
    }
}
