using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName="New Player")]
public class PlayerAttributes : ScriptableObject {
	public int id;
	public float walkSpeed;
	public int points;
	public int currentHP, maxHP;
	public int amountOfMedKits;
	public bool isDead;

	// >>> Character model references here <<<

	// >>> Keybindings here <<<

}
