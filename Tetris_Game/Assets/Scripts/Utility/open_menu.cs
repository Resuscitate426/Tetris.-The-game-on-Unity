using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_menu : MonoBehaviour{



    public void LoadMain()
    {
        Application.LoadLevel(0);
    }

    public void LoadFirst()
    {
        Application.LoadLevel(1);
        Board.m_game2 = false;
    }

    public void LoadSecond()
    {
        Application.LoadLevel(2);
        Board.m_game2=true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void TogglePause2()
    {
        Controller.m_isPaused = !Controller.m_isPaused;
    }
}
