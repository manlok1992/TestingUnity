using UnityEngine;
using System.Collections;
using Spine;

public class dasad : MonoBehaviour {
	public SkeletonDataAsset skeletonDataAsset;
	public Skeleton skeleton;
	public Bone bone;
	public SkeletonRenderer skeletonRenderer;
	public string boneName;
	public int fingerCount = 0;
//	public Rect rect;
	float scale;
	float sx, sy;
	public Vector2 vect2;
	float width, height;
	RegionAttachment att;
	string bytes;
	static public Vector2 playMatchPos;
	// Use this for initialization
	void Start () {
		SkeletonData skeletonData = skeletonDataAsset.GetSkeletonData(false);
		skeleton = new Skeleton(skeletonData);
		bone = skeletonRenderer.skeleton.FindBone(boneName);
//		rect = new Rect();
		att = (RegionAttachment)skeletonRenderer.skeleton.FindSlot("btn_playmatch").attachment;
		sx = Screen.width/1675.0f;
		sy = Screen.height/1044.0f;
		scale = sx > sy ? sx : sy;
		width = att.width*scale;
		height = att.height*scale;
	}

	// Update is called once per frame
	void Update () {
//		skeletonRenderer.skeleton.FindBone("team_slot1").x = 0;
//		skeletonRenderer.skeleton.FindBone("team_slot1").y = 0;
//		skeletonRenderer.skeleton.FindSlot("btn_playmatch").a -= 0.02f;
//		rect.Set (Screen.width/2+skeletonRenderer.skeleton.FindBone("btn_playmatch").x*scale-width/2
//		          ,Screen.height/2+skeletonRenderer.skeleton.FindBone("btn_playmatch").y*scale-height/2, width, height);
//		vect2 = Input.mousePosition;
//		Debug.Log (Input.touchCount);
//		if(Input.touchCount > 0) {
//			Debug.Log("Tocuh");
//			GameObject.Find("New Sprite").guiText.text = "0";
//			for(int i = 0; i < Input.touchCount; i++) {
//				GameObject.Find("New Sprite").guiText.text = "1";
//				if(Input.GetTouch(i).phase == TouchPhase.Began) {
//					GameObject.Find("New Sprite").guiText.text = "2";
//					Rect rect1 = touchRect("team_slot1", "team_slot1");
//					if(rect1.Contains(Input.GetTouch(i).position)) {
//							GameObject.Find("New Sprite").guiText.text = "3";
//							Debug.Log ("touch team slot 1");
//							skeletonRenderer.skeleton.FindBone("team_slot1").x = 100;
//					}	
//				}
//			}
//		}
		
		playMatchPos.x = skeletonRenderer.skeleton.FindBone("btn_playmatch").x;
		playMatchPos.y = skeletonRenderer.skeleton.FindBone("btn_playmatch").y;
//		Debug.Log (playMatchPos.x+ " "+ playMatchPos.y);
	}
	
	void OnGUI() {
		
	}

	Rect touchRect(string slotName, string boneName) 
	{
		float width = ((RegionAttachment)skeletonRenderer.skeleton.FindSlot(slotName).attachment).width*scale;
		float height = ((RegionAttachment)skeletonRenderer.skeleton.FindSlot(slotName).attachment).height*scale;
		float x = Screen.width/2+skeletonRenderer.skeleton.FindBone(boneName).x*scale-width/2;
		float y = Screen.height/2+skeletonRenderer.skeleton.FindBone(boneName).y*scale-height/2;
		return new Rect(x,y,width,height);
	}

//	void OnMouseDown() {
//		if(Input.GetMouseButton(0)) {
//			Rect rect = touchRect("team_slot1", "team_slot1");
//			if(rect.Contains(Input.mousePosition)) {
//				Debug.Log ("touch team slot 1");
//				skeletonRenderer.skeleton.FindBone("team_slot1").x = 100;
//				return;
//			}
//			rect = touchRect("team_slot2", "team_slot2");
//			if(rect.Contains(Input.mousePosition)) {
//				Debug.Log ("touch team slot 2");
//				skeletonRenderer.skeleton.FindBone("team_slot2").x = 2010;
//				return;
//			}
//			rect = touchRect("team_slot3", "team_slot3");
//			if(rect.Contains(Input.mousePosition)) {
//				Debug.Log ("touch team slot 3");
//				skeletonRenderer.skeleton.FindBone("team_slot3").x = 300;
//				return;
//			}
//			rect = touchRect("team_slot4", "team_slot4");
//			if(rect.Contains(Input.mousePosition)) {
//				Debug.Log ("touch team slot 4");
//				skeletonRenderer.skeleton.FindBone("team_slot4").x = 400;
//				return;
//			}
//			rect = touchRect("team_slot5", "team_slot5");
//			if(rect.Contains(Input.mousePosition)) {
//				Debug.Log ("touch team slot 5");
//				skeletonRenderer.skeleton.FindBone("team_slot5").x = 500;
//				return;
//			}
//		}
//	}
}


