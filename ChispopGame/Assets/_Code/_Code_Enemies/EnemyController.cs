//Diana Ramos 09/02/22 Creation of the script

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.LazyGames.Chispop;

namespace com.LazyGames.Chispop
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Transform pfHealthBar;
        [SerializeField] private int healthEnemy;

        private HealthBar healthBar;
        private HealthSystem healthSystem;
        private EnemyStates _enemyStates;
        
        private bool healthSystemIsAlreadyCreated = false;
    
        public EnemyStates EnemyState
        {
            get { return _enemyStates; }
            set { _enemyStates = value; }
        }

        private void Start()
        {
            InitializeEnemyConfig();
        }

        private void InitializeEnemyConfig()
        {
            if (!healthSystemIsAlreadyCreated)
            {
                healthSystem = new HealthSystem(100);
                healthSystemIsAlreadyCreated = true;
            }
            else
            {
                Debug.Assert(healthSystemIsAlreadyCreated, "The player already has life");
            }
            HandleEnemyStates();
        }

        private void HandleEnemyStates()
        {
            if (healthSystemIsAlreadyCreated)
            {
                if (healthSystem.GetHealth() > 0)
                {
                    EnemyState = EnemyStates.Alive;
                    Debug.Log("Enemy is = " + EnemyState);
                }
                else
                {
                    EnemyState = EnemyStates.Dead;
                    Debug.Log("Enemy is = " + EnemyState);
                }
            }
        }

        //Testing Health System

        #region TestHeal
        public void InitializeOrGetHealth()
        {
            if (healthSystem == null)
            {
                Debug.Log("<color=#F97C13>Create Enemy Health</color>");
                healthBar = pfHealthBar.GetComponent<HealthBar>();
                healthSystem = new HealthSystem(healthEnemy);
            }
            healthBar.SetUp(healthSystem);
            Debug.Log(healthSystem.GetHealth());
        }

        public void GetHealthPercent()
        {
            healthSystem.ReceiveDamage(10);
            healthBar.SetUp(healthSystem);
            Debug.Log(healthSystem.GetHealthPercent());
        }

        public void PlayerReceiveDamage()
        {
            if (healthSystem.GetHealth().Equals(0))
            {
                EnemyState = EnemyStates.Dead;
                Debug.Log("<color=#BEFF6C> Player Sate is  = </color>" + EnemyState);
            }
            healthSystem.ReceiveDamage(10);
            healthBar.SetUp(healthSystem);
            Debug.Log(healthSystem.GetHealth());
            
        }

        public void PlayerReceiveHeal()
        {
            healthSystem.ReceiveHealing(10);
            healthBar.SetUp(healthSystem);
            Debug.Log(healthSystem.GetHealth());
        }
        #endregion
    } 


    public enum EnemyStates
    {
        
        Alive = 0,
        Dead = 1,
    }
}
