using UnityEngine;
using UnityEngine.SceneManagement;

public class BricksWallsBase : MonoBehaviour
{
    //get the star to bes destroyed corectly and go to the next scene, connect it with the score system
    [SerializeField] private GameObject Star;

    ScoreSystem score;
    //[SerializeField] Animation explodingEffect;
    // Use this for initialization
    private void Start()
    {
        //scene = FindObjectOfType<InputControl>();
        Star = GameObject.Find("ScoreSystem");
        score=Star.GetComponent<ScoreSystem>();
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
        //explodingEffect.GetComponent<Animation>();
        //explodingEffect = Instantiate(explodingEffect, transform.position, transform.rotation);
        if (gameObject.name == "star1")
        {
            score.AddPtsP2();
        }

        else if (gameObject.name == "star2")
        {
            score.AddPtsP1();
        }
        FindObjectOfType<TankBlueprint>().NextScene();
        
    }
}