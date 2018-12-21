using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform weaponHold;
    Gun equippedGun;
    public Gun startingGun;

    private void Start() {
        if(startingGun!=null) {
            EquipWeapon(startingGun);
        }
    }


    public void EquipWeapon(Gun guntoEquip) {
        if(equippedGun!=null) {
            Destroy(equippedGun.gameObject);
        }
        equippedGun = Instantiate(guntoEquip, weaponHold.position, weaponHold.rotation) as Gun;
        equippedGun.transform.parent = weaponHold;
    }

    public void Shoot() {
        if(equippedGun!=null) {
            equippedGun.Shoot();
        }
    }
}
