using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private GameObject BlockShield;

    private void Start()
    {
        BlockShield.GetComponent<PlayerController>();
    }

    private void Update()
    {
    }

    public void ShieldOn()
    {
        BlockShield.SetActiveRecursively(true);

        Debug.Log(gameObject.name);
    }
}