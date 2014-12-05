using UnityEngine;
using System.Collections;
using System.IO;
using System;
public class testSocket : MonoBehaviour {
	// Use this for initialization
	void Start() {
		StartCoroutine(waiting());
	}

	IEnumerator waiting() {
			// We should only read the screen after all rendering is complete
		yield return new WaitForEndOfFrame();
		// Create a texture the size of the screen, RGB24 format
		int width = Screen.width;
		int height = Screen.height;
		Texture2D tex = new Texture2D( width, height, TextureFormat.RGB24, false );
//		// Read screen contents into the texture
		tex.ReadPixels( new Rect(0, 0, width, height), 0, 0 );
		tex.Apply();
		// Encode texture into PNG
		byte[] bytes = tex.EncodeToJPG();
		Destroy( tex );
//		// Create a Web Form
		WWWForm form = new WWWForm();
		form.AddField("frameCount", Time.frameCount.ToString());
		form.AddBinaryData("fileUpload", bytes, "screenShot.png", "image/png");
		// Upload to a cgi script
		form.AddField("test", 1234324);
		form.AddField("test2", 1234);
		WWW w = new WWW("http://127.0.0.1:1111", form);
		yield return w;
		if (w.error != null)
			Debug.Log("Error: "+w.error);
		else
			Debug.Log ("get data: "+w.text);
	}

	// Update is called once per frame
	void Update () {

	}
}
	