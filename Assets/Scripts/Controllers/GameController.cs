using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    public enum GameState { Menu, GamePlay, GameOver, Transition}
    [SerializeField] GameState gameState;

    public void StartState(GameState state)
    {
        gameState = state;

        switch(state)
        {
            case GameState.Menu:
                EventManager.Invoke(EventConst.OnMenuStart);
                break;
            case GameState.GamePlay:
                GameData gameData = GenerateGameData();
                EventManager.Invoke<GameData>(EventConst.OnGameOverStart, gameData);
                break;
            case GameState.GameOver:
                EventManager.Invoke(EventConst.OnGameOverStart);
                break;
        }
    }

    public void EndState()
    {
        switch (gameState)
        {
            case GameState.Menu:
                EventManager.Invoke(EventConst.OnMenuEnd);
                break;
            case GameState.GamePlay:
                EventManager.Invoke(EventConst.OnGameOverEnd);
                break;
            case GameState.GameOver:
                EventManager.Invoke(EventConst.OnGameOverEnd);
                break;
        }
        gameState = GameState.Transition;
    }

    public void TransitionState(GameState state, float time)
    {
        StartCoroutine(DelayTransition(state, time));
    }

    IEnumerator DelayTransition(GameState newState, float time)
    {
        EndState();
        yield return new WaitForSeconds(time);
        StartState(newState);
    }

    GameData GenerateGameData()
    {
        //Va grab les player n shit
        return new GameData();
    }
}
