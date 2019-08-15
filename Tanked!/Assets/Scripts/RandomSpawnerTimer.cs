using System.Collections;
using UnityEngine;

public class RandomSpawnerTimer : MonoBehaviour
{
    public Transform[] SpawnPoint;

    public GameObject[] SpawnObject;

    private bool startAgain = true;

    private void Start()
    {
        //transform.position=SpawnPoint[SpawnObject.Length].position;

        StartCoroutine(SpawnTimer());
    }

    private void Update()
    {
    }

    private IEnumerator SpawnTimer()
    {
        while (startAgain == true)
        {
            yield return new WaitForSeconds(2);
            if (GameObject.FindGameObjectWithTag("PowerUpRate") == false || GameObject.FindGameObjectWithTag("PowerUpSpeed") == false)
            {
                Instantiate(SpawnObject[Random.Range(0, 2)], SpawnPoint[Random.Range(0, SpawnPoint.Length)].position, Quaternion.identity);
                Instantiate(SpawnObject[Random.Range(0, 2)], SpawnPoint[Random.Range(0, SpawnPoint.Length)].position, Quaternion.identity);
                Debug.Log(SpawnObject.ToString());
            }

            startAgain = false;
            yield return new WaitForSeconds(2);
            startAgain = true;
        }
    }
}