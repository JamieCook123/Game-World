using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public float waveSpeed = 1.0f;
    public float waveRate = 1.0f;
    public float waveHeight = 0.1f;

    private Vector3[] baseVertices;
    private Mesh mesh;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        baseVertices = mesh.vertices; 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] vertices = new Vector3[baseVertices.Length];

        for (int i = 0; i < vertices.Length; i++) 
        {
            Vector3 vertex = baseVertices[i];
            vertex.y += CalculateWave(vertex.x, vertex.z, Time.time);
            vertices[i] = vertex;      
        }

        mesh.vertices = vertices;
        mesh.RecalculateBounds();
    }

    float CalculateWave(float x, float z, float time) 
    {
        float wave = 0.0f;

        wave = (Mathf.Sin(x * waveRate + time * waveSpeed) * waveHeight) * (Mathf.Cos(z * waveRate + time * waveSpeed));

        return wave;
    }
}
