using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab;
    [SerializeField, Range(1,100000)]
    int resolution = 10;

    [SerializeField]
    FunctionLibrary.FunctionName function;

    Transform[] points;

    void Awake()
    {
        double step = 2f/resolution;
        var scale = Vector3.one * (float)step;

        points = new Transform[resolution * resolution];

        for(int i = 0; i < points.Length; i++){

            Transform point = points[i] = Instantiate(pointPrefab);
            point.localPosition = scale;
            point.localScale = scale;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        FunctionLibrary.Function f = FunctionLibrary.GetFunction(function);

        float time = Time.time;
        float step = 2f / resolution;
        float v = .5f * step - 1f;

        for(int i = 0, x = 0, z = 0; i < points.Length; i++, x++)
        {
            if (x == resolution)
            {
                x = 0;
                z += 1;
                v = (z + .5f) * step - 1f;
            }
            float u = ((x + .5f) * (float)step) - 1f;
            points[i].localPosition = f(u, v, time);
        }
    }
}
