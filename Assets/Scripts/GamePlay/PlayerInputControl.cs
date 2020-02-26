using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputControl : MonoBehaviour
{
    [Header("BasicOperation")]
    public float HorizontalMoveFactor;
    public float VerticalMoveFactor;

    public bool IsFist;
    public bool IsKick;
    public bool IsDodge;



    void Start()
    {
        
    }


    void Update()
    {
        HorizontalMoveFactor = Input.GetAxis("Horizontal");
        VerticalMoveFactor = Input.GetAxis("Vertical");
        IsFist = Input.GetButtonDown("Fist");
        IsKick = Input.GetButtonDown("Kick");
        //IsDodge = Input.GetButtonDown("IsDodge");
    }
}
