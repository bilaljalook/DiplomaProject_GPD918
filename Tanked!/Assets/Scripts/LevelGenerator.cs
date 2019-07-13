using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Transform[] startingPosition;
    public GameObject[] Squares; //indexing 0 is for square1, 1 square 2, 2 s3, 3 s4

    private int Dir;
    public float amount;

    private float TimeToSquare;
    [SerializeField] float startTimeNextSquare=0.25f;

    public float minX;
    public float maxX;
    public float minY;
    public bool stopGen;

    [SerializeField] LayerMask SquareLayer;

    int CalculateDown;
    void Start()
    {
        int RndStartPos = Random.Range(0, startingPosition.Length);
        transform.position = startingPosition[RndStartPos].position;
        Instantiate(Squares[0], transform.position, Quaternion.identity);

        Dir = Random.Range(1, 6);
    }

    private void Update()
    {
        if (TimeToSquare <= 0 && stopGen == false)
        {
            NextDir();
            TimeToSquare = startTimeNextSquare;
        }
        else
        {
            TimeToSquare -= Time.deltaTime;
        }

    }

    private void NextDir()
    {
        if (Dir == 1 || Dir == 2)//to the right
        {
            if (transform.position.x < maxX)
            {
                CalculateDown = 0;


                Vector2 Pos = new Vector2(transform.position.x + amount, transform.position.y);
                transform.position = Pos;

                int rand = Random.Range(0, Squares.Length);
                Instantiate(Squares[rand], transform.position, Quaternion.identity);

                Dir = Random.Range(1, 6);

                if (Dir == 3)
                {
                    Dir = 2;
                }
                else if (Dir == 4)
                {
                    Dir = 5;
                }
            }
                else
                {
                    Dir = 5;
                }
            
        }

        else if (Dir == 3 || Dir == 4)//to the left
        {
            if (transform.position.x > maxX)
            {
                CalculateDown = 0;

                Vector2 Pos = new Vector2(transform.position.x - amount, transform.position.y);
                transform.position = Pos;

                int rand = Random.Range(0, Squares.Length);
                Instantiate(Squares[rand], transform.position, Quaternion.identity);

                Dir = Random.Range(3, 6);
            }
            else
            {
                Dir = 5;
            }
            
        }
        else if (Dir == 5)//to the down
        {
            CalculateDown++;



            if (transform.position.y > minY)
            {
                Collider2D SquareDetect = Physics2D.OverlapCircle(transform.position, 1, SquareLayer);

                if (SquareDetect.GetComponent<SquareSelect>().type!=1&&SquareDetect.GetComponent<SquareSelect>().type!=3)
                {

                    if (CalculateDown>=2)
                    {
                        SquareDetect.GetComponent<SquareSelect>().SquareDestroy();

                        Instantiate(Squares[3], transform.position, Quaternion.identity);
                    }
                    else
                    {
                        SquareDetect.GetComponent<SquareSelect>().SquareDestroy();

                        int RandomSelectRoom = Random.Range(1, 4);
                        if (RandomSelectRoom == 2)
                        {
                            RandomSelectRoom = 1;
                        }
                        Instantiate(Squares[RandomSelectRoom], transform.position, Quaternion.identity);
                    }

                   
                }

                Vector2 Pos = new Vector2(transform.position.x, transform.position.y - amount);
                transform.position = Pos;

                int rand = Random.Range(2, 4);
                Instantiate(Squares[rand], transform.position, Quaternion.identity);

                Dir = Random.Range(1, 6);
            }
            else
            {
                stopGen = true;
            }
            
        }

       
    }
}