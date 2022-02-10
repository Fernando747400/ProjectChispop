using System.Collections;
using System.Collections.Generic;
using com.LazyGames.Chispop;
using UnityEngine;

namespace com.LazyGames.Chispop
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField]private RectTransform bar;
        
        private HealthSystem healthSystem;
        
        void Start()
        {
        
        }
        
        void Update()
        {
        
        }

        public void SetUp(HealthSystem _healthSystem)
        {
            this.healthSystem = _healthSystem;
            //Receives the event of Damage or Healing
            _healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
        }
        
        private void HealthSystem_OnHealthChanged(object sender, System.EventArgs eventArgs)
        {
            //Reduce the scale of the health bar when the event is triggered 
            bar.localScale = new Vector3(healthSystem.GetHealthPercent(), 1);
        }
    }
}

