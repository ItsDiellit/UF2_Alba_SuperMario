using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Enemy : MonoBehaviour
{
    private GameManager gameManager;
    private Rigidbody2D rBody;
    private AudioSource source;

    private BoxCollider2D boxCollider;

    public AudioClip deathSound;

    public float enemySpeed = 5;

    public float enemyDirection = -1;
    // Start is called before the first frame update
    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider2D>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rBody.velocity = new Vector2(enemyDirection * enemySpeed, rBody.velocity.y);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3 || (collision.gameObject.tag == "Goombas"))
        {
            if(enemyDirection == 1)
            {
                enemyDirection = -1;
            }
            else if(enemyDirection == -1)
            {
                enemyDirection = 1;
            }

            }


        if(collision.gameObject.tag == "Player")
        {
          PlayerMovement playerScript = collision.gameObject.GetComponent<PlayerMovement>();
         
          //playerScript.Death();

          if(playerScript.isDeath == false)
          {
            
            playerScript.StartCoroutine("Die");

          }

        }
       
        
    }

    public void GoombaDeath()
    {
        source.PlayOneShot(deathSound);
        boxCollider.enabled = false;
        rBody.gravityScale = 0;
        enemyDirection = 0;
        FindObjectOfType<Contador>().IncreaseGoombas();
        Destroy(gameObject, 0.5f);
    }

    void OnBecameVisible()
    {
        gameManager.enemiesInScreen.Add(this.gameObject);
    }

    void OnBecameInvisible()
    {
        gameManager.enemiesInScreen.Remove(this.gameObject);
    }
}
