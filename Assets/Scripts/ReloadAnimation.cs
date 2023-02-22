using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadAnimation : MonoBehaviour
{
    public Animator animator;
    public float animationSpeed = 1f;

    private Revolver revolver;
    private float reloadTime = 0f;

    void Start()
    {
        revolver = GetComponentInParent<Revolver>();
        reloadTime = revolver.reloadSpeed;
    }

    void Update()
    {
        if (revolver.isReload)
        {
            animator.speed = animationSpeed;
            animator.SetBool("ReloadTrigger", true);
            StartCoroutine(ReloadFinished(reloadTime));
        }
    }

    IEnumerator ReloadFinished(float time)
    {
        yield return new WaitForSeconds(time);
        animator.SetBool("ReloadTrigger", false);
        revolver.isReload = false;
    }
}
