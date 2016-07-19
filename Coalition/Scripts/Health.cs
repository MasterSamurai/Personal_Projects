using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using System.Collections;

public class Health : MonoBehaviour {

	//Health variables
	public float health = 110f; //Variable containing the actual health value of the player or object script is on
	private float dmg; //Damage player or object should take
	private float duration; //Duration that player or object should take damage
	private float rate; //How quickly player or object should take damage during duration

	//Action and player variables
	public bool isRegenerating = false; //Boolean showing if player or object is regenerating
	private bool isPlayer = false; //Variable carrying the value of whether or not the script is attached to a player or not 
	private bool isAI = false; //Variable carrying the value of whether or not the script is attached to an AI or not
	private bool isObject = false; //Variable carrying the value of whether or not the script is attached to an object or not

	//Components (Scripts and Objects)
	public Grayscale gr; //Grayscale script 
	public MotionBlur mb; //Motion Blur script
	public GameMaster gm; //GameMaster script
	public Transform playerRagdoll; //Ragdoll component

	//Audio Components
	public AudioSource audioSource2; //Audio source number 2, containing the heartbeat clip
	public AudioClip heartbeatClip; //The heartbeat AudioClip
	private float volume; //The volume the heartbeat clip should play at

	void Start () {
		audioSource2 = GameObject.FindGameObjectWithTag ("Audio2").GetComponent<AudioSource> ();
		gm = GameObject.FindGameObjectWithTag("Scripts").GetComponent<GameMaster>();
		if (this.GetComponent<PlayerMovement>() != null) {
			isPlayer = true;
		}
		if (this.GetComponent<AIMovement> () != null) {
			isAI = true;
		}
		if(this.GetComponent<AIMovement> () == null && this.GetComponent<PlayerMovement>() == null){
			isObject = true;
		}
	}

	void Update () {
		if(health == 0f){
			die();
		}
		if (isPlayer == true) {
			volume = (-0.1f * health) + 2f;
			if (health <= 100 && isRegenerating == false) {
				StartCoroutine ("regenerate");
			}
			if (health <= 20f) {
				gr.enabled = true;
				mb.enabled = true;
				mb.blurAmount = (-0.05f * health) + 1f; 
				audioSource2.volume = volume;
				if (!audioSource2.isPlaying) {
					StartCoroutine ("playHeartBeat");
				}
			} else {
				audioSource2.Stop ();
				gr.enabled = false;
				mb.enabled = false;
			}
		}
	}

	public void takeDamage(float dmg){
		if (health - dmg < 0f) {
			health = 0f;
		} else {
			health -= dmg;
		}
	}

	public void bleedDamage(float damage, float durationTime, float rateTime){
		dmg = damage;
		InvokeRepeating ("bleed", durationTime, rateTime);
	}

	public IEnumerator bleed(){
		if (health - dmg < 0f) {
			health = 0f;
		} else {
			health -= dmg;
		}
		yield break;
	}

	public void die(){
		if(isObject == false){
			GameObject ragdoll = Instantiate (playerRagdoll, this.gameObject.transform.position, Quaternion.identity) as GameObject;
			Destroy(this.gameObject);
			Destroy (ragdoll);
			if(isPlayer == true){
				gm.spawnCharacter();
			}
		}
	}

	public IEnumerator playHeartBeat(){
		audioSource2.PlayOneShot (heartbeatClip, volume);
		yield return new WaitForSeconds (30f);
	}

	public IEnumerator regenerate(){
		if(health + 1 < 101){
			isRegenerating = true;
			health++;
			yield return new WaitForSeconds (1f);
			isRegenerating = false;
		}
	}
}
