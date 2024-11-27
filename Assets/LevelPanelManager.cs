using System;
using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;

public class LevelPanelManager : MonoBehaviour
{
    [SerializeField]
    GameObject panel;
    [SerializeField]
    GameObject crosshair;
    [SerializeField]
    GameObject feedbackHUD;

    [SerializeField] List<UpgradeButton> upgradeButtons;

    PauseGame pauseGame;
    
    [SerializeField] public Experience playerLevel;

    private void Awake()
    {
        pauseGame= GetComponent<PauseGame>();
    }

    private void Start()
    {
        HideButtons();
    }

    private void HideButtons()
    {
        for (int i = 0; i < upgradeButtons.Count; i++)
        {
            upgradeButtons[i].gameObject.SetActive(false);
        }
    }

    public void OpenPanel(List<UpgradeData> upgradeData)
    {
        Clean();
        pauseGame.pauseGame();
        panel.SetActive(true);
        crosshair.SetActive(false);
        feedbackHUD.SetActive(false);

        for(int i=0;i<upgradeData.Count;i++)
        {
            upgradeButtons[i].gameObject.SetActive(true);
            upgradeButtons[i].Set(upgradeData[i]);
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        AudioUtility.SetMasterVolume(0.5f);

        for(int i= 0 ;i<upgradeData.Count;i++)
        {
            upgradeButtons[i].Set(upgradeData[i]);
        }
    }

    public void Clean()
    {
        for (int i=0;i<upgradeButtons.Count;i++)
        {
            upgradeButtons[i].Clean();
        }
    }

    public void Upgrade(int pressedButton)
    {
        playerLevel.Upgrade(pressedButton);
        ClosePanel();
    }

    public void ClosePanel()
    {
        pauseGame.unPauseGame();
        panel.SetActive(false);
        crosshair.SetActive(true);
        feedbackHUD.SetActive(true);

        HideButtons();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        AudioUtility.SetMasterVolume(1f);
    }
}
