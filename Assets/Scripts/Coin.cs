using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioSource source;
    public AudioClip CoinSound;
    public Rigidbody2D rBody;
    private BoxCollider2D boxCollider;
    // Start is called before the first frame update
    void Awake()
    {
        source = GetComponent<AudioSource>();
        rBody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
   
   void OnTriggerEnter2D(Collider2D Collider)
    {
        if(Collider.gameObject.tag == "Player")

        {
           source.clip = CoinSound;
           source.Play();
           Destroy(gameObject, 0.4f);

        }
        
    }
}
