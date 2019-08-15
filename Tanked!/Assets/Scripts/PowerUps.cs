using System.Collections;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    //referencs
    public ParticleSystem effect;

    [SerializeField] private Animation animEffect;

    private float speedUp = 2100;
    private float rateSpeed = 0.8f;

    private SpriteRenderer spriteRenderer;
    private Collider2D col;

    //initialization
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision) //couroutines for Powerups on collision
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

    private void DisableComponentsAndPlayEffect() //disable sprites and colliders of power up
    {
        spriteRenderer.enabled = false;
        col.enabled = false;

        animEffect.GetComponent<Animation>();
        animEffect = Instantiate(animEffect, transform.position, transform.rotation);
    }

    private IEnumerator PickPowerSpeed(PlayerController player)//disable power, call audio clip, set speed power up of player
    {
        AudioControl.instance.Play("powerUp");
        DisableComponentsAndPlayEffect();
        player.FillSpeedTimer();
        player.Speed += speedUp;

        yield return new WaitForSeconds(3);
        player.Speed -= speedUp;

        Destroy(gameObject);
    }

    private IEnumerator PickPowerRate(PlayerController player)//disable power, call audio clip, set fire rate power up player
    {
        AudioControl.instance.Play("powerUp");
        DisableComponentsAndPlayEffect();
        player.FillRateTimer();
        player.RateOfFire -= rateSpeed;

        yield return new WaitForSeconds(3);
        player.RateOfFire += rateSpeed;

        Destroy(gameObject);
    }

    private IEnumerator PickPowerShield(PlayerController player) //disable power, call audio clip, calls shield
    {
        AudioControl.instance.Play("shield");
        //Debug.Log(player.name); //to check which player getting the shield
        DisableComponentsAndPlayEffect();

        player.ActivateShield();

        yield return 0;
    }
}