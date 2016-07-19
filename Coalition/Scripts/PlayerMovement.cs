using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public GameObject player;
	public Camera playerCamera;
	public Transform head;
	public float gravity;
	public float jumpHeight;
	public float speed;
	public float move;
	public bool isSwimming = false;
	public bool isSprinting = false;
	private float lftLTT = 0f;
	private float fwdLTT = 0f;
	private float rgtLTT = 0f;
	private float bkwdLTT = 0f;
	public float x = 0f;
	//bool respawn = true;
	float normRot;
	//Rigidbody rb;
	//GameMaster gm;
	PlayerUI pUI;
	Stamina st;
	Animator anim;

	// Use this for initialization
	void Start () {
		//rb = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
		//gm = GameObject.FindGameObjectWithTag ("Scripts").GetComponent<GameMaster> ();
		st = this.GetComponent<Stamina> ();
		pUI = this.GetComponent<PlayerUI> ();
		anim.SetInteger ("Direction", 0);
		anim.SetInteger ("MovementSpeed", 0);
		anim.SetBool ("isSwimming", false);
	}
	// Update is called once per frame
	void Update () {
		
		if (pUI.menuOpen == false) {
			if(isSwimming == true && Input.GetKey(KeyCode.W)){
				this.transform.Translate(player.transform.rotation * new Vector3(0f,0f,0.05f));
			}
			if (Input.anyKey == false) {
				StartCoroutine ("characterStop");
				isSprinting = false;
			}
			if (st.stamina <= 10 && anim.GetInteger ("Direction") == 1 && anim.GetInteger ("MovementSpeed") == 2) {
				anim.SetInteger ("Direction", 1);
				anim.SetInteger ("MovementSpeed", 1);
				isSprinting = false;
			}
			if (st.stamina <= 10 && anim.GetInteger ("Direction") == 2 && anim.GetInteger ("MovementSpeed") == 2) {
				anim.SetInteger ("Direction", 2);
				anim.SetInteger ("MovementSpeed", 1);
				isSprinting = false;
			}
			if (st.stamina <= 10 && anim.GetInteger ("Direction") == 3 && anim.GetInteger ("MovementSpeed") == 2) {
				anim.SetInteger ("Direction", 3);
				anim.SetInteger ("MovementSpeed", 1);
				isSprinting = false;
			}
			if (st.stamina <= 10 && anim.GetInteger ("Direction") == 4 && anim.GetInteger ("MovementSpeed") == 2) {
				anim.SetInteger ("Direction", 4);
				anim.SetInteger ("MovementSpeed", 1);
				isSprinting = false;
			}
			if (Input.GetKeyDown (KeyCode.W)) {
				if (isSwimming == false) {
					if (Time.time - fwdLTT < 0.5f && st.stamina > 10f) {
						StartCoroutine ("characterRunFWD");
						fwdLTT = Time.time;
						isSprinting = true;
					} else {
						StartCoroutine ("characterWalkFWD");
						fwdLTT = Time.time;
						isSprinting = false;
					}
				} else {
					if (Input.GetKey (KeyCode.W)) {
						StartCoroutine ("characterSwimFWD");

					}
				}

			}
			if (Input.GetKeyDown (KeyCode.A)) {
				if (isSwimming == false) {
					if (Time.time - lftLTT < 0.5f && st.stamina > 10f) {
						StartCoroutine ("characterRunStrafeLFT");
						lftLTT = Time.time;
						isSprinting = true;
					} else {
						StartCoroutine ("characterStrafeLFT");
						lftLTT = Time.time;
						isSprinting = false;
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.S)) {
				if (isSwimming == false) {
					if (Time.time - bkwdLTT < 0.5f && st.stamina > 10f) {
						StartCoroutine ("characterRunBKWD");
						bkwdLTT = Time.time;
						isSprinting = true;
					} else {
						StartCoroutine ("characterWalkBKWD");
						bkwdLTT = Time.time;
						isSprinting = false;
					}
				}
			}
			if (Input.GetKeyDown (KeyCode.D)) {
				if (isSwimming == false) {
					if (Time.time - rgtLTT < 0.5f && st.stamina > 10f) {
						StartCoroutine ("characterRunStrafeRGT");
						rgtLTT = Time.time;
						isSprinting = true;
					} else {
						StartCoroutine ("characterStrafeRGT");
						rgtLTT = Time.time;
						isSprinting = false;
					}
				}
			}
			transform.Rotate (0, Input.GetAxis ("Mouse X"), 0);
			playerCamera.transform.Rotate (Input.GetAxis ("Mouse Y"), 0, 0);
			playerCamera.transform.localRotation = new Quaternion (Mathf.Clamp (playerCamera.transform.localRotation.x, -0.6f, 0.6f), playerCamera.transform.localRotation.y, playerCamera.transform.localRotation.z, playerCamera.transform.localRotation.w); 

		} else {
			anim.SetInteger ("Direction", 0);
			anim.SetInteger ("MovementSpeed", 0);
		}
	}


	public IEnumerator characterStop(){
		anim.SetInteger ("MovementSpeed", 0);
		anim.SetInteger ("Direction", 0);
		anim.SetBool ("isSwimming", false);
		yield break;
	}
	public IEnumerator characterWalkFWD(){
		anim.SetInteger ("MovementSpeed", 1);
		anim.SetInteger ("Direction", 1);
		anim.SetBool ("isSwimming", false);
		yield break;
	}

	public IEnumerator characterRunFWD(){
		anim.SetInteger ("MovementSpeed", 2);
		anim.SetInteger ("Direction", 1);
		anim.SetBool ("isSwimming", false);
		yield break;
	}
	public IEnumerator characterStrafeLFT(){
		anim.SetInteger ("MovementSpeed", 1);
		anim.SetInteger ("Direction", 2);
		anim.SetBool ("isSwimming", false);
		yield break;
	}
	public IEnumerator characterRunStrafeLFT(){
		anim.SetInteger ("MovementSpeed", 2);
		anim.SetInteger ("Direction", 2);
		anim.SetBool ("isSwimming", false);
		yield break;
	}
	public IEnumerator characterStrafeRGT(){
		anim.SetInteger ("MovementSpeed", 1);
		anim.SetInteger ("Direction", 4);
		anim.SetBool ("isSwimming", false);
		yield break;
	}
	public IEnumerator characterRunStrafeRGT(){
		anim.SetInteger ("MovementSpeed", 2);
		anim.SetInteger ("Direction", 4);
		anim.SetBool ("isSwimming", false);
		yield break;
	}
	public IEnumerator characterRunBKWD(){
		anim.SetInteger ("MovementSpeed", 2);
		anim.SetInteger ("Direction", 3);
		anim.SetBool ("isSwimming", false);
		yield break;
	}
	public IEnumerator characterWalkBKWD(){
		anim.SetInteger ("MovementSpeed", 1);
		anim.SetInteger ("Direction", 3);
		anim.SetBool ("isSwimming", false);
		yield break;
	}

	public IEnumerator characterSwimFWD(){
		anim.SetInteger ("MovementSpeed", 1);
		anim.SetInteger ("Direction", 1);
		anim.SetBool ("isSwimming", true);
		yield break;
	}
		
}