using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemyPrefab;

    public Transform[] spawnPoint;

    public float spawnRate = 0.5f;

    public float timer;
    public float waitTime = 3f;

    private bool activateSpawn = false;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnEnemy", 1f, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        if(activateSpawn)
        {
          SpawnEnemy();

        }
    }

    void SpawnEnemy()
    {
        timer += Time.deltaTime;

        if(timer >= waitTime)
        {
 //Esto es para cuando la variable era normal
            //Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);//

            //Esto es para el array
           Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], spawnPoint[0].position, spawnPoint[0].rotation);
            Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], spawnPoint[1].position, spawnPoint[1].rotation);
            Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], spawnPoint[2].position, spawnPoint[2].rotation);
             timer = 0;
        }
       
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            activateSpawn = true;
        }

    }


    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            activateSpawn = false;
        }
        
    }
}
