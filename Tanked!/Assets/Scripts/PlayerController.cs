using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public string PlayerId;
    [SerializeField] public float Speed = 0.5f;
    [SerializeField] public float RateOfFire = 1.5f;
    [SerializeField] private GameObject PlayerShield;

   

    private Shield playerSH;
    private Rigidbody2D rigid;
    private Vector2 moveDirection;
    private float rotationAngle;
    private float nextF = 0.0f;

    public ScoreSystem score;

    public GameObject SpawnPoint;

    public static bool stopInput = false;

    [SerializeField] Timer Stime;
    [SerializeField] Timer Rtime;

    
    

    private void Start()
    {
        Stime.GetComponent<GameObject>();
        Rtime.GetComponent<GameObject>();
        rigid = GetComponent<Rigidbody2D>();
        PlayerId = PlayerId + " ";
    }

    private void Update()
    {
        

        if (stopInput == false)
        {
            GetInput();

            Moving();
        }
    }

    private void GetInput()
    {
        moveDirection = Vector2.zero;

        float rotationAngle = transform.rotation.eulerAngles.z;

        if (Input.GetButton(PlayerId + "Up")||Input.GetAxis(PlayerId + "JoyU")>0)
        {
            
            moveDirection += Vector2.up;
            rotationAngle = 90;
             FindObjectOfType<AudioControl>().Play("move");
        }
        else if (Input.GetButton(PlayerId + "Down") || Input.GetAxis(PlayerId + "JoyD") < 0)
        {
            moveDirection += Vector2.down;
            rotationAngle = -90;
             FindObjectOfType<AudioControl>().Play("move");
        }
        else if (Input.GetButton(PlayerId + "Left")||Input.GetAxis(PlayerId + "JoyL")<0)
        {
            moveDirection += Vector2.left;
            rotationAngle = 180;
             FindObjectOfType<AudioControl>().Play("move");
        }
        else if (Input.GetButton(PlayerId + "Right") || Input.GetAxis(PlayerId + "JoyR") > 0)
        {
            moveDirection += Vector2.right;
            rotationAngle = 0;
             AudioControl.instance.Play("move");
        }
        
        transform.rotation = Quaternion.Euler(0, 0, rotationAngle);

        if (Input.GetButton(PlayerId + "Fire") && Time.time > nextF)
        {
           
            nextF = Time.time + RateOfFire;
            GetComponent<Shell>().Shoot();
        }
    }

    public void Moving()
    {
        rigid.velocity = moveDirection * Speed * Time.smoothDeltaTime;//smooth it
        
    }

    public void Shield_On()
    {
        playerSH = PlayerShield.GetComponent<Shield>();
        playerSH.ShieldOn();

        //Debug.Log("Worked");
    }

    public void SpeedTimer()
    {
        Stime.FillTimer();
    }
    public void RateTimer()
    {
        Rtime.FillTimer();
    }
}