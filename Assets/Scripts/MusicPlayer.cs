using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private GameObject[] music;
    // Start is called before the first frame update
    void Start() {
        // destroy other music on scene reset
        music = GameObject.FindGameObjectsWithTag("gameMusic");
        Destroy(music[1]);
    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
