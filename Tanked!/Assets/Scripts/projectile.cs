using UnityEngine;

public class projectile : MonoBehaviour
{
    

    [SerializeField] private float speed = 30f;
    public Rigidbody2D rigid;



    // Use this for initialization
    private void Start()
    {
        rigid.velocity = transform.up * speed;
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TankBlueprint Tank = collision.GetComponent<TankBlueprint>();  

        if (Tank != null)
        {
            Tank.TakeDamage(1);
        }

        Destroy(gameObject);
    }
}