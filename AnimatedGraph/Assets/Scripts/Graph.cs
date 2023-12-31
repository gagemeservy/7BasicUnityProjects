using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab;
    [SerializeField, Range(1,100000)]
    int resolution = 10;

    Transform[] points;

    void Awake()
    {
        double step = 2f/resolution;
        var scale = Vector3.one * (float)step;
        var position = Vector3.zero;

        points = new Transform[resolution];
        for(int i = 0; i < points.Length; i++){
            Transform point = points[i] = Instantiate(pointPrefab);
            point.SetParent(transform, false);
            position.x = ((i + .5f)*(float)step) - 1f;
            //position.y = position.x * position.x * position.x;
            point.localPosition = position;
            point.localScale = scale;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.time;
        for(int i = 0; i < points.Length; i++){
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = Mathf.Sin(Mathf.PI * (position.x + time));
            point.localPosition = position;
        }
    }
}
