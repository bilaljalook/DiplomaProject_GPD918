using System.Collections;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    //TODO make the declarations of the script private for the ones you dont need
    public ParticleSystem effect;

    public float speedUp = 2;
    public float rateSpeed = 1;

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

        effect = Instantiate(effect, transform.position, transform.rotation) as ParticleSystem;
        effect.GetComponent<ParticleSystem>();
    }

    private IEnumerator PickPowerSpeed(PlayerController player)
    {
        DisableComponentsAndPlayEffect();

        player.Speed += speedUp;

        yield return new WaitForSeconds(2);
        player.Speed -= speedUp;

        Destroy(gameObject);
    }

    private IEnumerator PickPowerRate(PlayerController player)
    {
        DisableComponentsAndPlayEffect();

        player.RateOfFire -= rateSpeed;

        yield return new WaitForSeconds(2);
        player.RateOfFire += rateSpeed;

        Destroy(gameObject);
    }

    private IEnumerator PickPowerShield(PlayerController player)
    {
        //Debug.Log(player.name);
        DisableComponentsAndPlayEffect();

        player.Shield_On();
        

        yield return 0;
    }
}