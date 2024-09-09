using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : MonoBehaviour
{
    public float targetSize = 10f;  // Target orthographic size
    private float growSpeed = 3f;    // Speed of size change

    void Update()
    {
        // Gradually interpolate the orthographic size of the camera
        //Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, targetSize, Time.deltaTime * growSpeed);
        if (Camera.main.orthographicSize < targetSize)
        {
            if (Camera.main.orthographicSize >= 20f){
                growSpeed = 50f;
                Debug.Log("Speed Changed");
            }
            Camera.main.orthographicSize += growSpeed * Time.deltaTime;
        }
    
    }
}
