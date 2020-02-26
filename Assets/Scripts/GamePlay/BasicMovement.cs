using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float yFactor;
    public float xFactor;

    public SimpleTouchController DirectionController;
    public float MoveRangeHorizontal;
    public float MoveRangeYVertical;


    [Range(0,0.005f)]
    public float MoveSpeed=0.001f;//移动速度

    void Start()
    {
        
    }


    void Update()
    {
        MoveControl();
    }

    public void MoveControl() {
        xFactor = Input.GetAxis("Horizontal");
        yFactor = Input.GetAxis("Vertical");



        //transform.position += new Vector3(DirectionController.GetTouchPosition.x, DirectionController.GetTouchPosition.y, 0)* MoveSpeed;

        transform.position += new Vector3(xFactor, yFactor, 0) * MoveSpeed;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -MoveRangeHorizontal, MoveRangeHorizontal), Mathf.Clamp(transform.position.y, -MoveRangeYVertical, MoveRangeYVertical), 0);



    }


}
