//Diana Ramos 04/02/22  Creation of the script

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.LazyGames.Chispop
{
    public class HealthSystem : MonoBehaviour
    {
        // This script control the health of all Enemies and the Player
       
        public EventHandler OnHealthChanged;
    
        private int _health;
        private int _healthMax;

        //Initialize health system in classes
        public HealthSystem(int healthMax)
        {
            _healthMax = healthMax;
            _health = _healthMax;
        }
        
        public int GetHealth()
        {
            return _health;
        }

        public void ReceiveDamage(int damageAmount)
        {
            _health -= damageAmount;

            if (_health < 0)
            {
                _health = 0;
            }
            //If it is suscribed to the event change the health bar 
            if (OnHealthChanged != null)
            {
                OnHealthChanged(this,EventArgs.Empty);
            }
        }

        public void ReceiveHealing(int healAmount)
        {
            _health += healAmount;
            if (_health > _healthMax)
            {
                _health = _healthMax;
            }
            if (OnHealthChanged != null)
            {
                OnHealthChanged(this,EventArgs.Empty);
            }
        }

        public float GetHealthPercent()
        {
            return (float)_health / _healthMax;
        }
    }
    
}

