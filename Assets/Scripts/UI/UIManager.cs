using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour {

	[Header("Player Info")]
	public TextMeshProUGUI[] playerText;
	public TextMeshProUGUI[] scoreText;
	public Slider[] healthBar;
	public Image[] fillColor;
	public TextMeshProUGUI[] healthValue;

	public TextMeshProUGUI[] gunName;
	public TextMeshProUGUI[] ammoCount;

	public TextMeshProUGUI[] medKitAmount;

	[Header("Health Bar Indicator Colors")]
	public Color excellent;
	public Color good;
	public Color medium;
	public Color bad;

	PlayerMovement playerMovement;
	WeaponsBehaviour weaponsBehaviour;

	void Awake() {
		playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

		for(int i = 0; i < playerText.Length; i++) {
			
		}
		for(int i = 0; i < scoreText.Length; i++) {
			scoreText[i].text = "00000";
			scoreText[i].color = Color.red;
		}

		for(int i = 0; i < gunName.Length; i++) {
			gunName[i].text = "";
		}
		for(int i = 0; i < ammoCount.Length; i++) {
			ammoCount[i].enabled = false;
		}
	}

	void Update() {
		for(int i = 0; i < healthBar.Length; i++) {
			for(int j = 0; j < fillColor.Length; j++) {
				healthBar[i].value = playerMovement.currentHP;
				healthBar[i].maxValue = playerMovement.maxHP;

				if(healthBar[i].value <= 100 && healthBar[i].value >= 76) {
					fillColor[j].color = excellent;
				} else if(healthBar[i].value <= 75 && healthBar[i].value >= 51) {
					fillColor[j].color = good;
				} else if(healthBar[i].value <= 50 && healthBar[i].value >= 26) {
					fillColor[j].color = medium;
				} else if(healthBar[i].value <= 25) {
					fillColor[j].color = bad;
				}
			}
		}

		for(int i = 0; i < healthValue.Length; i++) {
			healthValue[i].text = playerMovement.currentHP.ToString();
		}

		for(int i = 0; i < medKitAmount.Length; i++) {
			medKitAmount[i].text = playerMovement.playerAttr.amountOfMedKits.ToString();
		}

		for(int i = 0; i < gunName.Length; i++) {
			for(int j = 0; j < ammoCount.Length; i++) {
				if(playerMovement.gunEquipped != null) {
					weaponsBehaviour = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().gunEquipped.GetComponent<WeaponsBehaviour>();
					
					gunName[i].text = weaponsBehaviour.weaponName;
					gunName[i].fontSize = 18f;
					
					ammoCount[j].enabled = true;
					ammoCount[j].text = weaponsBehaviour.clipSize + " / " + weaponsBehaviour.maxAmmo;
				} else {
					gunName[i].text = "";
					ammoCount[j].enabled = false;	
				}
			}
		}

	}
}