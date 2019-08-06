using System.Collections;
using UnityEngine;

public class BricksWallsBase : MonoBehaviour
{
    
    [SerializeField] private GameObject Star;

    private ScoreSystem score;
    [SerializeField] private Animation explodingEffect;

    
    private void Start()
    {
        
        Star = GameObject.Find("ScoreSystem");
        score = Star.GetComponent<ScoreSystem>();
    }

    
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

        PlayerController.stopInput = true;
        FindObjectOfType<AudioControl>().Play("explode");
        explodingEffect.GetComponent<Animation>();
        explodingEffect = Instantiate(explodingEffect, transform.position, transform.rotation);
        StartCoroutine(wait(.8f));
        if (gameObject.name == "star1")
        {
            score.AddPtsP2();
        }
        else if (gameObject.name == "star2")
        {
            score.AddPtsP1();
        }
    }

    private IEnumerator wait(float t)
    {
        yield return new WaitForSeconds(t);
        BlockDestroyed();
        FindObjectOfType<TankBlueprint>().NextScene();
    }
}