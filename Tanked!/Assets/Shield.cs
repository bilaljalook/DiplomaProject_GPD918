using UnityEngine;

//TODO finish the shield to make it work
public class Shield : MonoBehaviour
{
    [SerializeField] private GameObject BlockShield;

    // Start is called before the first frame update
    private void Start()
    {
        BlockShield.GetComponent<PlayerController>();
        //BlockShield.GetComponent<GameObject>();
        //ShieldOn();
    }
    // Update is called once per frame
    private void Update()
    {
    }

    //[System.Obsolete]
    public void ShieldOn()
    {
        BlockShield.SetActiveRecursively(true);

        Debug.Log(gameObject.name);
        
    }
}