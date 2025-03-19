using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public SceneLoader sceneLoader;
    public GameObject loadingPanel;

    public Animator gameNameAnimator;
    public Animator mainMenuAnimator;

    public void Start()
    {
        gameNameAnimator.Play("GameNameShow");
        mainMenuAnimator.Play("MainMenuShow");
    }

    public void PlayGame()
    {
        loadingPanel.SetActive(true);
        sceneLoader.LoadGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
