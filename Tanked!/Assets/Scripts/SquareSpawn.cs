using UnityEngine;

public class SquareSpawn : MonoBehaviour //to select what to spawn inside of each square, such as Block, Power ups, or any gameObject
{
    //referencs
    [SerializeField] private GameObject[] objects;

    //initialization
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