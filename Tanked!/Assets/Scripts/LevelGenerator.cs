using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform startPosition;
    [SerializeField] public GameObject[] Squares; //TODO Index the square to get the randoms u need

    [SerializeField] private float movementAmount;
    private int SpawnDirection = 1;

    [SerializeField] private float startTimeToSquare = 0.2f;
    private float TimeToSquare;

    //[SerializeField] float minX;
    //[SerializeField] float maxX;
    [SerializeField] private float maxY;

    public bool StopGen;

    private void Start()
    {
        transform.position = startPosition.position;
        Instantiate(Squares[0], transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if (TimeToSquare <= 0 && StopGen == false)
        {
            MoveSquare();
            TimeToSquare = startTimeToSquare;
        }
        else
        {
            TimeToSquare -= Time.deltaTime;
        }
    }

    private void MoveSquare()
    {
        if (SpawnDirection == 1) // Square Generate right
        {
            /*Vector2 Pos = new Vector2(transform.position.x + movementAmount, transform.position.y);
            transform.position = Pos;*/

            transform.position += Vector3.right * movementAmount;
            int random = Random.Range(0, Squares.Length);
            Instantiate(Squares[random], transform.position, Quaternion.identity);
            SpawnDirection++;
        }
        else if (SpawnDirection == 5) // Square Generate left
        {
            /* Vector2 Pos = new Vector2(transform.position.x - movementAmount, transform.position.y);
             transform.position = Pos;*/

            transform.position += Vector3.left * movementAmount;
            int random = Random.Range(0, Squares.Length);
            Instantiate(Squares[random], transform.position, Quaternion.identity);
            SpawnDirection++;
        }
        else if (SpawnDirection >= 2 && SpawnDirection < 5) // Square Generate down
        {
            /*Vector2 Pos = new Vector2(transform.position.x, transform.position.y - movementAmount);
            transform.position = Pos;*/

            transform.position += Vector3.down * movementAmount;
            int random = Random.Range(0, Squares.Length);
            Instantiate(Squares[random], transform.position, Quaternion.identity);

            SpawnDirection++;
        }
        else if (SpawnDirection >= 6) // Generate Up
        {
            if (transform.position.y < maxY)
            {
                /*Vector2 Pos = new Vector2(transform.position.x, transform.position.y + movementAmount);
                transform.position = Pos;*/

                transform.position += Vector3.up * movementAmount;

                int random = Random.Range(0, Squares.Length);
                Instantiate(Squares[random], transform.position, Quaternion.identity);

                SpawnDirection++;
            }
            else
            {
                StopGen = true; //Stop Generating
            }
        }

        //Instantiate(Squares[0], transform.position, Quaternion.identity);
    }
}