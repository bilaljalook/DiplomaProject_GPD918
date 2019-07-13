﻿using UnityEngine;
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
    //public ScoreSystem score;

    // Use this for initialization
    void Start()
    {
        GameObject obj = GameObject.Find("ScoreSystem");
        //score = obj.GetComponent<ScoreSystem>();
        HealthBar();
    }

    // Update is called once per frame
    void Update()
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

        Tank.GetComponent<SpriteRenderer>().enabled = false;
        Tank.GetComponent<Collider2D>().enabled = false;

        NextScene();
    }
    public void NextScene()
    {
        SceneManager.LoadScene(2);
    }
}


