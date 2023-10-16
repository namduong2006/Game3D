using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testmove : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float speedrotate;
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform cam1;
    [SerializeField] Vector3 ofset;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        Vector3 move = new Vector3 (h, 0f, v);
        transform.Translate(move * Time.deltaTime* speed, Space.World);
        if (move != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(move,Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,rotation,speedrotate*Time.deltaTime);
        }


        cam1.position = transform.position + ofset;
    }
}
