using UnityEngine;

public class projectile : MonoBehaviour
{
    //references

    [SerializeField] private float speed = 30f;
    public Rigidbody2D rigid;

    //initialization
    private void Start()
    {
        rigid.velocity = transform.up * speed; //Moving the projectile
    }

    private void OnTriggerEnter2D(Collider2D collision) //How the Projectile affect players
    {
        TankBlueprint Tank = collision.GetComponent<TankBlueprint>();

        if (Tank != null)
        {
            Tank.TakeDamage(1);
        }

        Destroy(gameObject);
    }
}