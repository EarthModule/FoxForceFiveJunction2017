using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}



/// Launch projectile

public class WeaponScript : MonoBehaviour {

	// 1 - Designer variables



	/// Projectile prefab for shooting

	public Rigidbody2D shotPrefab;

	/// <summary>
	/// Cooldown in seconds between two shots
	/// </summary>
	public float shootingRate = 0.25f;


	// 2 - Cooldown

	private float shootCooldown;

	void Start() {
	 	shootCooldown = 0f;
	}

	void Update() {
	 	if (shootCooldown > 0) {
	     	shootCooldown -= Time.deltaTime;
	 	}
	}

	public void Attack(bool isEnemy) {
	 	if (CanAttack) {
			shootCooldown = shootingRate;

			// Create a new shot
			//var shotTransform = Instantiate(shotPrefab) as Transform;

			// Assign position
			//shotTransform.position = transform.position;
	 		Rigidbody2D clone;
			clone = (Instantiate(shotPrefab, transform.position+1.0f*transform.forward,transform.rotation) as Rigidbody2D);
			//var rigidbody2D = Rigidbody2D;
			clone.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2 (1000, 0));
			//shotPrefab.Rigidbody2D.AddForce(transform.forward * 1000);

			// The is enemy property
			/*ShotScript shot = clone.gameObject.GetComponent<ShotScript>();
			if (shot != null) {
			 	shot.isEnemyShot = isEnemy;
			}*/
	     
			// Make the weapon shot always towards it
			/*MoveScript move = shotPrefab.gameObject.GetComponent<MoveScript>();
			if (move != null) {
                Debug.Log("something");
			    //move.direction = this.transform.right; // towards in 2D space is the right of the sprite
			}*/
	 	}
	}

	public bool CanAttack {
	 	get {
	     	return shootCooldown <= 0f;
	 	}
	}
}
