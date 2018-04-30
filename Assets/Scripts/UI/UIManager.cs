using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour {
	public Slider healthBar;
	public Image fillColor;
	public TextMeshProUGUI healthValue;

	public TextMeshProUGUI gunName;
	public TextMeshProUGUI ammoCount;
	public GameObject ammoGrid;

	public TextMeshProUGUI[] itemAmount;	// 0 = medkits

	[SerializeField] Color excellent, good, medium, bad;

	PlayerMovement playerMovement;

	void Awake() {
		playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

		gunName.text = "";
		ammoGrid.SetActive(false);
		ammoCount.enabled = false;
	}

	void Update() {
		healthBar.value = playerMovement.currentHP;
		healthBar.maxValue = playerMovement.maxHP;
		healthValue.text = playerMovement.currentHP + "/" + playerMovement.maxHP;

		if(healthBar.value <= 100 && healthBar.value >= 76) {
			fillColor.color = excellent;
		} else if(healthBar.value <= 75 && healthBar.value >= 51) {
			fillColor.color = good;
		} else if(healthBar.value <= 50 && healthBar.value >= 26) {
			fillColor.color = medium;
		} else if(healthBar.value <= 25) {
			fillColor.color = bad;
		}

		itemAmount[0].text = playerMovement.amountOfMidKits.ToString();

		if(playerMovement.gunEquipped != null) {
			gunName.text = playerMovement.gunEquipped.name;
			gunName.fontSize = 18f;
			ammoGrid.SetActive(true);
			ammoCount.enabled = true;
		} else {
			gunName.text = "";
			ammoGrid.SetActive(false);
			ammoCount.enabled = false;			
		}
	}


}
