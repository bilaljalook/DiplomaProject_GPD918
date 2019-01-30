using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankBlueprint : MonoBehaviour {
    //TODO clean up the code here

    public int health;
    public int NumHealth;
    
    public Image[] hearts;
    public Sprite MaxHealth;
    public Sprite noHealth;
    public GameObject Tank;

	// Use this for initialization
	void Start () {
        HealthBar();

	}
	
	// Update is called once per frame
	void Update ()
    {
        HealthBar();
	}
    public void TakeDamage(int dmg=1)
    {
        
         health = health - dmg;
         if (health == 0)
         {
            health = health - dmg;
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
        Destroy(Tank,0.1f);
        FindObjectOfType<ScoreSystem>().AddPts();
    }
}
