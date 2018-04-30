using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour {

	public GameObject itemType;

	// Animator m_animator;

	void Start() {
		// m_animator = GetComponent<Animator>();

		// if(this.gameObject.name == "Cube") {
		// 	m_animator.Play("ItemRotate");
		// }
	}

	void OnCollisionStay(Collision other) {
		if(this.gameObject.tag == "Player") {
			Debug.Log("hit player");
			
		}
	}
	
}
