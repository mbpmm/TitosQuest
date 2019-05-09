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

    private void OnMouseDown()
    {
        player.target = gameObject;
    }
}
