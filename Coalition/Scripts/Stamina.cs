using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Stamina : MonoBehaviour {
	
	public float stamina = 110f;
	//public Slider staminaSlider;
	PlayerMovement pm;

	void Start () {
		pm = this.GetComponent<PlayerMovement>();
		//staminaSlider = GameObject.FindGameObjectWithTag("Stamina").GetComponentInChildren<Slider>();
	}

	void Update () {
		//staminaSlider.value = stamina;
		//StartCoroutine ("decreaseStamina");
	}

	public IEnumerator decreaseStamina(){
		while(pm.isSprinting == true && stamina > 0f){
			stamina -= 0.1f;
			yield return new WaitForSeconds (1f);
			if(stamina == 0f){
				pm.isSprinting = false;
			}
		}
		while(pm.isSprinting != true && stamina < 110f){
			stamina += 0.1f;
			yield return new WaitForSeconds (1f);
		}
		yield break;
	}
}
