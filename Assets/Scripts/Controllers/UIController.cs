using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private CanvasFader mainMenuFader;
    [SerializeField] private CanvasFader endGameFader;
    [SerializeField] private CanvasFader inGameFader;
 
    private void Awake()
    {
        EventManager.Subscribe("OnMenuStart", Init);
        EventManager.Subscribe("OnGamePlayStart", ShowInGame);
        EventManager.Subscribe("OnGamePlayEnd", ShowEndGame);
        EventManager.Subscribe("OnGameOverEnd", ResetMenu);
    }

    private void Init()
    {
        mainMenuFader.FadeIn();
    }

    private void ShowInGame()
    {
        inGameFader.FadeIn();
    }

    private void ShowEndGame()
    {
        endGameFader.FadeIn();
    }

    private void ResetMenu()
    {
        endGameFader.Hide();
        mainMenuFader.FadeIn();
    }
}
