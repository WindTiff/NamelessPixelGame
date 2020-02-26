using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControl : MonoBehaviour
{

    private Animator monkAnimator;
    private BasicMovement scpt_BasicMovement;

    void Start()
    {
        monkAnimator = GetComponent<Animator>();
        scpt_BasicMovement = GetComponent<BasicMovement>();
    }


    void Update()
    {
        monkAnimator.SetFloat("Ypara", scpt_BasicMovement.yFactor);
    }
}
