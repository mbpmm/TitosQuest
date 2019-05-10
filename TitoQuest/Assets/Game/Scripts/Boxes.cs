using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes : MonoBehaviour
{
    private GameObject turret;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        turret = GameObject.Find("Turret");
        player = turret.GetComponent<PlayerController>();
    }
    private void Update()
    {
        transform.position += Vector3.down*Time.deltaTime*2;
    }
    private void OnMouseDown()
    {
        player.target = gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Missile(Clone)")
        {
            Destroy(gameObject);
        }
    }
}
