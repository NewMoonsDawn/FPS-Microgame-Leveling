using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
   // Update is called once per frame
    public void pauseGame()
    {
        Time.timeScale= 0f;
    }

    public void unPauseGame()
    {
        Time.timeScale= 1f;
    }
}
