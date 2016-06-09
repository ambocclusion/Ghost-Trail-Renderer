using UnityEngine;
using System.Collections;

public class GhostTrail : MonoBehaviour {

	private float _lifeTime = .1f;
	private float _startTime = 0.0f;
	private float _fadeSpeed = .1f;
	private float _scaleSpeed = .1f;

	private Renderer _renderer;
	private Color _myColor;

	public void Init(float lifetime, float fadespeed, Vector3 scale, Quaternion rotation, float scalespeed){

		_renderer = GetComponent<Renderer>();
		_renderer.material.shader = Shader.Find("Transparent/Diffuse");
		transform.localScale = scale;
		transform.rotation = rotation;
		
		_lifeTime = lifetime;
		_fadeSpeed = fadespeed;
		_startTime = Time.time;
		_scaleSpeed = scalespeed;

	}

	void Update(){

		if(Time.time >= _startTime + _lifeTime)
			Destroy(this.gameObject);

	}

	void LateUpdate(){

		_myColor = _renderer.material.color;

		_myColor.a = Mathf.MoveTowards(_myColor.a, 0, _fadeSpeed * Time.deltaTime);

		_renderer.material.color = _myColor;

		transform.localScale = new Vector3(Mathf.MoveTowards(transform.localScale.x, 0, _scaleSpeed * Time.deltaTime), Mathf.MoveTowards(transform.localScale.y, 0, _scaleSpeed * Time.deltaTime), Mathf.MoveTowards(transform.localScale.z, 0, _scaleSpeed * Time.deltaTime));

	}
}
