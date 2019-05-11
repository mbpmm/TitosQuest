using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public enum Gun
    {
        AK=1,DE,MP5
    }
    public GameObject gun1;
    public GameObject gun2;
    public GameObject gun3;
    private Gun rnd;
    private float pointsGiven;
    private GameObject turret;
    private PlayerController player;
    private GameObject gameManager;
    private GameManager manager;
    private GameObject boxes;
    private BoxesManager boxesManager;

    // Start is called before the first frame update
    void Start()
    {
        pointsGiven = 100f;
        turret = GameObject.Find("Turret");
        player = turret.GetComponent<PlayerController>();
        gameManager = GameObject.Find("GameManager");
        manager = gameManager.GetComponent<GameManager>();
        boxes = GameObject.Find("BoxesManager");
        boxesManager = boxes.GetComponent<BoxesManager>();
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
        rnd = (Gun)Random.Range(1, 3);
        if (other.gameObject.tag == "Missile")
        {
            GameObject auxGun;
            if (rnd==Gun.AK)
            {
                auxGun = Instantiate(gun1, transform.position, transform.rotation);
            }
            if (rnd == Gun.DE)
            {
                auxGun = Instantiate(gun2, transform.position, transform.rotation);
            }
            if (rnd == Gun.MP5)
            {
                auxGun = Instantiate(gun3, transform.position, transform.rotation);
            }
            manager.points += pointsGiven;
            manager.boxesDestroyed++;
            boxesManager.cantBoxes--;
            Destroy(gameObject);
        }
        else 
        {
            manager.points -= pointsGiven;
            boxesManager.cantBoxes--;
            Destroy(gameObject);
        }
        
    }
}
