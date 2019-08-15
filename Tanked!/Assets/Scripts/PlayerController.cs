using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //References
    public string PlayerId;

    public float Speed = 0.5f;
    public float RateOfFire = 1.5f;
    [SerializeField] private GameObject PlayerShield;

    private Shield playerSH;
    private Rigidbody2D rigid;
    private Vector2 moveDirection;
    private float rotationAngle;
    private float nextF = 0.0f;

    public ScoreSystem score;

    public GameObject SpawnPoint;

    public static bool stopInput = false;

    [SerializeField] private Timer Stime;
    [SerializeField] private Timer Rtime;

    private void Start()
    {
        Stime.GetComponent<GameObject>();
        Rtime.GetComponent<GameObject>();
        rigid = GetComponent<Rigidbody2D>();
        PlayerId = PlayerId + " ";
    }

    private void Update()
    {
        // for Movements and stopping/enabling input on certain times
        if (stopInput == false)
        {
            GetInput();

            Moving();
        }
    }

    private void GetInput() //direction movement and shooting for Keyboard and joystick
    {
        moveDirection = Vector2.zero;

        float rotationAngle = transform.rotation.eulerAngles.z;

        if (Input.GetButton(PlayerId + "Up") || Input.GetAxis(PlayerId + "JoyU") > 0)
        {
            moveDirection += Vector2.up;
            rotationAngle = 90;
            
        }
        else if (Input.GetButton(PlayerId + "Down") || Input.GetAxis(PlayerId + "JoyD") < 0)
        {
            moveDirection += Vector2.down;
            rotationAngle = -90;
           
        }
        else if (Input.GetButton(PlayerId + "Left") || Input.GetAxis(PlayerId + "JoyL") < 0)
        {
            moveDirection += Vector2.left;
            rotationAngle = 180;
            
        }
        else if (Input.GetButton(PlayerId + "Right") || Input.GetAxis(PlayerId + "JoyR") > 0)
        {
            moveDirection += Vector2.right;
            rotationAngle = 0;
            
        }
        if (moveDirection!=Vector2.zero)
        {
            AudioControl.instance.Play(PlayerId+"move");

        }

        transform.rotation = Quaternion.Euler(0, 0, rotationAngle);

        if (Input.GetButton(PlayerId + "Fire") && Time.time > nextF)
        {
            nextF = Time.time + RateOfFire;
            GetComponent<Shell>().Shoot();
        }
    }

    public void Moving() //movement
    {
        rigid.velocity = moveDirection * Speed * Time.smoothDeltaTime;
    }

    public void ActivateShield() //calling shield class from Power up Class
    {
        playerSH = PlayerShield.GetComponent<Shield>();
        playerSH.ActivateShieldOn();

        //Debug.Log("Worked");
    }

    public void FillSpeedTimer() //call speed timer from Timer Class
    {
        Stime.FillTimer();
    }

    public void FillRateTimer() //call fire rate timer from Timer Class
    {
        Rtime.FillTimer();
    }
}