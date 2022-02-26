//Aviles con Acento en la Z makes love to this script <3
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.LazyGames.Chispop
{
    public class Weapon_Controller : MonoBehaviour
    {
        //Start all the variables from the scriptable objects
        //-----------------------------------------------------
        public Scriptable_Enemy_Guns weaponTest;

        public string weaponName;

        public float damage;
        public float speed;
        public float capacity;
        public float cadence;
        public float range;
        public float reloadTime;

        public Mesh weaponMesh;
        public Mesh bulletMesh;
        public GameObject Bullet;
        public GameObject SpawnerPosition;
        public GameObject Weapon;
        //-----------------------------------------------------

        private ShootPlayer shootPlayer;
        private InputController inputController;
        private InputController.PlayerActions playerActions;
        private Vector2 mouseDirection;
        private Vector3 shootDirection;

        public GameObject[] Bullets = new GameObject[5];

        //New transform when it's picked up
        public GameObject gunPosition;
        private bool IsParent;

        private float currentAmmo;
        private bool isReloading = false;

        public void Awake()
        {
            
        }

        void Start()
        {
            shootDirection = Camera.main.ScreenToWorldPoint(mouseDirection);
            shootDirection = shootDirection.normalized;

            weaponName = weaponTest.codeName;
            damage = weaponTest.damage;
            speed = weaponTest.speed;
            capacity = weaponTest.capacity;
            cadence = weaponTest.cadence;
            range = weaponTest.range;
            reloadTime = weaponTest.reloadTime;

            weaponMesh = weaponTest.weaponMesh;
            bulletMesh = weaponTest.bulletMesh;
            Bullet = weaponTest.Bullet;

            currentAmmo = capacity;
            
        }
        private void Update()
        {
           if(isReloading == false)
            {
                StopCoroutine(ReloadGun());
            }
        }
        public void AbleToShoot()
        {
            if (IsParent == true && isReloading == false)
            { 
                ShootGun();
            }
        }
        public void ShootGun()
        {
            currentAmmo--;
            GameObject Selected = Bullets[Random.Range(0, 5)];
            GameObject newBullet = Instantiate(Selected, SpawnerPosition.transform.position, SpawnerPosition.transform.rotation);
            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * speed;
            if(currentAmmo <= 0)
            {
                StartCoroutine(ReloadGun());
                return;
            }
        }
        IEnumerator ReloadGun()
        {
            isReloading = true;
            print("reloading");
            yield return new WaitForSeconds(reloadTime);
            currentAmmo = capacity;
            isReloading = false;
            print("end reload");
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                IsParent = true;
                this.transform.SetParent(GameObject.Find("Player").transform);
                this.transform.position = gunPosition.transform.position;
                this.transform.rotation = GameObject.Find("Player").transform.rotation;
                ShootPlayer shootPlayer = null;
                shootPlayer = other.gameObject.GetComponent<ShootPlayer>();
                if(shootPlayer.CurrentWeapon != null)
                {
                    shootPlayer.CurrentWeapon = null;
                    shootPlayer.CurrentWeapon = this.gameObject.GetComponent<Weapon_Controller>();
                }
                else
                {
                    shootPlayer.CurrentWeapon = this.gameObject.GetComponent<Weapon_Controller>();
                    print(shootPlayer.CurrentWeapon);
                }
            }
        }
    }
}