using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class stickBall : MonoBehaviour
{
    public float facingAngle =0;
    float x=0;
    float z=0;
    Vector2 unitV2;
    public GameObject cam;
    float distCam =5;
    public float size =1;
    public GameObject[] category = new GameObject[3];
    public bool[] unlocked = new bool[3];
    public float[] categorySize = new float[3];
    public float velocity = 300f;
    public float rotation = 100f;

    public GameObject UIsize;
    void Start()
    {
        unlockPickUpCategories();
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal")*Time.deltaTime*-rotation;
        z = Input.GetAxis("Vertical")*Time.deltaTime*velocity;
        
        facingAngle+=x;
        unitV2 = new Vector2(Mathf.Cos(facingAngle * Mathf.Deg2Rad),Mathf.Sin(facingAngle*Mathf.Deg2Rad));
    }

    private void FixedUpdate()
    {
        Vector3 auxPos = this.transform.position;
        cam.transform.position = new Vector3(-unitV2.x*distCam,distCam,-unitV2.y*distCam)+auxPos;
        this.transform.GetComponent<Rigidbody>().AddForce(new Vector3(unitV2.x, 0, unitV2.y) * z * 3);
    }

    void unlockPickUpCategories()
    {
        for(int n = 0;n<unlocked.Length;n++){
            if(unlocked[n]==false){
                if(size>=categorySize[n]){
                    unlocked[n]=true;
                    for(int i =0;i<category[n].transform.childCount;i++){
                        category[n].transform.GetChild(i).GetComponent<Collider>().isTrigger = true;
                    }
                }
                break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("sticky"))
        {
            float increase = 0.02f;
            transform.localScale += new Vector3(increase,increase,increase);
            size += increase;
            distCam +=0.08f;
            other.enabled = false;
            other.transform.SetParent(this.transform);
            unlockPickUpCategories();
            UIsize.GetComponent<Text>().text = "Mass: "+Math.Round(size,2).ToString();
        }
    }
}
