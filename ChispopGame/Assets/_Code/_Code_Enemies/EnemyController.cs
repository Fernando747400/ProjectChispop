//Diana Ramos 27/02/22 Changes in the health system

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using com.LazyGames.Chispop;

namespace com.LazyGames.Chispop
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Transform UIHealthBar;
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
                PrepareHealthSystem();
            }
            else
            {
                Debug.Assert(healthSystemIsAlreadyCreated, "The enemy already has life");
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
                    Debug.Log("<color=#ADFF44>Enemy is = </color>" + EnemyState);
                }
                else
                {
                    EnemyState = EnemyStates.Dead;
                    Debug.Log("<color=#ADFF44>Enemy is = </color>" + EnemyState);
                }
            }
        }

        private void PrepareHealthSystem()
        {
            healthSystem = new HealthSystem(healthEnemy);
            healthBar = UIHealthBar.GetComponent<HealthBar>();
            healthBar.SetUp(healthSystem);
            Debug.Log("<color=#ADFF44> Create health to = </color>"+ this.name +healthSystem.GetHealth());
            healthSystemIsAlreadyCreated = true;
        }

        
        

        //Testing Health System
        #region TestHeal
        public void InitializeOrGetHealth()
        {
            if (healthSystem == null)
            {
                Debug.Log("<color=#F97C13>Create Enemy Health</color>");
                healthBar = UIHealthBar.GetComponent<HealthBar>();
                healthSystem = new HealthSystem(healthEnemy);
            }
            healthBar.SetUp(healthSystem);
            Debug.Log(healthSystem.GetHealth());
        }

        public void GetHealthPercent()
        {
            healthSystem.ReceiveDamage(10);
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
            Debug.Log(healthSystem.GetHealth());
            
        }

        public void PlayerReceiveHeal()
        {
            healthSystem.ReceiveHealing(10);
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
