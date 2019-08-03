using System.Collections;
using UnityEngine;


public class PowerUps : MonoBehaviour
{
    //TODO make the declarations of the script private for the ones you dont need
    public ParticleSystem effect;
    [SerializeField] Animation animEffect;

    float speedUp = 3500;
    float rateSpeed = 1;

    private SpriteRenderer spriteRenderer;
    private Collider2D col;

    //[SerializeField] GameObject timer;
    //Timer refTimer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        //refTimer.GetComponent<Timer>();
        //timer.GetComponent<GameObject>();
        //refTimer=timer.GetComponent<Timer>();
        //GetComponent<Slider>();
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
            //pc.PowerUpTimerSpeed();
            //refTimer.FillTimer();
        }
        else if (gameObject.CompareTag("PowerUpRate"))
        {
            StartCoroutine(PickPowerRate(pc));
            // pc.PowerUpTimerFire();
            //refTimer.FillTimer();
            //FindObjectOfType<PlayerController>().PowerUpTimerFire();
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
        
        
        //Timer.FillTimer();
        animEffect.GetComponent<Animation>();
        animEffect = Instantiate(animEffect, transform.position, transform.rotation);
        
       
        
    }

    private IEnumerator PickPowerSpeed(PlayerController player)
    {
        DisableComponentsAndPlayEffect();

        player.Speed += speedUp;
        
        yield return new WaitForSeconds(3);
        player.Speed -= speedUp;

        Destroy(gameObject);
    }

    private IEnumerator PickPowerRate(PlayerController player)
    {
        DisableComponentsAndPlayEffect();

        player.RateOfFire -= rateSpeed;
        
        yield return new WaitForSeconds(3);
        player.RateOfFire += rateSpeed;

        Destroy(gameObject);
    }

    private IEnumerator PickPowerShield(PlayerController player)
    {
        //Debug.Log(player.name); //to check which player getting the shield
        DisableComponentsAndPlayEffect();

        player.Shield_On();

        yield return 0;
    }

}