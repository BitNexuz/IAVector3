using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingThruPoints : MonoBehaviour
{
    public float speed;
    public Transform[] point;
    int index;
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, point[index].position, step);
        if(transform.position == point[index].position)
        {
            index++;
            if(index == point.Length)
            {
                index = 0;
            }
        }
    }
}
