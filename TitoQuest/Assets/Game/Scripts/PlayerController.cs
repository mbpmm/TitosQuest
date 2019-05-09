using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject cannon;
    public LayerMask rayCastLayer;
    public float rayDistance;
    public float rotateSpeed;
    public float cannonRotateSpeed;
    public GameObject target;
    private bool click;
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            click = true;
            
        }
        if (click)
        {
            LookTarget();
        }

        if (Physics.Raycast(cannon.transform.position, cannon.transform.forward, out hit, rayDistance, rayCastLayer))
        {
            Debug.DrawRay(cannon.transform.position, cannon.transform.forward * hit.distance, Color.white);

            string layerHitted = LayerMask.LayerToName(hit.transform.gameObject.layer);

            if (layerHitted=="Boxes")
            {
                Debug.DrawRay(cannon.transform.position, cannon.transform.forward * hit.distance, Color.red);
                Debug.Log("Can Hit");
            }
        }
        else
        {
            Debug.DrawRay(cannon.transform.position, cannon.transform.forward * rayDistance, Color.white);
        }
    }

    public void LookTarget()
    {
        Vector3 lookDirCannon = target.transform.position - transform.position;
        Vector3 lookDir = target.transform.position - transform.position;
        lookDir.y = 0;  
        Quaternion q = Quaternion.LookRotation(lookDir);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, rotateSpeed * Time.deltaTime);
        Quaternion q2 = Quaternion.LookRotation(lookDirCannon);
        cannon.transform.rotation = Quaternion.RotateTowards(cannon.transform.rotation, q2, cannonRotateSpeed * Time.deltaTime);
    }
}
