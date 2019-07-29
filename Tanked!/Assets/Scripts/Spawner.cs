using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform SpawnPoint1;
    public GameObject SpawnPlayer1;

    // Use this for initialization
    private void Start()
    {
        SpawnPlayer1.transform.position = SpawnPoint1.position;
    }

    // Update is called once per frame
    private void Update()
    {
    }
}