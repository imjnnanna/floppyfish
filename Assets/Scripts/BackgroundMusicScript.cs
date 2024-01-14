using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicScript : MonoBehaviour
{
    private GameObject[] backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("starting start");
        backgroundMusic = GameObject.FindGameObjectsWithTag("Music");
        Debug.Log("destroying music");
        if(backgroundMusic.Length > 1) Destroy(backgroundMusic[1]);
    }

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
