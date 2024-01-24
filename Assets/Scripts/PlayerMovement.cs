using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rBody;
    public GroundSensor sensor;
    public SpriteRenderer render;

    public Animator anim;

    // Para asignar Mario a rigidbody2D a traves de privada 
    public Vector3 newPosition = new Vector3(50,5,0);

    public float movementSpeed = 5;

    private float inputHorizontal;

    public float jumpForce = 10;

    public bool jump = false;

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        //Con GetComponent asignamos la variable "Rigidbody2D" al componente en cuestion
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
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
        if(Input.GetButtonDown("Jump") && sensor.isGrounded == true )
        { 
            
             rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                //Si ponemos exclamacion en if(!...) le decimos que se active si el resultado es el contrario
            anim.SetBool("IsJumping", true);
        }
      
        if(inputHorizontal < 0)
    {
        render.flipX = true;
        anim.SetBool("IsRunning", true);
    }
    else if(inputHorizontal > 0)
    {
        render.flipX = false;
        anim.SetBool("IsRunning", true);
    }
    else
    {
        anim.SetBool("IsRunning", false);
    }
    }

    void FixedUpdate ()
    {

        rBody.velocity = new Vector2(inputHorizontal * movementSpeed , rBody.velocity.y);

    }
}
