//Aviles con Acento en la Z makes love to this script
using UnityEngine;

namespace com.LazyGames.Chispop
{
    [CreateAssetMenu(menuName = "EnemyGuns")]
    public class Scriptable_Enemy_Guns : ScriptableObject
    {
        //I think it could be useful have a set or codename for every combination or for each enemy but i wonder how could we implement that xd
        public string codeName;
        //These ones represents all the stats that the gun use in every time
        public float damage, speed, capacity, cadence, range, reloadTime;

        //These variables are for all the visuals and effects of the gun
        //I don't know how the effects and particles will be implemented, so I put out "shootEffect", "particles", etc.
        //public Sprite weaponSprite, bulletSprite;
        public Mesh weaponMesh, bulletMesh;
        public GameObject Bullet;

        //These last ones are for special enemies or special scenarios that could be fun to experiment with
        /*public float bouncing;
        public float ratioExplotion;
        public bool poison, bleeding, paralysis, healing;
        public float chargeShoot;
        public float tracking;*/
    }
}
