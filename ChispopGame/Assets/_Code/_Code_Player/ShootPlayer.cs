//Diana Ramos Creation fo the Scprit
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.LazyGames.Chispop
{
    public class ShootPlayer : MonoBehaviour
    {
        [SerializeField] public bool canShoot = true;
        [SerializeField] private Weapon_Controller currentWeapon;

        public Weapon_Controller CurrentWeapon
        {
            get { return currentWeapon; }
            set { currentWeapon = value; }
        }

        void Start()
        {
            
        }
        
        void Update()
        {
            
        }
        public void ShootWeapon()
        {
           if(currentWeapon == null)
            {
                return;
            }
            else
            {
                if (!canShoot) return;

                Debug.Log("Shoot");
                currentWeapon.AbleToShoot();
                StartCoroutine(CanShoot());
            }
        }
        IEnumerator CanShoot()
        {
            canShoot = false;
           
            yield return new WaitForSeconds(currentWeapon.cadence);
            canShoot = true;
        }
    }
}

