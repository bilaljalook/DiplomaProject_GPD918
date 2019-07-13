using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField] private Transform BarrelPoint;
    [SerializeField] private GameObject ProPre;

    //[SerializeField] public GameObject ShooterPlayer;
    public bool SelectShooter;

    // Update is called once per frame
    private void Update()
    {
    }

    public void Shoot()
    {
        Instantiate(ProPre, BarrelPoint.position, BarrelPoint.rotation);
    }
}