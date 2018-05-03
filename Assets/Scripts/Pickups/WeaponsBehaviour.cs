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
	public float damage;
	public Sprite bulletSprite;
	public int clipSize;
	public int maxAmmo;

	void Awake() {
		weaponName = weaponType.name;
		weaponType.weapon = this.GetComponent<GameObject>();
		burstMode = weaponType.burstType;
		bulletSprite = weaponType.sprite;

		damage = weaponType.weaponDamage;
		clipSize = weaponType.magSize;
		maxAmmo = weaponType.maxAmmo;
	}

	void Update() {
		switch(weapons) {
			case WEAPONS.PISTOL:

				break;
			case WEAPONS.PUMP_SHOTGUN:

				break;
		}
	}
}
