using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	public GameObject bullet;
	public GameObject bulletHole;
	public Texture2D cursor;
	bool isReloading = false;
	WeaponData wd;
	public int maxShots;
	public int currentShots = 0;
	AudioSource audio;
	public AudioClip reloadClip;
	GameObject sp;
	//GameObject gunHolder;
	GameObject spawnedBullet;
	Ray ray;
	RaycastHit hit;
	PlayerUI pui;
	// Use this for initialization
	void Start () {
		wd = this.GetComponentInChildren<WeaponData> ();
		maxShots = (int)wd.maxShots;
		sp = GameObject.FindGameObjectWithTag("BulletSpawner");
		//gunHolder = GameObject.FindGameObjectWithTag("GunHolder");
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.SetCursor (cursor, Vector2.zero, CursorMode.Auto);
		pui = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerUI> ();
		audio = GameObject.FindGameObjectWithTag ("Audio").GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		wd.currentShots = currentShots;
		if(currentShots == maxShots){
			if(Input.GetKeyDown(KeyCode.R)){
				StartCoroutine ("waitToShoot");
			}
		}
		if (Input.GetKeyDown (KeyCode.Mouse0) && pui.menuOpen != true && GameObject.FindGameObjectsWithTag ("Bullet").Length <= 0) {
			if (currentShots < maxShots) {
				currentShots = currentShots + 1;

				GameObject spawnedBullet = Instantiate (wd.bulletPrefab, sp.transform.position, Quaternion.identity) as GameObject;

				ray = this.GetComponentInChildren<Camera> ().ScreenPointToRay (new Vector3 ((Screen.width / 2) + 10f, (Screen.height / 2), 0));
				Destroy (spawnedBullet, 0.5f);
		
				if (Physics.Raycast (ray, out hit, 50f)) {
					if (hit.collider.GetComponent<CapsuleCollider> () != null) {
						GameObject spawnedBulletHole = Instantiate (bulletHole, new Vector3 (hit.point.x, hit.point.y + 0.005f, hit.point.z), Quaternion.FromToRotation (Vector3.up, hit.normal)) as GameObject;
						spawnedBulletHole.transform.parent = hit.collider.gameObject.transform;
						Destroy (spawnedBulletHole, 50f);
					} else {
						GameObject spawnedBulletHole = Instantiate (bulletHole, new Vector3(hit.point.x, hit.point.y+0.005f, hit.point.z), Quaternion.FromToRotation(Vector3.up, hit.normal)) as GameObject;
						Destroy (spawnedBulletHole, 50f);
					}

					Debug.DrawRay (ray.origin, ray.direction * 50f, Color.red);
					Debug.Log (hit.collider + ", " + hit.distance);
					if(hit.collider.GetComponentInParent<Health>()){
						hit.collider.GetComponentInParent<Health> ().takeDamage (20f);
					}
				}
			}	
		}
	}
	public IEnumerator waitToShoot(){
		if(isReloading != true){
			isReloading = true;
			audio.PlayOneShot (reloadClip, 2f);
			yield return new WaitForSeconds(2.25f);
			currentShots = 0;
			isReloading = false;
			yield break;
		}

	}


}

