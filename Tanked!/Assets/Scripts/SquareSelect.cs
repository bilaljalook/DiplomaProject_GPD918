using UnityEngine;

public class SquareSelect : MonoBehaviour
{
    [SerializeField] private LayerMask selectSquare;
    [SerializeField] private LevelGenerator gen;
    [SerializeField] GameObject[] EmptySpace; // to choose what exact randoms to generate in the empty space
    [SerializeField] GameObject[] chooseRandomInsideRoom;
    

    private void Start()
    {
        //int rand = Random.Range(0, chooseRandomGenerate.Length);
        //Instantiate(chooseRandomGenerate[rand], transform.position, Quaternion.identity);
    }
    private void Update()
    {
        Collider2D ifSquareSpawn = Physics2D.OverlapCircle(transform.position, 1, selectSquare);
        if (ifSquareSpawn == null && gen.StopGen == true) //autocomplete generation
        {
            int random = Random.Range(0, EmptySpace.Length);
            Instantiate(EmptySpace[random], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}