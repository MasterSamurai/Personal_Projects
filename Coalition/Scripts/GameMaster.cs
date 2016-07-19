using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameMaster : MonoBehaviour {
	
	public Transform player;
	public PlayerUI pui;
	// Use this for initialization
	void Start () {
		if(SceneManager.GetActiveScene().name != "LoadScreen"){
			spawnCharacter ();
			pui = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerUI> ();
		}

	}
	// Update is called once per frame
	void Update () {
		
	}

	public void quitGame(){
		StartCoroutine ("cQuitGame");
	}

	public void settings(){
		pui.openSettings();
	}

	public void adjustFOV(){
		pui.adjustFOV ();
	}

	public IEnumerator cQuitGame(){
		Application.Quit();
		yield break;
	}

	public void loadGame(){
		StartCoroutine ("cLoadGame");
	}

	public IEnumerator cLoadGame(){
		SceneManager.LoadScene ("SinglePlayer");
		yield break;
	}

	public void loadEastAsiaCampaign(){
		StartCoroutine ("cLoadEastAsiaCampaign");
	}

	public IEnumerator cLoadEastAsiaCampaign(){
		SceneManager.LoadScene ("EastAsiaSinglePlayer");
		yield break;
	}
		
	public void spawnCharacter(){
		StartCoroutine ("cSpawnCharacter");
	}
	public IEnumerator cSpawnCharacter(){
		Instantiate (player, new Vector3 (1101,950,1101), new Quaternion(0,0,0,0));
		yield break;
	}

}
