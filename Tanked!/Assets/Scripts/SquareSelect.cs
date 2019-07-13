using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareSelect : MonoBehaviour
{
    // Start is called before the first frame update
    public int type;

    public void SquareDestroy()
    {
        Destroy(gameObject);
    }
}
