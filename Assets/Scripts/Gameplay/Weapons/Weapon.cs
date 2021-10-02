using System.Collections;
using Gameplay.Weapons.Projectiles;
using UnityEngine;

namespace Gameplay.Weapons
{
    public class Weapon : MonoBehaviour
    {

        [SerializeField]
        private Projectile _projectile;
        [SerializeField]
        private Projectile[] projectiles;
        int wpnum;
        [SerializeField]
        private Transform _barrel;

        [SerializeField]
        private float _cooldown;


        private bool _readyToFire = true;
        private UnitBattleIdentity _battleIdentity;

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q)&&projectiles.Length > wpnum)
            {
                wpnum++;
            }

            if (Input.GetKeyDown(KeyCode.E) && wpnum > 0)
            {
                wpnum--;
            }
            if(projectiles.Length < wpnum || wpnum < 0)
            {
                wpnum = 0;
            }
        }

        public void setwp2()
        {
            wpnum = 2;
        }
        public void setwp()
        {
            wpnum = 1;
        }
        public void Init(UnitBattleIdentity battleIdentity)
        {
            _battleIdentity = battleIdentity;
        }
        
        
        public void TriggerFire()
        {
            if (!_readyToFire)
                return;
            _projectile = projectiles[wpnum];
            var proj = Instantiate(_projectile, _barrel.position, _barrel.rotation);
            proj.Init(_battleIdentity);
            proj.tag = "Player";
            StartCoroutine(Reload(_cooldown));
        }


        private IEnumerator Reload(float cooldown)
        {
            _readyToFire = false;
            yield return new WaitForSeconds(cooldown);
            _readyToFire = true;
        }

    }
}
