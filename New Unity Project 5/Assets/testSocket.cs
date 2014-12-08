using UnityEngine;
using System.Collections;
using System.IO;
using System;
using SimpleJSON;
public class testSocket : MonoBehaviour {
	// Use this for initialization
	void Start() {
		StartCoroutine(waiting());
	}

	IEnumerator waiting() {
		JSONObject obj = new JSONObject(JSONObject.Type.OBJECT);
		JSONObject obj1 = new JSONObject(JSONObject.Type.OBJECT);
		obj.AddField("id", 1);
		obj.AddField("type", "get_team");
		obj1.AddField("id", 2);
		obj1.AddField("type", "getUsingBackground");
		obj1.AddField("getUsingBgInfo", "getUsingBgInfo");
		obj.AddField("getUsingBgInfo", "getUsingBgInfo");

		JSONObject all = new JSONObject(JSONObject.Type.OBJECT);
		all.Add(obj);
		all.Add(obj1);
		
		Debug.Log (all.ToString());
		Debug.Log (all.ToString().Length);
//		SimpleJSON.JSONNode node ;
//		int width, height;
//		width = UnityEngine.Random.Range(0,Screen.width);
//		height = UnityEngine.Random.Range(0,Screen.height);
//		Debug.Log ("height: "+height);
//		Debug.Log ("width: "+width);
//			// We should only read the screen after all rendering is complete
//		yield return new WaitForEndOfFrame();
////		// Create a texture the size of the screen, RGB24 format
//		Texture2D tex = new Texture2D( width, height, TextureFormat.RGB24, false );
//////		// Read screen contents into the texture
//		tex.ReadPixels( new Rect(0, 0, width, height));
//		tex.Apply();
//		// Encode texture into PNG
//		byte[] bytes = tex.EncodeToJPG();
//		Destroy( tex );
//		// Create a Web Form
		WWWForm form = new WWWForm();
//		form.AddField("frameCount", Time.frameCount.ToString());
//		form.AddBinaryData("fileUpload", bytes, "screenShot.jpg", "image/jpg");
		// Upload to a cgi script
		
//		SimpleJSON.JSONNode each ;
//		each["id"] = "1";
//		each["type"] = "get_team";

//		node.Add(each);
//		Debug.Log (node.ToString());
//		form.AddField("test", 1234324);
//		form.AddField("test2", 1234);

		var postHeader = new Hashtable();
		
		postHeader.Add("Content-Type", "application/json");
		postHeader.Add("Cookie", "Our seession cookie");
		
		byte[] bytes = System.Text.Encoding.UTF8.GetBytes(all.ToString());
//		byte[] bytes = System.Text.Encoding.UTF8.GetBytes(temp);
		WWW w = new WWW("http://169.254.31.4:3001/api/soccer/batch_test?token=c6696460-7393-11e4-a057-f95e2fa260d1", bytes, postHeader);
		yield return w;
		if (w.error != null)
			Debug.Log("Error: "+w.error);
		else {
			Debug.Log (w.text);
			var n = SimpleJSON.JSONNode.Parse(w.text);
//			Debug.Log (n);
			//			Debug.Log (n.Count);
			var temp1 = SimpleJSON.JSONNode.Parse(n["data"][0]["team"][0]["LevelData"].ToString());
			var temp2 = SimpleJSON.JSONNode.Parse(n["data"][1].ToString());
//			var temp2 = SimpleJSON.JSONNode.Parse(temp1.ToString());
			//			Debug.Log (temo2);
			string str1 = temp1["Level_Id"].ToString();
			string str2 = temp2["Filename"].ToString();
			Debug.Log (str1);
			Debug.Log (str2);
//			for(int i = 0; i < n.Count; i++) {
//				string temp = n[i]["id"].ToString();
//				string temp1 = n[i]["name"].ToString();
//				string temp2 = n[i]["message"].ToString();
//				Debug.Log ("get data id: "+temp);
//				Debug.Log ("get data name: "+temp1);
//				Debug.Log ("get data message: "+temp2);
//			}

		}
	}

	// Update is called once per frame
	void Update () {

	}
}
	