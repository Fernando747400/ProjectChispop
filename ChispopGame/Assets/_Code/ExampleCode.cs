//Fernando Cossio 9/11/2021  Name and date of creation is necessary 
//Diana Ramos 10/11/2021 renamed variables   Name of the last person edited, date and a very breif general explanation of what was changed. 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.LazyGames.Chispop { //All code MUST be contained under namespace for our studio and our proyect 
    public class ExampleCode : MonoBehaviour
    {
        [Header("Player")] //If using Serialized field, they MUST contain a Header even if only 1 variable is being used. 
        [SerializeField] private GameObject playerController; //Public variables are discouraged. SerializedField are encouraged.  
        private GameObject playerHand;  //Naming convention for variables will start with lowercase followed by Uppercase
        
        [HideInInspector] public float damageToReceive; //All public variables must be hidden in the inspector, unless absolutelly necessary, 
        public float speed;

        //Private varibales are always encouraged to be declared and grouped before public variables. Any variables with Serialized and Hidden should go before plain public or private ones.

        public void Awake()
        {
            // Awake, Start, Update, FixedUpdate, LateUpdate and Prepare methods MUST come before any new method, in that specific order. Any unused method can be erased as necessary. 
            //If in need for an erased method, it can be added as long as this order is mantained. 
        }

        public void Start()
        {
            
        }

        public void Update()
        {
            
        }

        public void FixedUpdate()
        {
            
        }

        public void LateUpdate()
        {
            
        }

        private void Prepare()
        {
            //All new methods MUST be private unless necessary.  
        }

        public void DoStuff()
        {
            //For methods, starting uppercase is mandatory. Verbs to name the methods is highly encouraged. Avoid any non-verb naming. 
        }

        //Private methods should be declare before any public methods. This to be in par with variable declaration. 
    }
}
