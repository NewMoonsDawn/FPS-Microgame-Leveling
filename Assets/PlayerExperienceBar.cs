using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;
using UnityEngine.UI;

public class PlayerExperienceBar : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("Image component dispplaying current experience")]
    public Image ExperienceFillImage;

    Experience m_PlayerExperience;

    void Start()
    {
        PlayerCharacterController playerCharacterController =
            GameObject.FindObjectOfType<PlayerCharacterController>();
        DebugUtility.HandleErrorIfNullFindObject<PlayerCharacterController, PlayerExperienceBar>(
            playerCharacterController, this);

        m_PlayerExperience = playerCharacterController.GetComponent<Experience>();
        DebugUtility.HandleErrorIfNullGetComponent<Experience, PlayerExperienceBar>(m_PlayerExperience, this,
            playerCharacterController.gameObject);
    }

    void Update()
    {
        // update experience bar value
        ExperienceFillImage.fillAmount = m_PlayerExperience.currentExperience / m_PlayerExperience.experienceToLevel;
    }
}
