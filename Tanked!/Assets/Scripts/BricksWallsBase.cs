using UnityEngine;
using UnityEngine.SceneManagement;

public class BricksWallsBase : MonoBehaviour
{
    //get the star to bes destroyed corectly and go to the next scene, connect it with the score system
    [SerializeField] private GameObject Star;

    // Use this for initialization
    private void Start()
    {
        //scene = FindObjectOfType<InputControl>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void BlockDestroyed()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        projectile projectile = collision.GetComponent<projectile>();

        //Debug.Log("Star Col//: " + collision.gameObject.tag);
        BlockDestroyed();
        if (gameObject.name == "star")
        {
            SceneManager.LoadScene(2);
        }
    }
}