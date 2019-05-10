﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float missileSpeed;
    public float missileRotSpeed;
    private GameObject turret;
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        turret = GameObject.Find("Turret");
        player = turret.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.target)
        {
            transform.position += transform.forward * Time.deltaTime * missileSpeed;
        }
        else
        {
            Vector3 lookDir = player.target.transform.position - transform.position;
            Quaternion q = Quaternion.LookRotation(lookDir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, missileRotSpeed * Time.deltaTime);

            transform.position += transform.forward * Time.deltaTime * missileSpeed;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Box")
        {
            Destroy(gameObject);
        }
    }
}
