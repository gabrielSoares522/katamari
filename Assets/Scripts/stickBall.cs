using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class stickBall : MonoBehaviour
{
    [SerializeField]
    public List<Category> categories = new List<Category>(3); 
    public float velocity = 300f;
    public float rotation = 100f;
    public GameObject cam;
    public Text UIsize;
    public Transform core;

    private float facingAngle = 0;
    private float distCam = 5;
    private float size = 1;
    private float x = 0;
    private float z = 0;
    private Vector2 unitV2;

    void Start()
    {
        unlockPickUpCategories();
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal") * Time.deltaTime * -rotation;
        z = Input.GetAxis("Vertical") * Time.deltaTime * velocity;
        
        facingAngle += x;
        unitV2 = new Vector2(Mathf.Cos(facingAngle * Mathf.Deg2Rad), Mathf.Sin(facingAngle * Mathf.Deg2Rad));
    }

    private void FixedUpdate()
    {
        cam.transform.Rotate(0, -x, 0);
        Vector3 camPos = this.transform.position;
        cam.transform.position = Vector3.Lerp(cam.transform.position, camPos, 0.1f);

        this.transform.GetComponent<Rigidbody>().AddForce(cam.transform.forward * z * 3);
    }

    void unlockPickUpCategories()
    {
        for(int i = 0;i < categories.Count; i++)
        {
            if(categories[i].check(size)) {
                categories.RemoveAt(i);
            }
            else {
                break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("sticky"))
        {
            float increase = 0.015f;
            transform.localScale += new Vector3(1, 1, 1) * increase;
            size += increase;
            cam.transform.GetChild(0).Translate(0, 0, -increase * 3f);
            other.enabled = false;
            other.transform.SetParent(this.transform);
            unlockPickUpCategories();
            UIsize.text = "Mass: " + Math.Round(size, 2).ToString();
        }
    }
}
