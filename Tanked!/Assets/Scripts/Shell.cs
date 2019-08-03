using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField] private Transform BarrelPoint;
    [SerializeField] private GameObject ProPre;

    private void Update()
    {
    }

    public void Shoot()
    {
        FindObjectOfType<AudioControl>().Play("Shoot");
        Instantiate(ProPre, BarrelPoint.position, BarrelPoint.rotation);
    }
}