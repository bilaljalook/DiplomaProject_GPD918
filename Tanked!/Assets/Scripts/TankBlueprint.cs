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

    //[SerializeField] GameObject starBase;
    //[SerializeField] Animation explodingEffect;

    // Use this for initialization
    private void Start()
    {
        GameObject obj = GameObject.Find("ScoreSystem");
        
         //star = starBase.GetComponent<BricksWallsBase>();
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
        if (health == 0)
        {
            Die();
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

     void Die()
    {
        //Tank.GetComponent<SpriteRenderer>().enabled = false;
        //Tank.GetComponent<Collider2D>().enabled = false;
        Tank.SetActive(false);
        if (Tank.CompareTag("Player1")==false )
        {
        score.AddPtsP1();

        }
        else if (Tank.CompareTag("Player2")==false )
        {
        score.AddPtsP2();
        }
        Destroy(gameObject);
        //explodingEffect.GetComponent<Animation>();
        //explodingEffect = Instantiate(explodingEffect, transform.position, transform.rotation);
        NextScene();
    }
    //public void DieStar()
    //{
    //    //Tank.GetComponent<SpriteRenderer>().enabled = false;
    //    //Tank.GetComponent<Collider2D>().enabled = false;
        
    //    if ( starBase.name == "star2")
    //    {
    //        score.AddPtsP1();

    //    }
    //    else 
    //    {
    //        score.AddPtsP2();
    //    }
        
    //    //explodingEffect.GetComponent<Animation>();
    //    //explodingEffect = Instantiate(explodingEffect, transform.position, transform.rotation);
    //    NextScene();
    //}

    public void NextScene()
    {
       
        if (ScoreSystem.rCount<2)
        {

        SceneManager.LoadScene("Rounds");
        }
         if(ScoreSystem.rCount==3)
        {
            SceneManager.LoadScene("GameOver");
            
        }
            ScoreSystem.RoundCount();
        Debug.Log(ScoreSystem.rCount.ToString());
    }
}