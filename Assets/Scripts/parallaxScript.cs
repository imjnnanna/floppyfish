using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxScript : MonoBehaviour
{
    [SerializeField] private float skyScrollSpeed = -1f;
    [SerializeField] private float cloudLightScrollSpeed = -2f;
    [SerializeField] private float cloudDarkScrollSpeed = -3f;
    [SerializeField] private float birdScrollSpeed = -4f;
    [SerializeField] private float seaScrollSpeed = -5f;
    [SerializeField] private float poleScrollSpeed = -6f;

    [SerializeField] private GameObject sky;
    [SerializeField] private GameObject cloudLight;
    [SerializeField] private GameObject cloudDark;
    [SerializeField] private GameObject bird;
    [SerializeField] private GameObject sea;
    [SerializeField] private GameObject pole;

    private Vector2 skyStartPos;
    private Vector2 cloudLightStartPos;
    private Vector2 cloudDarkStartPos;
    private Vector2 birdStartPos;
    private Vector2 seaStartPos;
    private Vector2 poleStartPos;

    // Start is called before the first frame update
    void Start()
    {
        skyStartPos = sky.transform.position;
        cloudLightStartPos = cloudLight.transform.position;
        cloudDarkStartPos = cloudDark.transform.position;
        birdStartPos = bird.transform.position;
        seaStartPos = sea.transform.position;
        poleStartPos = pole.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        sky.transform.position = skyStartPos + Vector2.right * Mathf.Repeat(Time.time * skyScrollSpeed, 38.4f);
        cloudLight.transform.position = cloudLightStartPos + Vector2.right * Mathf.Repeat(Time.time * cloudLightScrollSpeed, 38.4f);
        cloudDark.transform.position = cloudDarkStartPos + Vector2.right * Mathf.Repeat(Time.time * cloudDarkScrollSpeed, 38.4f);
        bird.transform.position = birdStartPos + Vector2.right * Mathf.Repeat(Time.time * birdScrollSpeed, 38.4f);
        sea.transform.position = seaStartPos + Vector2.right * Mathf.Repeat(Time.time * seaScrollSpeed, 45.5f); // 45.5
        pole.transform.position = poleStartPos + Vector2.right * Mathf.Repeat(Time.time * poleScrollSpeed, 38.4f);
    }
}
