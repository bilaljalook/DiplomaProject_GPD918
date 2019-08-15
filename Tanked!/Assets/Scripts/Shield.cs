using UnityEngine;

public class Shield : MonoBehaviour //Script for Shield Spawn
{
    //References
    [SerializeField] private GameObject BlockShield;

    [SerializeField] private LayerMask Tank;

    private void Start()
    {
        BlockShield.GetComponent<PlayerController>();
    }

    private void Update()
    {
    }

    public void ActivateShieldOn()
    {
        Instantiate(BlockShield, transform.position, Quaternion.identity);
        Collider2D shield = Physics2D.OverlapCircle(transform.position, 1, Tank);

        if (shield == true)
        {
            Destroy(gameObject);
        }
        //Debug.Log(gameObject.name);
    }
}