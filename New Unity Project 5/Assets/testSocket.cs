using UnityEngine;
using System.Collections;
using System.IO;
using System;
public class testSocket : MonoBehaviour {
	string arr;
	// Use this for initialization
	SimpleJSON.JSONNode node;
	void Start() {
		StartCoroutine(waiting());
		PlayerPrefs.SetInt("123", 1);
	}

	IEnumerator waiting() {
			// We should only read the screen after all rendering is complete
		yield return new WaitForEndOfFrame();
//		// Create a texture the size of the screen, RGB24 format
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
		form.AddBinaryData("fileUpload", bytes, "screenShot.jpg", "image/jpg");
		// Upload to a cgi script
		form.AddField("test", 1234324);
		form.AddField("test2", 1234);
		WWW w = new WWW("http://169.254.31.4:1111", form);
		yield return w;
		if (w.error != null)
			Debug.Log("Error: "+w.error);
		else {
			arr = w.text;
			Debug.Log (w.text);
			var n = SimpleJSON.JSONNode.Parse(w.text);
			Debug.Log (n);
			Debug.Log (n.Count);
			for(int i = 0; i < n.Count; i++) {
				string temp = n[i]["id"].ToString();
				string temp1 = n[i]["name"].ToString();
				string temp2 = n[i]["message"].ToString();
				Debug.Log ("get data id: "+temp);
				Debug.Log ("get data name: "+temp1);
				Debug.Log ("get data message: "+temp2);
			}

		}
	}

	// Update is called once per frame
	void Update () {
		Debug.Log ("get: "+PlayerPrefs.GetInt("123"));
	}
}
	