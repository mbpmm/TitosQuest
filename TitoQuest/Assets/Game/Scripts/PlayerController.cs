using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject cannon;
    public LayerMask rayCastLayer;
    public float rayDistance;
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(cannon.transform.position, cannon.transform.up, out hit, rayDistance, rayCastLayer))
        {
            Debug.DrawRay(cannon.transform.position, cannon.transform.up * hit.distance, Color.white);

            string layerHitted = LayerMask.LayerToName(hit.transform.gameObject.layer);

            switch (layerHitted)
            {
                case "enemy":
                    if (hit.transform.gameObject.name == "Box")
                    {
                        Debug.DrawRay(cannon.transform.position, cannon.transform.up * hit.distance, Color.yellow);
                        Debug.Log("Can Hit");
                    }
                    break;
            }
        }
        else
        {
            Debug.DrawRay(cannon.transform.position, cannon.transform.up * rayDistance, Color.white);
        }
    }
}
