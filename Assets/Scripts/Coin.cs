using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private AudioSource source;
    public AudioClip CoinSound;
    // Start is called before the first frame update
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
   
   void OnTriggerEnter2D(Collider2D Collider)
    {
        if(Collider.gameObject.tag == "Player")

        {
           source.clip = CoinSound;
           source.Play();
           FindObjectOfType<Contador>().IncreaseCoins();
           Destroy(gameObject, 0.4f);

        }
        
    }
}
