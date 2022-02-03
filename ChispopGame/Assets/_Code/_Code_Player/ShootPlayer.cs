//Diana Ramos Creation fo the Scprit
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.LazyGames.Chispop
{
    public class ShootPlayer : MonoBehaviour
    {
        [SerializeField] public bool canShoot = true;
        
        void Start()
        {
        
        }
        
        void Update()
        {
        
        }

        //Method who action shoot of player
        public void ShootWeapon()
        {
            if (!canShoot) return;
            
            Debug.Log("Shoot");
            StartCoroutine(CanShoot());

        }

        IEnumerator CanShoot()
        {
            canShoot = false;
            yield return new WaitForSeconds(1f);
            canShoot = true;
        }
        
        
    }
}

