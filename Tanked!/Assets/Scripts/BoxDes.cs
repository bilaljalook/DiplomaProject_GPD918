using UnityEngine;

public class BoxDes : MonoBehaviour
{
    [SerializeField] private Animation explodingEffect;
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        projectile projectile = collision.GetComponent<projectile>();

        if (collision.name == ("Projectile 1(Clone)"))
        {
            AudioControl.instance.Play("bHit");
            Destroy(gameObject);
            explodingEffect.GetComponent<Animation>();
            explodingEffect = Instantiate(explodingEffect, transform.position, transform.rotation);
        }
        //Debug.Log("Brick//: " + collision.name);
    }
}