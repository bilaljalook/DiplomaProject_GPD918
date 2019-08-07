using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TankBlueprint : MonoBehaviour
{
    //TODO clean up the code here

    public int health;
    public int NumHealth;

    public Image[] hearts;
    public Sprite MaxHealth;
    public Sprite noHealth;
    public GameObject Tank;
    public ScoreSystem score;

    //BricksWallsBase star;

    
    [SerializeField] private Animation explodingEffect;

    // Use this for initialization
    private void Start()
    {
        GameObject obj = GameObject.Find("ScoreSystem");

        
        score = obj.GetComponent<ScoreSystem>();
        HealthBar();
    }

    // Update is called once per frame
    private void Update()
    {
        HealthBar();
    }

    public void TakeDamage(int dmg = 1)
    {
        health = health - dmg;
        AudioControl.instance.Play("tHit");
        if (health == 0)
        {
            PlayerController.stopInput = true;
            AudioControl.instance.Play("explode");

            explodingEffect.GetComponent<Animation>();
            explodingEffect = Instantiate(explodingEffect, transform.position, transform.rotation);
            StartCoroutine(wait(1f));
        }
    }

    public void HealthBar()
    {
        if (health > NumHealth)
        {
            health = NumHealth;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = MaxHealth;
            }
            else
            {
                hearts[i].sprite = noHealth;
            }
            if (i < NumHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    private void Die()
    {
        //Tank.GetComponent<SpriteRenderer>().enabled = false;
        //Tank.GetComponent<Collider2D>().enabled = false;
        Tank.SetActive(false);
        if (Tank.CompareTag("Player1") == false)
        {
            score.AddPtsP1();
        }
        else if (Tank.CompareTag("Player2") == false)
        {
            score.AddPtsP2();
        }

        NextScene();
    }

    public void NextScene()
    {
        PlayerController.stopInput = false;
        if (ScoreSystem.rCount < 2)
        {
            SceneManager.LoadScene("Rounds");
        }

        ScoreSystem.RoundCount();
        Debug.Log(ScoreSystem.rCount.ToString());
    }

    private IEnumerator wait(float t)
    {
        yield return new WaitForSeconds(t);
        Die();
        Destroy(gameObject);
    }
}