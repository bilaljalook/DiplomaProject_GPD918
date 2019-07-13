using UnityEngine;

public class BoxDes : MonoBehaviour
{
    // Start is called before the first frame update
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
            Destroy(gameObject);
        }
        //Debug.Log("Brick//: " + collision.name);
    }
}