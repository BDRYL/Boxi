using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour {

	public Animator animator;

	float defaultRandomNumberTime= 0f;
	float RandomNumberTime;
	float defaultAttackTime= 0f;
	float AttackTime;
	public HealthBar healthbar_d;
	public int defaultHealth = 150;
	int health;
	public int attackdamage = 27; 
	public float attackRange = 10f;
	public LayerMask characterLayers;
	public Transform attackPosition;
	public AudioClip[] Voice;

	void Start () {
		RandomNumberTime = defaultRandomNumberTime;
		AttackTime = defaultAttackTime;
		health = defaultHealth;
		healthbar_d.SetMaxHealth (defaultHealth);
	}
	
	// Update is called once per frame
	void Update () {

		if (AttackTime <= 0){
			AttackTime = Random.Range (1,6);
			Debug.Log (AttackTime);
		}if (AttackTime >= 0) {
			AttackTime -= Time.deltaTime;
		}
		if (AttackTime<=0){
			Attack();
		}
		if (RandomNumberTime <= 0){
			RandomNumberTime = Random.Range (15, 25);
			Debug.Log (RandomNumberTime);

		}if(RandomNumberTime>=0){
			RandomNumberTime -= Time.deltaTime;
			anim ();

		}
	}
	void anim(){
		if (RandomNumberTime <= 1)
			animator.SetTrigger ("Dance");
	
	}
	void Attack(){
		if (AttackTime <= 5){
			AttackLc ();
			if (AttackTime <= 1){
				animator.SetTrigger ("Attack");
			}
		}
		if (AttackTime >= 6 ){
			Attackc ();
			if(AttackTime <=4){
				animator.SetTrigger ("Attack2");


			}

		}
	
	}
	public void TakeDamage (int damage){
		GetComponent<AudioSource> ().PlayOneShot (Voice [0]);
		health -= damage;
		animator.SetTrigger ("hurtr");
		healthbar_d.SetHealth (health);
		if (health <= 0) {
			Die ();
		}
	
	}
	public void TakeDamageL (int damage){
		GetComponent<AudioSource> ().PlayOneShot (Voice [0]);
		health -= damage;
		animator.SetTrigger ("hurtl");
		healthbar_d.SetHealth (health);
		if (health <= 0) {
			Die ();
		}

	}

	void Die (){
		animator.SetBool ("Died",true);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	void Attackc(){
		GetComponent<AudioSource> ().PlayOneShot (Voice [1]);
		Collider2D[] hitCharacter = Physics2D.OverlapCircleAll(attackPosition.position,attackRange,characterLayers);

		foreach(Collider2D Character in hitCharacter){
			Character.GetComponent<Character>().TakeDamageLc(attackdamage);
			Debug.Log("yes");}
	}
	void AttackLc(){
		GetComponent<AudioSource> ().PlayOneShot (Voice [1]);
		Collider2D[] hitCharacter = Physics2D.OverlapCircleAll(attackPosition.position,attackRange,characterLayers);

		foreach(Collider2D Character in hitCharacter){
			Character.GetComponent<Character>().TakeDamagec(attackdamage);
			Debug.Log("yes");}
	}

	void OnDrawGizmosSelected(){

		if (attackPosition == null)
			return;
		Gizmos.DrawWireSphere (attackPosition.position, attackRange);


	}

}
