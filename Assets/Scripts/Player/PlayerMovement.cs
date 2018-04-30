using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float walkSpeed;
	public int currentHP, maxHP;
	public int amountOfMidKits;

	public Transform handPosition;
	public GameObject gunEquipped;

	public Transform spawnPosition;

	private bool isDead = false;

	Rigidbody m_rigidbody;
	Animator m_animator;

	void Awake() {
		m_rigidbody = GetComponent<Rigidbody>();
		m_animator = GetComponent<Animator>();

		maxHP = 100;
		// currentHP = maxHP;

		m_animator.SetFloat("xPos", 0);
		m_animator.SetFloat("yPos", 1);
	}

	void Update() {
		if(currentHP <= 0) { 
			isDead = true;
			currentHP = 0;
		}
		if(currentHP > maxHP) { currentHP = maxHP; }

		if(!isDead) {
			float moveHorizontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");

			Vector3 movement = new Vector3 (moveVertical, 0, -moveHorizontal);
			m_rigidbody.velocity = movement * walkSpeed;

			if(Input.GetKeyDown(KeyCode.W)) {
				m_animator.SetFloat("xPos", 0);
				m_animator.SetFloat("yPos", 1);
			}
			if(Input.GetKeyDown(KeyCode.S)) {
				m_animator.SetFloat("xPos", 0);
				m_animator.SetFloat("yPos", -1);
			}
			if(Input.GetKeyDown(KeyCode.D)) {
				m_animator.SetFloat("xPos", 1);
				m_animator.SetFloat("yPos", 0);
			}
			if(Input.GetKeyDown(KeyCode.A)) {
				m_animator.SetFloat("xPos", -1);
				m_animator.SetFloat("yPos", 0);
			}

			if(gunEquipped != null && Input.GetKeyDown(KeyCode.Q)) {
				gunEquipped.transform.parent = null;
				gunEquipped = null;
			}

			if((Input.GetKeyDown(KeyCode.F)) && (amountOfMidKits >= 1 && currentHP < 100)) {
				currentHP += 20;
				amountOfMidKits -= 1;
				if(currentHP > 100) { currentHP = 100; }
			}

		}

	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Deadzone") {
			isDead = true;
			this.transform.position = spawnPosition.position;
			currentHP -= 10;
		}
	}

	void OnTriggerStay(Collider other) {
		if(Input.GetKeyDown(KeyCode.E)) {
			if(gunEquipped == null) {
				if(other.gameObject.name == "Shotgun") {
					gunEquipped = other.gameObject;
					gunEquipped.transform.parent = handPosition;
					gunEquipped.transform.position = handPosition.position;
					gunEquipped.transform.rotation = handPosition.rotation;
				} else if(other.gameObject.name == "Pistol") {
					gunEquipped = other.gameObject;
					gunEquipped.transform.parent = handPosition;
					gunEquipped.transform.position = handPosition.position;
					gunEquipped.transform.rotation = handPosition.rotation;
				}
			}
			if(other.gameObject.name == "Medkit") {
				if(amountOfMidKits < 3) {
					amountOfMidKits += 1;
					other.gameObject.SetActive(false);
				}
			}
		}
	}

	void OnTriggerExit(Collider other) {
		if(other.gameObject.name == "Deadzone") {
			isDead = false;
		}
	}
}
