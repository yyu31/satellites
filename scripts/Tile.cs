using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
	
	public Vector2 gridPosition = Vector2.zero;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
            
	}
    
    	
	void OnMouseEnter() {
		transform.GetComponent<Renderer>().material.color = Color.yellow;
		
		Debug.Log("my position is (" + gridPosition.x + "," + gridPosition.y);
	}
	
	void OnMouseExit() {
		transform.GetComponent<Renderer>().material.color = Color.white;
	}
	
	
	void OnMouseDown() {
		GameManager.instance.moveCurrentPlayer(this);
	}


	
}
