using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour
{
    public Text points;
    public Text boxesLeft;

    private GameObject gameManager;
    private GameManager manager;
    private GameObject boxes;
    private BoxesManager boxesManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        manager = gameManager.GetComponent<GameManager>();
        boxes = GameObject.Find("BoxesManager");
        boxesManager = boxes.GetComponent<BoxesManager>();
    }

    // Update is called once per frame
    void Update()
    {
        points.text = "Points: " + manager.points;
        boxesLeft.text = "Boxes Left: " + boxesManager.cantBoxes;
    }
}
