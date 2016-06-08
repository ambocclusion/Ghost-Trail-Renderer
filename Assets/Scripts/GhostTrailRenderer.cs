using UnityEngine;
using System.Collections;

public class GhostTrailRenderer : MonoBehaviour {

	public float Rate = .1f;
	public float DistanceThreshold = .15f;
	public float LifeTime = .5f;
	public float FadeSpeed = 2.0f;

	private Mesh _myMesh;
	private float _lastGhost = 0.0f;
	private Vector3 _lastPos = new Vector3();

	void Awake(){

		_myMesh = GetComponent<MeshFilter>().mesh;

	}

	void Update(){
		
		if(Time.time >= _lastGhost + Rate && Vector3.Distance(transform.position, _lastPos) > DistanceThreshold){

			CreateGhost();

		}

	}

	private void CreateGhost(){

		GameObject obj = new GameObject("Ghost");
		obj.AddComponent<MeshFilter>().mesh = _myMesh;
		obj.AddComponent<MeshRenderer>().material = GetComponent<MeshRenderer>().material;
		obj.transform.position = transform.position;
		obj.AddComponent<GhostTrail>().Init(LifeTime, FadeSpeed);
		_lastGhost = Time.time;
		_lastPos = transform.position;

	}

}
