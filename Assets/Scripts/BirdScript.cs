using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public GameObject titleScreen;
    public Text scoreText;

    [SerializeField] private AudioSource popSound;
    [SerializeField] private AudioSource thumpSound;

    private Animator jumpAnimation;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        jumpAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            if (titleScreen.activeSelf)
            {
                titleScreen.SetActive(false);
                myRigidbody.gravityScale = 5;
                scoreText.enabled = true;
            }
            myRigidbody.velocity = Vector2.up * flapStrength;
            jumpAnimation.SetBool("jump", true);
            jumpAnimation.SetBool("isFalling", false);
            popSound.Play();
        }
        else if(titleScreen.activeSelf)
        {
            myRigidbody.velocity = new Vector2(0, 0);
            myRigidbody.gravityScale = 0;
        }
        else if(myRigidbody.velocity.y <= 0f && birdIsAlive)
        {
            jumpAnimation.SetBool("jump", false);
            jumpAnimation.SetBool("isFalling", true);
        }

        if(myRigidbody.position.y < -8 && birdIsAlive)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        thumpSound.Play();
        logic.gameOver();
        birdIsAlive = false;
    }
}
