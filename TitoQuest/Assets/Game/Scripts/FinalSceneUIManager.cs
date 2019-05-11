using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalSceneUIManager : MonoBehaviour
{
    public Text points;
    public Text boxesDestroyed;
    public Button menu;

    private GameObject gameManager;
    private GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        manager = gameManager.GetComponent<GameManager>();
        menu.onClick.AddListener(GoToMenu);
    }

    // Update is called once per frame
    void Update()
    {
        points.text = "Points: " + manager.points;
        boxesDestroyed.text = "Boxes Destroyed: " + manager.boxesDestroyed;
    }

    void GoToMenu()
    {
        Destroy(gameManager);
        SceneManager.LoadScene("IntroScene");
    }
}

