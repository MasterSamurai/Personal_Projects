using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerUI : MonoBehaviour {

	public bool menuOpen = false; //boolean to determine if menu is open or not
	public bool settingsOpen = false;
	private float[] legA; //A triangle leg holding z value distance
	private float[] legB; //A triangle leg holding x value distance
	private float[] hypot; //A triangle hypotneuse holding distance
	private float[] angleA; //A triangle angle holding angle at which target is at, relative to the player
	Text questBarText; //The text displaying distance to targets on the Quest Bar
	Text bulletUIText;
	GameObject[] targets; //An array holding all the targets
	RectTransform compassBar; //The moving part of the compass bar containing compass directions
	public GameObject point; //The prefab for objectives
	Shooting s;
	GameObject c; //Gameobject of compassbar
	Image[] points1; //Array containing one point per target
	Image[] points2; //Complementary array containing one point per target

	void Start () {
		if(SceneManager.GetActiveScene().name != "LoadScreen"){
			GameObject.FindGameObjectWithTag ("Menu").GetComponent<CanvasGroup>().alpha = 0;
			GameObject.FindGameObjectWithTag ("SettingsMenu").GetComponent<CanvasGroup>().alpha = 0;
		}
		c = GameObject.FindGameObjectWithTag ("Compass");
		s = this.GetComponent<Shooting> ();
		bulletUIText = GameObject.FindGameObjectWithTag ("BulletUI").GetComponentInChildren<Text>();
		compassBar = GameObject.FindGameObjectWithTag ("Compass").GetComponent<RectTransform> ();
		questBarText = GameObject.FindGameObjectWithTag ("QuestBarText").GetComponent<Text> ();
		targets = new GameObject[GameObject.FindGameObjectsWithTag ("Target").Length];
		GameObject.FindGameObjectsWithTag ("Target").CopyTo (targets, 0);

		legA = new float[targets.Length];
		legB = new float[targets.Length];
		hypot = new float[targets.Length];
		angleA = new float[targets.Length];
		points1 = new Image[targets.Length];
		points2 = new Image[targets.Length];
		spawnObjectivePoints ();
	}

	void Update () {
		updateBulletCount ();
		updateCompassBar ();
		if(Input.GetKeyDown(KeyCode.Escape)){
			if (GameObject.FindGameObjectWithTag ("Menu").GetComponent<CanvasGroup> ().alpha != 0) {
				GameObject.FindGameObjectWithTag ("Menu").GetComponent<CanvasGroup> ().alpha = 0;
				GameObject.FindGameObjectWithTag ("SettingsMenu").GetComponent<CanvasGroup> ().alpha = 0;
				menuOpen = false;
				settingsOpen = false;

			} else {
				GameObject.FindGameObjectWithTag ("Menu").GetComponent<CanvasGroup>() .alpha = 1;
				menuOpen = true;
				settingsOpen = false;
			}
		}
		if (menuOpen == false && settingsOpen == false) {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = true;
		} else {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}

	public void openSettings(){
		if (menuOpen == true) {
			GameObject.FindGameObjectWithTag ("Menu").GetComponent<CanvasGroup> ().alpha = 0;
			GameObject.FindGameObjectWithTag ("SettingsMenu").GetComponent<CanvasGroup> ().alpha = 1;
			settingsOpen = true;
		} 
		if(settingsOpen == true || menuOpen == false){
			settingsOpen = false;
		}
	}

	public void adjustFOV(){
		this.gameObject.GetComponentInChildren<Camera>().fieldOfView = GameObject.FindGameObjectWithTag ("SettingsMenu").GetComponentInChildren<Slider> ().value; 
	}
	#region CompassBar
	public void spawnObjectivePoints(){
		for(int i = 0; i < targets.Length; i++){
			GameObject spawnedPoint = Instantiate (point, point.transform.localPosition, Quaternion.identity) as GameObject;
			points1[i] = spawnedPoint.GetComponent<Image>();
			spawnedPoint.transform.SetParent (c.transform, false);
			GameObject spawnedPoint2 = Instantiate (point, point.transform.localPosition, Quaternion.identity) as GameObject;
			points2[i] = spawnedPoint2.GetComponent<Image>();
			spawnedPoint2.transform.SetParent (c.transform, false);
		}
	}

	public void updateCompassBar(){
		for (int i = 0; i < targets.Length; i++) {
			legA[i] = this.transform.position.z - targets [i].GetComponent<Transform> ().transform.position.z;
			legB[i] = this.transform.position.x - targets [i].GetComponent<Transform> ().transform.position.x;
			hypot[i] = Mathf.Pow (legA[i], 2) + Mathf.Pow (legB[i], 2);
			angleA[i] = Mathf.Atan2 (legB[i], legA[i]) * Mathf.Rad2Deg;
			points1[i].transform.localPosition = new Vector3 (-1835f + (angleA[i]) * (960f / 90f), point.transform.localPosition.y, 0);
			points2[i].transform.localPosition = new Vector3 (2005f + (angleA[i]) * (960f / 90f), point.transform.localPosition.y, 0);
			questBarText.text = "Destination: " + Mathf.Abs ((int)hypot[i])/1000 + "m";
		}
		if (this.transform.eulerAngles.y >= 0 && this.transform.eulerAngles.y < 180) {
			compassBar.transform.localPosition = new Vector3 (this.transform.eulerAngles.y * -(960f / 90f), compassBar.transform.localPosition.y, 0);
		} 
		if (this.transform.eulerAngles.y >= 180 && this.transform.eulerAngles.y < 360) {
			compassBar.transform.localPosition = new Vector3 (3840f + this.transform.eulerAngles.y * -(960f / 90f), compassBar.transform.localPosition.y, 0);
		}
	}
	#endregion

	public void updateBulletCount(){
		bulletUIText.text =  (8 - s.currentShots) + " / " + s.maxShots;
	}


}
