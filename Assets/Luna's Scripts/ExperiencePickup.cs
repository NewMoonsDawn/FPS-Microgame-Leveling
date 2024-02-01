using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Gameplay;
using UnityEngine;

public class ExperiencePickup : Pickup
{
    [Header("Parameters")]
    [Tooltip("Amount of Experience provided per pickup")]
    public float experienceAmount;

    protected override void OnPicked(PlayerCharacterController playerController)
    {
        Experience experience = playerController.GetComponent<Experience>();
        if(experience)
        {
            experience.GainExperience(experienceAmount);
            PlayPickupFeedback();
            Destroy(gameObject);
        }
    }

}
