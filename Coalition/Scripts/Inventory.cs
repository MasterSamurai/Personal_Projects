using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Inventory : MonoBehaviour {

	public Button slot1;
	public Button slot2;
	public Button slot3;
	public Button slot4;
	public Button slot5;
	public Button slot6;
	public Button selected;
	public Button[] slotList;
	public bool[] guns;
	public Image[] items;
	public Canvas pCanvas;
	// Use this for initialization
	void Start () {
		slot1 = GameObject.FindGameObjectWithTag ("Slot1").GetComponent<Button> ();
		slot2 = GameObject.FindGameObjectWithTag ("Slot2").GetComponent<Button> ();
		slot3 = GameObject.FindGameObjectWithTag ("Slot3").GetComponent<Button> ();
		slot4 = GameObject.FindGameObjectWithTag ("Slot4").GetComponent<Button> ();
		slot5 = GameObject.FindGameObjectWithTag ("Slot5").GetComponent<Button> ();
		pCanvas = slot1.GetComponentInParent<Canvas> ();
		slotList = new Button[5] {slot1, slot2, slot3, slot4, slot5};
		guns = new bool[5] {false, false, false, false, false};
		selected = slotList[0];
		guns [0] = true;
		slotList[0].GetComponent<Image> ().color= new Color32 (255,255,255,75);
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			selected = slot1;
			StartCoroutine ("updateCanvas");
			//enableShooting ();
		}
		if(Input.GetKeyDown(KeyCode.Alpha2)){
			selected = slot2;
			StartCoroutine ("updateCanvas");
			//disableShooting ();
		}
		if(Input.GetKeyDown(KeyCode.Alpha3)){
			selected = slot3;
			StartCoroutine ("updateCanvas");
			//disableShooting ();
		}
		if(Input.GetKeyDown(KeyCode.Alpha4)){
			selected = slot4;
			StartCoroutine ("updateCanvas");
			//disableShooting ();
		}
		if(Input.GetKeyDown(KeyCode.Alpha5)){
			selected = slot5;
			StartCoroutine ("updateCanvas");
			//disableShooting ();
		}
		if (Input.GetKeyDown (KeyCode.P)) {
			if (GameObject.FindGameObjectWithTag ("Inventory").GetComponent<CanvasGroup>().alpha == 0f) {

				GameObject.FindGameObjectWithTag ("Inventory").GetComponent<CanvasGroup> ().alpha = 1f;
			} else {
				GameObject.FindGameObjectWithTag ("Inventory").GetComponent<CanvasGroup> ().alpha = 0f;
			}
		
		}
	}
	public IEnumerator updateCanvas(){
		for(int i = 0; i < slotList.Length; i++){
			if (slotList [i].GetComponent<Image> ().color != new Color32 (0, 0, 0, 75) && slotList [i] != selected) {
				yield return new WaitForSeconds (0.05f);
				slotList [i].GetComponent<Image> ().color = new Color32 (0, 0, 0, 75);
			} else {
				if(slotList[i] == selected){
					slotList[i].GetComponent<Image> ().color= new Color32 (255,255,255,75);
				}
			}
		}
		yield break;
	}
	public void disableShooting(){
		GameObject.FindGameObjectWithTag ("GunHolder").gameObject.SetActive (false);
		this.GetComponent<Shooting> ().enabled = false;
	}

	public void enableShooting(){
		GameObject.FindGameObjectWithTag ("GunHolder").SetActive (true);
		this.GetComponent<Shooting> ().enabled = true;
	}
}
