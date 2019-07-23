using UnityEngine;

//TODO need to delete this and make all the players on the same script

public class PlayerController2 : MonoBehaviour
{
    //TODO clean the serialized field in all scripts

    [SerializeField] public float Speed = 0.5f;
    private float vertical1;
    private float horizontal1;
    [SerializeField] private float limit = 0.7f;
    private Rigidbody2D rigid;
    private Vector2 moveDirection;
    private float rotationAngle;
    private float smoothTime = 1.0f;
    private Quaternion desiredRotation;
    [SerializeField] public float RateOfFire = 1.5f;
    private float nextF = 0.0f;
    public ScoreSystem score;
    private bool update = false;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        GameObject obj = GameObject.Find("ScoreSystem");
        score = obj.GetComponent<ScoreSystem>();
        IsDead();
    }

    private void Update()
    {
        horizontal1 = Input.GetAxisRaw("Horizontal1");
        vertical1 = Input.GetAxisRaw("Vertical1");
        GetInput1();
        desiredRotation = Quaternion.Euler(0, 0, rotationAngle);

        if (!update)
        {
            IsDead();
        }
    }

    private void FixedUpdate()
    {
        if (horizontal1 != 0 && vertical1 != 0)
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
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveDirection += Vector2.up;

            rigid.constraints = RigidbodyConstraints2D.None;
            rigid.constraints = RigidbodyConstraints2D.FreezePositionX;
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothTime);
            rotationAngle = 90;
            rigid.transform.Rotate(0, 0, rotationAngle);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveDirection += Vector2.down;
            rigid.constraints = RigidbodyConstraints2D.None;
            rigid.constraints = RigidbodyConstraints2D.FreezePositionX;
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothTime);
            rotationAngle = -90;
            rigid.transform.Rotate(0, 0, rotationAngle);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveDirection += Vector2.left;
            rigid.constraints = RigidbodyConstraints2D.None;
            rigid.constraints = RigidbodyConstraints2D.FreezePositionY;
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothTime);
            rotationAngle = 180;
            rigid.transform.Rotate(0, 0, rotationAngle);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveDirection += Vector2.right;
            rigid.constraints = RigidbodyConstraints2D.None;
            rigid.constraints = RigidbodyConstraints2D.FreezePositionY;
            transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, smoothTime);
            rotationAngle = 0;
            rigid.transform.Rotate(0, 0, rotationAngle);
        }
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextF)
        {
            nextF = Time.time + RateOfFire;
            GetComponent<Shell>().Shoot();
            //FindObjectOfType<Shell>().SelectShooter = false;
        }
    }

    public void Moving()
    {
        rigid.velocity = new Vector2((horizontal1 * Speed), (vertical1 * Speed));
    }

    public void IsDead()
    {
        if (gameObject.GetComponent<SpriteRenderer>().enabled == false)
        {
            score.AddPtsP1();
            update = true;
            Debug.Log("adding1");
        }
    }
}