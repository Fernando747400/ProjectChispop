//Aviles con Acento en la Z makes love to this script
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
        //-----------------------------------------------------

        //New transform when it's picked up
        public GameObject gunPosition;
        private bool IsParent;
        void Start()
        {
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
            Instantiate(Bullet, SpawnerPosition.transform.position, transform.rotation);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                IsParent = true;
                this.transform.SetParent(GameObject.Find("Player").transform);
                this.transform.position = gunPosition.transform.position;
                print("parentado xd");
            }
        }
    }
}