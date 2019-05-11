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
    public GameObject missileEmitter;
    public GameObject missile;

    private bool click;
    private bool isShooting;
    private float fireRate;
    private GameObject gameManager;
    private GameManager manager;

    private void Start()
    {
        fireRate = 3f;
        gameManager = GameObject.Find("GameManager");
        manager = gameManager.GetComponent<GameManager>();
    }
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            click = true;
            isShooting = true;
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
                fireRate += Time.deltaTime;
                if (fireRate>=3f)
                {
                    ShootMissile();
                    Debug.DrawRay(cannon.transform.position, cannon.transform.forward * hit.distance, Color.red);
                    fireRate = 0f;
                }
                
            }
        }
        else
        {
            Debug.DrawRay(cannon.transform.position, cannon.transform.forward * rayDistance, Color.white);
        }
    }

    public void LookTarget()
    {
        if (!target)
        {
            Vector3 lookIdle = Vector3.zero;
            Quaternion q3 = Quaternion.LookRotation(lookIdle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q3, rotateSpeed * Time.deltaTime);
        }
        else
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

    public void ShootMissile()
    {
        if (isShooting)
        {
            GameObject auxBullet;
            auxBullet = Instantiate(missile, missileEmitter.transform.position, missileEmitter.transform.rotation);
            isShooting = false;
        }
        
    }
}
