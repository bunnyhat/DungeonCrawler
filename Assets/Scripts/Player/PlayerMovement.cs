using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public PlayerAttributes playerAttr;
	public int playerID;
	public float walkSpeed;
	public int score;
	public int currentHP, maxHP;
	public int medKits;

	public Transform handPosition;
	public GameObject gunEquipped;

	public Transform spawnPosition;

	private bool isDead;

	Rigidbody m_rigidbody;
	Animator m_animator;

	WeaponsBehaviour weaponsBehaviour;

	void Awake() {
		m_rigidbody = GetComponent<Rigidbody>();
		m_animator = GetComponent<Animator>();

		playerID = playerAttr.id;
		walkSpeed = playerAttr.walkSpeed;
		score = playerAttr.points;
		currentHP = playerAttr.currentHP;
		maxHP = playerAttr.maxHP;
		medKits = playerAttr.amountOfMedKits;
		isDead = playerAttr.isDead;

		m_animator.SetFloat("xPos", 0);
		m_animator.SetFloat("yPos", 1);
	}

	void Update() {
		if(playerAttr.currentHP <= 0) { 
			playerAttr.isDead = true;
			playerAttr.currentHP = 0;
		}

		if(playerAttr.currentHP > playerAttr.maxHP) { playerAttr.currentHP = playerAttr.maxHP; }

		if(!playerAttr.isDead) {
			float moveHorizontal = Input.GetAxis("Horizontal");
			float moveVertical = Input.GetAxis("Vertical");

			Vector3 movement = new Vector3 (moveVertical, 0, -moveHorizontal);
			m_rigidbody.velocity = movement * playerAttr.walkSpeed;

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

			if(gunEquipped != null) {
				weaponsBehaviour = gunEquipped.GetComponent<WeaponsBehaviour>();
				if(Input.GetKeyDown(KeyCode.Space) && weaponsBehaviour.clipSize > 0) {
					weaponsBehaviour.StartCoroutine("Shoot");
				}
				if(Input.GetKeyDown(KeyCode.Q)) {
					gunEquipped.transform.parent = null;
					gunEquipped = null;
				}
			}

			if((Input.GetKeyDown(KeyCode.F)) && (playerAttr.amountOfMedKits >= 1 && playerAttr.currentHP < 100)) {
				playerAttr.currentHP += 20;
				playerAttr.amountOfMedKits -= 1;
				if(playerAttr.currentHP > 100) { playerAttr.currentHP = 100; }
			}

		}

	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Deadzone") {
			playerAttr.isDead = true;
			this.transform.position = spawnPosition.position;
			playerAttr.currentHP -= 10;
		}
	}

	void OnTriggerStay(Collider other) {
		if(Input.GetKeyDown(KeyCode.E)) {
			if(gunEquipped == null) {
				if(other.gameObject.tag == "Gun") {
					gunEquipped = other.gameObject;
					gunEquipped.transform.parent = handPosition;
					gunEquipped.transform.position = handPosition.position;
					gunEquipped.transform.rotation = handPosition.rotation;
				}
			}
			if(other.gameObject.name == "Medkit") {
				if(playerAttr.amountOfMedKits < 3) {
					playerAttr.amountOfMedKits += 1;
					other.gameObject.SetActive(false);
				}
			}
		}
	}

	void OnTriggerExit(Collider other) {
		if(other.gameObject.name == "Deadzone") {
			playerAttr.isDead = false;
		}
	}
}
