using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collider : MonoBehaviour
{
    public Vector3[] endHoles;
    private int count = 0;
    public GameObject snake;
    public GameObject camera;
    Snake snakeScript;
    ZoomOut camScript;
    SpriteRenderer spriteRenderer;
    //public ZoomOut end;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = endHoles[0];
        snakeScript = snake.GetComponent<Snake>();
        camScript = camera.GetComponent<ZoomOut>(); 

        if(snakeScript != null){
            Debug.Log("Script Found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Fuck");
        if (endHoles.Length > count + 1)
        {
            count++;
            transform.position = endHoles[count];
            snakeScript.tpLol();
        }
        else
        {
            snakeScript.disable();
            //Debug.Log("End");
            //Destroy(snake);
            camScript.enabled = true;
        }
        
    }
}
