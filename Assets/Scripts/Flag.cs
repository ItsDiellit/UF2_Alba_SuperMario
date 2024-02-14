using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public AudioSource source;
    public AudioClip flagsound;
    
    public AudioSource lvl1Music;

    
    // Start is called before the first frame update
    void Start()
    {
          source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D Collider)
    {
         if(Collider.gameObject.tag == "Player")
        {
            lvl1Music.Pause();
            source.clip = flagsound;
            
            source.Play();
            
        }
    }
}
