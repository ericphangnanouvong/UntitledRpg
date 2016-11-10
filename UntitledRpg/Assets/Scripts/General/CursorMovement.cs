using UnityEngine;
using System.Collections;

public class CursorMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}
}
