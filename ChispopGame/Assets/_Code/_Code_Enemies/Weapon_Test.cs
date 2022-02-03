//Aviles con Acento en la Z makes love to this script <3
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.LazyGames.Chispop
{
    public class Weapon_Test : MonoBehaviour
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

        public void Awake()
        {
            inputController = new InputController();
            shootPlayer = gameObject.GetComponent<ShootPlayer>();
            playerActions = inputController.Player;
            playerActions.MousePosition.performed += ctx => mouseDirection = ctx.ReadValue<Vector2>();
            playerActions.Shoot.performed += _ => shootPlayer.ShootWeapon();
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

            weaponMesh = weaponTest.weaponMesh;
            bulletMesh = weaponTest.bulletMesh;
            Bullet = weaponTest.Bullet;
        }
        private void Update()
        { 
            if(IsParent == true)
            {
                //Weapon.transform.rotation = Quaternion.Euler(shootDirection);
                if (cadence > 0)
                {
                    cadence -= Time.deltaTime;
                }
                else
                {
                    SpawnBullet();
                    cadence = weaponTest.cadence;
                }
            }


        }
        void SpawnBullet()
        {
            GameObject Selected = Bullets[Random.Range(0, 5)];
            GameObject newBullet = Instantiate(Selected, SpawnerPosition.transform.position, SpawnerPosition.transform.rotation);
            //Instantiate(Bullet, SpawnerPosition.transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * speed;
            //newBullet.transform.position = shootDirection * speed * Time.deltaTime;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                IsParent = true;
                this.transform.SetParent(GameObject.Find("Player").transform);
                this.transform.position = gunPosition.transform.position;
                this.transform.rotation = GameObject.Find("Player").transform.rotation;
                print("parentado xd");
            }
        }
    }
}