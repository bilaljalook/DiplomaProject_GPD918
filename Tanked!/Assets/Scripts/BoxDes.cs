using UnityEngine;
using System.Collections;

public class BoxDes : MonoBehaviour // Bricks class
{
    //references
    [SerializeField] private Animation explodingEffect;
    [SerializeField] Sprite[] sprite;
    SpriteRenderer renderSprite;

    private void Start()
    {
        renderSprite= GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision) //destroy and call audio and animation
    {
        projectile projectile = collision.GetComponent<projectile>();

        if (collision.name == ("Projectile 1(Clone)"))
        {
            AudioControl.instance.Play("bHit");
            //Destroy(gameObject); 
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            renderSprite.enabled = false;
            explodingEffect.GetComponent<Animation>();
            explodingEffect = Instantiate(explodingEffect, transform.position, transform.rotation);
            StartCoroutine(AfterAnimation(0.6f));
        }
        //Debug.Log("Brick//: " + collision.name);
    }

    void SpriteChange()
    {
        renderSprite.enabled = true;
        renderSprite.sprite = sprite[Random.Range(0,3)];
        renderSprite.color = new Color(1f, 1f, 1f, .7f);
       
        
    }

    IEnumerator AfterAnimation(float t)
    {


        yield return new WaitForSeconds(t);
        SpriteChange();
    }
}