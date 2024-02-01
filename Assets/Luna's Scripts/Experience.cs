using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{
    [Tooltip("Amount of Experience to Level up")]
    public float experienceToLevel;
    [Tooltip("Current Player level")]
    public int level;
    [Tooltip("Current Experience")]
    public float currentExperience;
    [Tooltip("Experience needed increase per level")]
    public float experienceIncrease;
    public void GainExperience(float experienceAmount)
    {
        currentExperience += experienceAmount;
        Debug.Log(currentExperience);
        if(currentExperience >= experienceToLevel)
        {
            LevelUp();
        }
    }
    
    public void LevelUp()
    {
        Debug.Log("levelup");
        currentExperience -= experienceToLevel;
        experienceToLevel += experienceIncrease;
        level++;


        //TODO LEVELUP MENU
    }
}
