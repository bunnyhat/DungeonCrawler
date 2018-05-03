using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName="Weapon")]
public class WeaponType : ScriptableObject {
	public new string name;
	public GameObject weapon;
	public Material[] weaponColors;
	public string burstType;
	public float weaponDamage;
	public Sprite sprite;
	public int magSize;
	public int maxAmmo;
	
}
