using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationDestroy : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Animator Anim;
    [SerializeField] float finishTimeAnim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Anim.isActiveAndEnabled)
        {
            Destroy(gameObject, finishTimeAnim);
        }
    }

    
}
