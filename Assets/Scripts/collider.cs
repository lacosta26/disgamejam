using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider : MonoBehaviour
{
    public Vector3[] endHoles;
    private int count = 0;
    public Snake snakeScript;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = endHoles[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (endHoles.Length > count + 1)
        {
            count++;
            transform.position = endHoles[count];
            snakeScript.tpLol();
        }
        else
        {

        }
        
    }
}
