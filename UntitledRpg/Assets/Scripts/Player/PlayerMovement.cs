using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float m_movementSpeed;
	private Vector3 m_newPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0))
		{
			m_newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			m_newPosition.z = transform.position.z;
			Debug.Log (m_newPosition);
			transform.position = Vector2.MoveTowards (this.transform.position, m_newPosition, Time.deltaTime*m_movementSpeed);
		}
}
}

