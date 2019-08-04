using System.Collections;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    //TODO make the declarations of the script private for the ones you dont need
    public ParticleSystem effect;

    [SerializeField] private Animation animEffect;

    private float speedUp = 2100;
    private float rateSpeed = 0.8f;

    private SpriteRenderer spriteRenderer;
    private Collider2D col;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController pc = collision.GetComponent<PlayerController>();

        if (gameObject.CompareTag("PowerUpSpeed"))
        {
            StartCoroutine(PickPowerSpeed(pc));
            
        }
        else if (gameObject.CompareTag("PowerUpRate"))
        {
            StartCoroutine(PickPowerRate(pc));
            
        }
        else if (gameObject.CompareTag("PowerUpShield"))
        {
            StartCoroutine(PickPowerShield(pc));
        }
    }

    private void DisableComponentsAndPlayEffect()
    {
        spriteRenderer.enabled = false;
        col.enabled = false;

        
        animEffect.GetComponent<Animation>();
        animEffect = Instantiate(animEffect, transform.position, transform.rotation);
    }

    private IEnumerator PickPowerSpeed(PlayerController player)
    {
        FindObjectOfType<AudioControl>().Play("powerUp");
        DisableComponentsAndPlayEffect();
        FindObjectOfType<PlayerController>().SpeedTimer();
        player.Speed += speedUp;

        yield return new WaitForSeconds(3);
        player.Speed -= speedUp;

        Destroy(gameObject);
    }

    private IEnumerator PickPowerRate(PlayerController player)
    {
        FindObjectOfType<AudioControl>().Play("powerUp");
        DisableComponentsAndPlayEffect();
        FindObjectOfType<PlayerController>().RateTimer();
        player.RateOfFire -= rateSpeed;

        yield return new WaitForSeconds(3);
        player.RateOfFire += rateSpeed;

        Destroy(gameObject);
    }

    private IEnumerator PickPowerShield(PlayerController player)
    {
         FindObjectOfType<AudioControl>().Play("shield");
        //Debug.Log(player.name); //to check which player getting the shield
        DisableComponentsAndPlayEffect();

        player.Shield_On();

        yield return 0;
    }
}