using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rBody;
    public GroundSensor sensor;
    public SpriteRenderer render;

    public Animator anim;

    AudioSource source;

    // Para asignar Mario a rigidbody2D a traves de privada 
    public Vector3 newPosition = new Vector3(50,5,0);

    public float movementSpeed = 5;

    private float inputHorizontal;

    public float jumpForce = 10;

    public bool jump = false;

    public AudioClip jumpSound;

    public Transform bulletSpawn;
    public GameObject bulletPrefab;

    private bool canShoot = true;
    public float timer;
    public float rateOffire = 1f;

    public Transform hitBox;
    public float hitBoxRadius = 2;

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        //Con GetComponent asignamos la variable "Rigidbody2D" al componente en cuestion
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        // teletransporta al personaje a la posicion de la variante newPosition
        //transform.position = newPosition;

        
        
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        //transform.position = transform.position + new Vector3(1,0,0) * movementSpeed * Time.deltaTime;
        //transform.position += new Vector3(inputHorizontal,0,0) * movementSpeed * Time.deltaTime;

        

       /* if(jump == true)
        {
            Debug.Log("estoy saltando");
        }
        else if(jump == false)
        {
            Debug.Log("estoy en el suelo");
        }
        else
        {
            Debug.Log("afsdg");
        }*/
//Getbutton Down para cuando pulsas el boton getbuttonup cuando sueltas y getbutton cuando mantienes la tecla
        
      
     

    Shoot();
    Movement();
    Jump();
    if(Input.GetKeyDown(KeyCode.J))
    {
        //Attack();
        anim.SetTrigger("IsAttacking");
    }

    }

    void FixedUpdate ()
    {

        rBody.velocity = new Vector2(inputHorizontal * movementSpeed , rBody.velocity.y);

    }



    void Movement()
    {
           if(inputHorizontal < 0)
    {
        //render.flipX = true;
        transform.rotation = Quaternion.Euler(0, 180, 0);
        anim.SetBool("IsRunning", true);
    }
    else if(inputHorizontal > 0)
    {
       // render.flipX = false;
       transform.rotation = Quaternion.Euler(0, 0, 0);
        anim.SetBool("IsRunning", true);
    }
    else
    {
        anim.SetBool("IsRunning", false);
    }
    }


    void Jump()
    {
        if(Input.GetButtonDown("Jump") && sensor.isGrounded == true )
        { 
            
             rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                //Si ponemos exclamacion en if(!...) le decimos que se active si el resultado es el contrario
            anim.SetBool("IsJumping", true);
            source.PlayOneShot(jumpSound);
        }
    }


    void Shoot()
    {
        if(!canShoot)
        {
            timer += Time.deltaTime;
            if(timer >= rateOffire)
            {
                canShoot = true;
                timer = 0;
            }
        }
        if(Input.GetKeyDown(KeyCode.F) && canShoot)
        {
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
            canShoot = false;


        }
    }

   public void Attack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(hitBox.position, hitBoxRadius);

        foreach (Collider2D enemy in enemies)
        {
            if(enemy.gameObject.tag == "Goombas")
            {
                //Destroy(enemy.gameObject);
                Enemy enemyScript = enemy.GetComponent<Enemy>();
                enemyScript.GoombaDeath();
            }
        }

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(hitBox.position, hitBoxRadius);
    }
}
