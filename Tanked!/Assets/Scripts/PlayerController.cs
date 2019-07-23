using UnityEngine;

//TODO fix the movement bug when pressing to direction at the same time.
//TODO Finish the input of the player in unity editor
//TODO The score system need get a reference to the playerId and put it in the gamemanager
public class PlayerController : MonoBehaviour
{
    public string PlayerId;
    [SerializeField] public float Speed = 0.5f;
    [SerializeField] public float RateOfFire = 1.5f;
    [SerializeField] GameObject PlayerShield;

    Shield playerSH;
    Rigidbody2D rigid;
    Vector2 moveDirection;
    float rotationAngle;
    float nextF = 0.0f;

    public ScoreSystem score;
    //private bool update = false;

    public GameObject SpawnPoint;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        PlayerId = PlayerId + " ";
    }

    private void Update()
    {
        GetInput();

       /* if (!update)
        {
            IsDead();
        }*/
        Moving();
    }

    private void GetInput()
    {
        moveDirection = Vector2.zero;

        float rotationAngle = transform.rotation.eulerAngles.z;

        if (Input.GetButton(PlayerId + "Up"))
        {
            moveDirection += Vector2.up;
            rotationAngle = 90;
        }
        else if (Input.GetButton(PlayerId + "Down"))
        {
            moveDirection += Vector2.down;
            rotationAngle = -90;
        }
        else if (Input.GetButton(PlayerId + "Left"))
        {
            moveDirection += Vector2.left;
            rotationAngle = 180;
        }
        else if (Input.GetButton(PlayerId + "Right"))
        {
            moveDirection += Vector2.right;
            rotationAngle = 0;
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
        rigid.velocity = moveDirection * Speed * Time.deltaTime;
    }

    public void IsDead()
    {
        //if (gameObject.GetComponent<SpriteRenderer>().enabled == false && gameObject.CompareTag("Player1")==null)
        //{
        //    score.AddPtsP2();
        //    update = true;
        //    Debug.Log("playedr2 up");
        //}
        //else if (gameObject.GetComponent<SpriteRenderer>().enabled==false&&PlayerId=="Player2")
        //{
        //    score.AddPtsP1();
        //    update = true;
        //    Debug.Log("Player1 up");
        //}
    }

    public void Shield_On()
    {
        playerSH = PlayerShield.GetComponent<Shield>();
        playerSH.ShieldOn();
        
        //Debug.Log("Worked");
    }
}