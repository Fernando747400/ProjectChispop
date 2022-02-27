//Diana Ramos 27/02/22 Changes in the health system 

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using com.LazyGames.Chispop;

namespace com.LazyGames.Chispop
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform UIHealthBar;
        [SerializeField] private int healthPlayer;
        
        private HealthBar healthBar;
        private bool healthSystemIsAlreadyCreated = false;
        private HealthSystem healthSystem;
        private PlayerStates _playerStates;

        public PlayerStates PlayerState
        {
            get { return _playerStates; }
            set { _playerStates = value; }
        }

        
        private void Start()
        {
            InitializePlayerConfig();
        }

        private void InitializePlayerConfig()
        {
            if (!healthSystemIsAlreadyCreated)
            {
                PrepareHealthSystem();
            }
            else
            {
                Debug.Assert(healthSystemIsAlreadyCreated, "The player already has life");
            }
            HandlePlayerStates();
        }
        
        //Controls the current state checking the health
        private void HandlePlayerStates()
        {
            if (healthSystemIsAlreadyCreated)
            {
                if (healthSystem.GetHealth() > 0)
                {
                        PlayerState = PlayerStates.Alive;
                        Debug.Log("<color=#E094FF> Player Sate is  = </color>" + PlayerState);
                }
                else if(healthSystem.GetHealth() <= 0)
                {
                        PlayerState = PlayerStates.Dead;
                        Debug.Log("<color=#E094FF> Player Sate is  = </color>"+ PlayerState);
                }
            }
            
            if (PlayerState == PlayerStates.Dead)
            {
                Debug.Log("GAME OVER or TRY AGAIN");
            }
            
        }

        private void PrepareHealthSystem()
        {
            healthSystem = new HealthSystem(healthPlayer);
            healthBar = UIHealthBar.GetComponent<HealthBar>();
            healthBar.SetUp(healthSystem);
            Debug.Log("<color=#E094FF> Create health to = </color>" + this.name + healthSystem.GetHealth());
            healthSystemIsAlreadyCreated = true;
        }
        
        
        #region TestHeal
        public void InitializeOrGetHealth()
        {
            if (healthSystem == null)
            {
                Debug.Log("<color=#E094FF>Create Player Health</color>");
                healthBar = UIHealthBar.GetComponent<HealthBar>();
                healthSystem = new HealthSystem(healthPlayer);
            }
            else
            {
                Debug.Log("<color=#E094FF>Create Player has already health</color>");
                return;
            }
            healthBar.SetUp(healthSystem);
            Debug.Log(healthSystem.GetHealth());
            HandlePlayerStates();
        }

        public void GetHealthPercent()
        {
            healthSystem.ReceiveDamage(10);
            Debug.Log(healthSystem.GetHealthPercent());
            HandlePlayerStates();
        }

        public void PlayerReceiveDamage()
        {
            healthSystem.ReceiveDamage(10);
            Debug.Log(healthSystem.GetHealth());
            HandlePlayerStates();
            
        }

        public void PlayerReceiveHeal()
        {
            healthSystem.ReceiveHealing(10);
            Debug.Log(healthSystem.GetHealth());
            HandlePlayerStates();
        }
        #endregion
    } 

    
        public enum PlayerStates
        {
            Alive = 0,
            Dead = 1,
        }
    }


