using UnityEngine;
using System.Collections;

public class AIMovement : MonoBehaviour {

	public float aggroRange = 10f;
	public Vector3 aiCenter;
	public float patrolRadius = 10f;
	//float angleA;
	//bool respawn = false;
	GameObject player;
	Animator anim;
	MeshFilter aiMesh;
	MeshCollider aiMeshCollider;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		aiCenter = this.transform.position;
		anim.SetInteger ("MovementSpeed", 1);
		anim.SetInteger ("Direction", 1);
		anim.SetBool ("isSwimming", false);
		InvokeRepeating ("aiMove", 2f, 20f);
		aiMesh = GetComponentInChildren<MeshFilter> ();
		aiMeshCollider = GetComponentInChildren<MeshCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
		//aiMesh.mesh.RecalculateNormals ();
		//aiMeshCollider.sharedMesh = null;
		//aiMeshCollider.sharedMesh = aiMesh.mesh;
		if(this.transform.position.x > aiCenter.x + patrolRadius || this.transform.position.x < aiCenter.x - patrolRadius || this.transform.position.z > aiCenter.z + patrolRadius || this.transform.position.z < aiCenter.z - patrolRadius){
			Debug.Log ("Past Radius");
			this.transform.Rotate (new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y + 180, transform.eulerAngles.z));
		}
	}

	public void aiMove(){
		this.transform.Rotate (new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y + Random.Range(0,180), transform.eulerAngles.z));
	}

}
