using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform startPosition;
    [SerializeField] public GameObject[] Squares; // index S1(0-3), S2(4-7), S3,4,7,8(8-17), S5(18-21), S6(22-25)

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
        Instantiate(Squares[Random.Range(0, 4)], transform.position, Quaternion.identity);
        PlayerController.stopInput = true;
         //Time.timeScale = 0f;
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
        if (SpawnDirection == 1) //Generate Square2, moving Right
        {
            transform.position += Vector3.right * movementAmount;

            int random = Random.Range(4, 8);
            Instantiate(Squares[random], transform.position, Quaternion.identity);

            SpawnDirection++;
        }
        else if (SpawnDirection == 5) // Generate Square6, moving Left
        {
            transform.position += Vector3.left * movementAmount;

            int random = Random.Range(22, 26);
            Instantiate(Squares[random], transform.position, Quaternion.identity);

            SpawnDirection++;
        }
        else if (SpawnDirection >= 2 && SpawnDirection < 5) // Generate Square3,4,5, moving Down
        {
            transform.position += Vector3.down * movementAmount;
            if (SpawnDirection < 4)
            {
                int random = Random.Range(8, 18);
                Instantiate(Squares[random], transform.position, Quaternion.identity);
            }
            else if (SpawnDirection < 5)
            {
                int random = Random.Range(18, 22);
                Instantiate(Squares[random], transform.position, Quaternion.identity);
            }

            SpawnDirection++;
        }
        else if (SpawnDirection >= 6) // Generate Square7,8 , moving Up
        {
            if (transform.position.y < maxY)
            {
                transform.position += Vector3.up * movementAmount;

                int random = Random.Range(8, 18);
                Instantiate(Squares[random], transform.position, Quaternion.identity);

                SpawnDirection++;
            }
            else
            {
                //PlayerController.stopInput = false;
                StopGen = true; //Stop Generating
            }
        }
    }
}