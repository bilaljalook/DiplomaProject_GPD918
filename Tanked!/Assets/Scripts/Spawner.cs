using UnityEngine;

public class Spawner : MonoBehaviour
{
    // References
    public Transform SpawnPoint1;

    public GameObject SpawnPlayer1;

    private void Start()
    {
        SpawnPlayer1.transform.position = SpawnPoint1.position; //Spawner
    }
}