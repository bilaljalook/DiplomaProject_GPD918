using UnityEngine;

public class AnimationDestroy : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Animator Anim;
    [SerializeField] private float finishTimeAnim;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Anim.isActiveAndEnabled)
        {
            Destroy(gameObject, finishTimeAnim);
        }
    }
}