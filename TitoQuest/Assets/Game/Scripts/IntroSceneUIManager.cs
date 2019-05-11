using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroSceneUIManager : MonoBehaviour
{
    public Button play;
    // Start is called before the first frame update
    void Start()
    {
        play.onClick.AddListener(GoToGameScene);
    }

    void GoToGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
