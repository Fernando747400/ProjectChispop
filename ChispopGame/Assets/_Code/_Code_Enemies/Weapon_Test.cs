using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.LazyGames.Chispop
{
    public class Weapon_Test : MonoBehaviour
    {
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
        void SpawnBullet()
        {
            Instantiate(Bullet, SpawnerPosition.transform.position, transform.rotation);
        }
    }
}