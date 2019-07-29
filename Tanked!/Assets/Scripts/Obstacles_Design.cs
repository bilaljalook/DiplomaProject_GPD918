using UnityEngine;

public class Obstacles_Design : MonoBehaviour
{
    //TODO hier where all the walls and obstacles goes, plus try to generate the map aswell

    //[SerializeField] GameObject Bricks;

    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void BrickDestroyed()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        projectile pro = collision.gameObject.GetComponent<projectile>();

        // Debug.Log(collision);
    }
}