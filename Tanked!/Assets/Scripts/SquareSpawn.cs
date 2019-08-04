using UnityEngine;

public class SquareSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;
    //[SerializeField] GameObject[] randomPickUp;

    private void Start()
    {
        SpawnTheRest();
    }

    private void SpawnTheRest()
    {
        int Randomize = Random.Range(0, objects.Length);
        GameObject instance = (GameObject)Instantiate(objects[Randomize], transform.position, Quaternion.identity);
        instance.transform.parent = transform;
    }
}