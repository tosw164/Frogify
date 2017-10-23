using UnityEngine;
using System.Collections;

public class ChangeCursor : MonoBehaviour {

	private Texture2D cursor;//texture image

	// Use this for initialization
	void Start () {
		//cursor = Resources.Load<Texture2D> ("chat");
		//cursor.Resize (5, 5);
		//cursor.width = 4;
	
	}
	
	void OnMouseOver(){
		//Cursor.SetCursor (cursor, Vector2.zero, CursorMode.Auto);
	}


	void OnMouseExit(){
		//Cursor.SetCursor (null, Vector2.zero, CursorMode.Auto);
	}
}
