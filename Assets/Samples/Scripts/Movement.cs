using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float Speed = 5.0f;

	private Vector2 _input = new Vector2();

	void Update(){

		_input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

		transform.Translate((new Vector3(_input.x, _input.y, 0) * Speed) * Time.deltaTime);

	}
}
