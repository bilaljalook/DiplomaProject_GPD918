using UnityEngine;

public class projectile : MonoBehaviour
{
    //TODO complete the animation proccess for the explosion effect
    //TODO rewire the whole code to make the script connected to only PlayerController script

    [SerializeField] float speed = 20f;
    public Rigidbody2D rigid;

    //public GameObject explosionEffect;

    // Use this for initialization
    private void Start()
    {
        rigid.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TankBlueprint Tank = collision.GetComponent<TankBlueprint>();  // see if here iks the best placxe to actually call all the scoring for the players and stars

        if (Tank != null)
        {
            Tank.TakeDamage(1);
        }

        Destroy(gameObject);
    }
}