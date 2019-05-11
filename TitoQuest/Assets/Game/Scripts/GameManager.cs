using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public float points;
    public float boxesDestroyed;

    private bool gameOver;
    private GameObject boxes;
    private BoxesManager boxesManager;

    public override void Awake()
    {
        base.Awake();
        boxes = GameObject.Find("BoxesManager");
        boxesManager = boxes.GetComponent<BoxesManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (boxesManager.cantBoxes<=0)
        {
            gameOver = true;
            boxesManager.cantBoxes++;
        }
        if (gameOver)
        {
            gameOver = false;
            GoToFinalScene();
        }
    }

    void GoToFinalScene()
    {
        SceneManager.LoadScene("FinalScene");
    }



}
