using UnityEngine;

public class Shell : MonoBehaviour //the spawn point of the Projectile
{
    [SerializeField] private Transform BarrelPoint;
    [SerializeField] private GameObject ProPre;

    public void Shoot()
    {
        
        Instantiate(ProPre, BarrelPoint.position, BarrelPoint.rotation);
    }
}