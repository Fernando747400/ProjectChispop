//Diana Ramos 04/02/22 Creation of Scripts

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
        [SerializeField] private HealthBar healthBar;
        [SerializeField] private int healthPlayer;

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
                healthSystem = new HealthSystem(100);
                healthSystemIsAlreadyCreated = true;
            }
            else
            {
                Debug.Assert(healthSystemIsAlreadyCreated, "The player already has life");
            }
            HandlePlayerStates();
        }
        
        private void HandlePlayerStates()
        {
            if (healthSystemIsAlreadyCreated)
            {
                if (healthSystem.GetHealth() > 0)
                {
                    PlayerState = PlayerStates.Alive;
                    Debug.Log("Player is = " + PlayerState);
                }
                else
                {
                    PlayerState = PlayerStates.Dead;
                    Debug.Log("Player is = " + PlayerState);
                }
            }
        }
       
        
        public enum PlayerStates
        {
            Alive = 0,
            Dead = 1,
        }
    }
}

