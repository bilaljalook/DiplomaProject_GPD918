using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    //TODO modify the tank to make slower and faster fire rate plus 4 health bars
    public float Speed=0.5f;
    private float vertical;
    private float horizontal;
    [SerializeField] public float limit = 0.7f;
    Rigidbody2D rigid;
    private Vector2 moveDirection;
    //private Vector2 moveDirection1;
    float rotationAngle;
    float smoothTime = 1.0f;
    Quaternion desiredRotation;
    public float RateOfFire = 1.5f;
    private float nextF = 0.0f;


    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        
    }
    
        
    private void Update()
    {

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        GetInput1();
        desiredRotation = Quaternion.Euler(0, 0, rotationAngle);
        //transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothTime*0.1f);
        
    }
    private void FixedUpdate()
    {
        if (horizontal!= 0 && vertical!=0)
        {
            Moving();
        }
        else
        {
            Moving();
        }

    }
    private void GetInput1()
    {
        
        moveDirection = Vector2.zero;
        float rotationAngle;
        if (Input.GetKey(KeyCode.W))
        {

            moveDirection += Vector2.up;
            
            rigid.constraints = RigidbodyConstraints2D.None;
            rigid.constraints = RigidbodyConstraints2D.FreezePositionX;
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothTime);
            rotationAngle = 90;
            rigid.transform.Rotate(0,0,rotationAngle);
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += Vector2.down;
            rigid.constraints = RigidbodyConstraints2D.None;
            rigid.constraints = RigidbodyConstraints2D.FreezePositionX;
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothTime);
            rotationAngle = -90;
            rigid.transform.Rotate(0, 0, rotationAngle);
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += Vector2.left;
            rigid.constraints = RigidbodyConstraints2D.None;
            rigid.constraints = RigidbodyConstraints2D.FreezePositionY;
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothTime);
            rotationAngle = 180;
            rigid.transform.Rotate(0, 0, rotationAngle);
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += Vector2.right;
            rigid.constraints = RigidbodyConstraints2D.None;
            rigid.constraints = RigidbodyConstraints2D.FreezePositionY;
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothTime);
            rotationAngle = 0;
            rigid.transform.Rotate(0, 0, rotationAngle);
        }
        if (Input.GetKeyDown(KeyCode.M) && Time.time > nextF)
        {
            nextF = Time.time + RateOfFire;
            GetComponent<Shell>().Shoot();
        }


    }
    public void Moving()
    {
       rigid.velocity = new Vector2((horizontal * Speed), (vertical * Speed));
    }
   
}
