using UnityEngine;

public class SquareSelect : MonoBehaviour //To spawn the Squares after Generation is done
{
    [SerializeField] private LevelGenerator gen;

    [SerializeField] private GameObject[] EmptySpace; // to choose what exact randoms to generate in the empty space

    private void Update()
    {
        if (gen.StopGen == true) //autocomplete generation
        {
            int random = Random.Range(0, EmptySpace.Length);
            Instantiate(EmptySpace[random], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}