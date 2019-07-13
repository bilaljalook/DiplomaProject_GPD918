using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareSpawn : MonoBehaviour
{
    [SerializeField] LayerMask RandomSquare;
    public LevelGenerator Gen;//maybe chnage to private

    void Update()
    {
        Collider2D SquareDetection = Physics2D.OverlapCircle(transform.position, 1, RandomSquare);

        if (SquareDetection==null&&Gen.stopGen==true)
        {
            //Random Squares
            int Rand = Random.Range(0, Gen.Squares.Length);
            Instantiate(Gen.Squares[Rand], transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
