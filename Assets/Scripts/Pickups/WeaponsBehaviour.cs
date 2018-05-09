using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum WEAPONS {
	PISTOL,
	PUMP_SHOTGUN
}

public class WeaponsBehaviour : MonoBehaviour {
	[SerializeField] public WEAPONS weapons;

	public WeaponType weaponType;

	public string weaponName;
	public string burstMode;
	public float reloadTime;
	public float damage;
	public int clipSize;
	public int maxAmmo;

	void Awake() {
		weaponName = weaponType.name;
		
		burstMode = weaponType.burstType;
		reloadTime = weaponType.reloadTimer;

		damage = weaponType.weaponDamage;
		clipSize = weaponType.magSize;
		maxAmmo = weaponType.maxAmmo;
	}

	public IEnumerator Shoot() {
		switch(weapons) {
			case WEAPONS.PISTOL:
				clipSize -= 1;
				yield return new WaitForSeconds(reloadTime);
				if(clipSize == 0) {
					if(maxAmmo >= 9) {
						maxAmmo -= 9;
						clipSize = 9;
					}
					if(maxAmmo < 9) {
						clipSize = maxAmmo;
						maxAmmo = 0;
					}
				}
				break;
			
			case WEAPONS.PUMP_SHOTGUN:
				clipSize -= 2;
				yield return new WaitForSeconds(reloadTime);
				if(clipSize == 0) {
					if(maxAmmo >= 2) {
						maxAmmo -= 2;
						clipSize = 2;
					}
					if(maxAmmo < 2) {
						clipSize = maxAmmo;
						maxAmmo = 0;
					}
				}
				break;
		}
	}
}
