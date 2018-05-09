using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName="Weapon")]
public class WeaponType : ScriptableObject {
	public new string name;
	public Material[] weaponColors;
	public string burstType;
	public float reloadTimer;
	public float weaponDamage;
	public int magSize;
	public int maxAmmo;
	
}
