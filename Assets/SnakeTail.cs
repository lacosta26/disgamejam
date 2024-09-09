using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeTailMovement : MonoBehaviour
{
    public GameObject snakeTailPiece;
    private GameObject obj;
    public static List<Vector3> path;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("snake tail init");
        obj = Instantiate(snakeTailPiece, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        // move each previous section to next assigned target



        // each point should know what forward node is, and frontmost node

        // if distance to forward node is more than threshold, lerp to that. otherwise, lerp to target

        // static field for path, list of vectors
        // distance btwn each element determines when to move


        // FixedJoint possibly
        obj.transform.position = transform.position + Vector3.up;
    }
}
