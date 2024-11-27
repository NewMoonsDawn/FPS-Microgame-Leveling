using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;
    public class Experience : MonoBehaviour
    {

        [SerializeField] public List<UpgradeData> upgrades;

        [Tooltip("Amount of Experience to Level up")]
        public float experienceToLevel;
        [Tooltip("Current Player level")]
        public int level;
        [Tooltip("Current Experience")]
        public float currentExperience;
        [Tooltip("Experience needed increase per level")]
        public float experienceIncrease;

        [SerializeField] LevelPanelManager levelPanelManager;

        List<UpgradeData> selectedUpgrades;

        [SerializeField] List<UpgradeData> acquiredUpgrades;

        //PlayerWeaponsManager weaponsManager;

        PlayerWeaponUpgradeManager weaponUpgradeManager;

        PlayerCharacterController playerCharacterController;        

        private void Awake()
        {
         //   weaponsManager = GetComponent<PlayerWeaponsManager>();
            weaponUpgradeManager = GetComponent<PlayerWeaponUpgradeManager>();
            playerCharacterController = GetComponent<PlayerCharacterController>();
        }
        public void GainExperience(float experienceAmount)
        {
            currentExperience += experienceAmount;
            Debug.Log(currentExperience);
            if (currentExperience >= experienceToLevel)
            {
                LevelUp();
            }
        }

        public void LevelUp()
        {
        if (upgrades.Count == 0)
        {
            return;
        }
            if (selectedUpgrades == null)
            {
                selectedUpgrades = new List<UpgradeData>();
            }
            selectedUpgrades.Clear();
            selectedUpgrades.AddRange(GetUpgrades(3));
            Debug.Log("levelup");
            levelPanelManager.OpenPanel(selectedUpgrades);
            currentExperience -= experienceToLevel;
            experienceToLevel += experienceIncrease;
            level++;


        }

        public List<UpgradeData> GetUpgrades(int count)
        {
            List<UpgradeData> upgradeChoices = new List<UpgradeData>();
            List<UpgradeData> tempUpgradeList = new List<UpgradeData>();
            tempUpgradeList.AddRange(upgrades);
            Debug.Log(tempUpgradeList.Count);
            int random;

            if (count > upgrades.Count)
            {
                count = upgrades.Count;
            }

            for (int i = 0; i < count; i++)
            {
                random = Random.Range(0, tempUpgradeList.Count);
                upgradeChoices.Add(tempUpgradeList[random]);
                tempUpgradeList.RemoveAt(random);
            }
            tempUpgradeList.Clear();
            return upgradeChoices;
        }

        internal void Upgrade(int pressedButton)
        {
            UpgradeData upgradeData = selectedUpgrades[pressedButton];

            if (acquiredUpgrades == null)
            {
                acquiredUpgrades = new List<UpgradeData>();
            }

            switch (upgradeData.upgradeType)
            {
                case UpgradeType.WeaponUpgrade:
                    weaponUpgradeManager.UpgradeWeapon(upgradeData);
                    break;
                case UpgradeType.PassiveUpgrade:
                    playerCharacterController.GetPassiveUpgrade(upgradeData);
                    if (upgradeData.item.nextLevel != null)
                    {
                    upgrades.Add(upgradeData.item.nextLevel);
                    }
                    break;
                case UpgradeType.WeaponUnlock:
                    weaponUpgradeManager.AddWeapon(upgradeData.weaponController);
                    break;
                case UpgradeType.JetpackUnlock:
                    var jetpack = GetComponent<Jetpack>();
                    if (jetpack != null)
                    {
                    jetpack.TryUnlock();
                    }
                    break;
            }

            acquiredUpgrades.Add(upgradeData);
            upgrades.Remove(upgradeData);
            if(upgrades.Count==0)
        {
            currentExperience = experienceToLevel;
        }

        }
    }
