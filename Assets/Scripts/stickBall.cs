using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stickBall : MonoBehaviour
{
    public float facingAngle =0;
    float x=0;
    float z=0;
    Vector2 unitV2;

    public GameObject cam;
    float distCam =5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal")*Time.deltaTime*-100;
        z = Input.GetAxis("Vertical")*Time.deltaTime*500;
        facingAngle+=x;
        unitV2 = new Vector2(Mathf.Cos(facingAngle * Mathf.Deg2Rad),Mathf.Sin(facingAngle*Mathf.Deg2Rad));
    }

    private void FixedUpdate()
    {
        cam.transform.position = new Vector3(-unitV2.x*distCam,distCam,-unitV2.y*distCam)+this.transform.position;
        this.transform.GetComponent<Rigidbody>().AddForce(new Vector3(unitV2.x, 0, unitV2.y) * z * 3);
    }
}
