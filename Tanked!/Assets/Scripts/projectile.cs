using UnityEngine;

public class projectile : MonoBehaviour
{
    

    [SerializeField] private float speed = 30f;
    public Rigidbody2D rigid;

    //[SerializeField] private Animation explodingEffect;

    // Use this for initialization
    private void Start()
    {
        rigid.velocity = transform.up * speed;
        //explodingEffect.GetComponent<Animation>();
        //explodingEffect = Instantiate(explodingEffect, transform.position, transform.rotation);
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