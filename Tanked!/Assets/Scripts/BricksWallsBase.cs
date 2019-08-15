using System.Collections;
using UnityEngine;

public class BricksWallsBase : MonoBehaviour //Base Class
{
    //references
    [SerializeField] private GameObject star;

    [SerializeField] private Animation explodingEffect;

    private ScoreSystem score;

    private void Start()
    {
        star = GameObject.Find("ScoreSystem");
        score = star.GetComponent<ScoreSystem>();
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