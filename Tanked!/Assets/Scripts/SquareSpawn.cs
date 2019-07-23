using UnityEngine;

public class SquareSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;

    private void Start()
    {
        int Randomize = Random.Range(0, objects.Length);
        GameObject instance = (GameObject)Instantiate(objects[Randomize], transform.position, Quaternion.identity);
        instance.transform.parent = transform;
    }
}