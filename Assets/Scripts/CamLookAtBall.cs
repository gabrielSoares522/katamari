using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLookAtBall : MonoBehaviour
{
    public GameObject ball;

    Vector3 lookAtOffSet;
    
    void Start()
    {
        lookAtOffSet = new Vector3(0,1.5f,0);
    }

    void Update()
    {
        //transform.LookAt(ball.transform.position+lookAtOffSet);
    }
}
