using System.Collections;
using UnityEngine;


//TODO Power spawn after time, Shield 1 and then random spawn, animation for brick, bricks destroy sprite, sounds for 2 players
public class BricksWallsBase : MonoBehaviour //Base Class
{
    //references
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

    private void OnTriggerEnter2D(Collider2D collision) //when base star is destroyed to stop input, play audio, play animation, add scores
    {
        projectile projectile = collision.GetComponent<projectile>();

        //Debug.Log("Star Col//: " + collision.gameObject.tag);

        PlayerController.stopInput = true;
        AudioControl.instance.Play("explode");
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

    private IEnumerator wait(float t) //to wait for OnTrigger Function finish all lines, thren start next Scene
    {
        yield return new WaitForSeconds(t);
        BlockDestroyed();
        FindObjectOfType<TankBlueprint>().NextScene();
    }
}