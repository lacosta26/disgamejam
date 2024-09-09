using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionn : MonoBehaviour
{
    public Vector3[] endHoles;
    private int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(1.015f, 0.48f, 0);
        //Debug.Log(new Vector3(1.015f, 0.48f, 0).x);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (endHoles.Length > count + 1)
        {
            count++;
            transform.position = endHoles[count];
        }
        else
        {

        }
    }
}
