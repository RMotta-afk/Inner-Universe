using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Assets._03_Scripts.Player
{
    public class PlayerLevel :MonoBehaviour
    {
        public TextMeshProUGUI playerCurrentLevel;

        public int currentLevel = 1;
        public int currentXP = 0;
        public int xpToNextLevel = 100;
        public int maxLevel = 10;

        public int healthPerLevel = 100;
        public int damagePerLevel = 50;

        public static event Action<int> OnPlayerHeal;

        public void Start()
        {
            playerCurrentLevel.text = currentLevel.ToString();
        }
        public void AddXP(int xp)
        {
            currentXP += xp;

            // Verify player's level up
            while (currentXP >= xpToNextLevel && currentLevel < maxLevel)
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            currentLevel++;
            currentXP -= xpToNextLevel; // Remove the wasted XP
            xpToNextLevel = (int)(xpToNextLevel * 1.5f); // Makes leveling a little bit harder by adding more XP need(ex: 100 > 150 > 225...)

            // Improve player's attributes
            OnPlayerHeal?.Invoke(healthPerLevel);
            //attackDamage += damagePerLevel;

            playerCurrentLevel.text = currentLevel.ToString();

            Debug.Log("LEVEL UP! Nível " + currentLevel);

        }
    }
}
