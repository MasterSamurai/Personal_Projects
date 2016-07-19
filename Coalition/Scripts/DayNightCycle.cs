using UnityEngine;
using System.Collections;

public class DayNightCycle : MonoBehaviour {
	public float speed = 0.05f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (Vector3.zero, Vector3.right, speed * Time.deltaTime);
		transform.LookAt (Vector3.zero);
	}
}
