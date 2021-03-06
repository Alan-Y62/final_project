using UnityEngine;
using UnityEngine.EventSystems;

//A simple script that allows a game object to teleport to a location based on raycast hit. Not complete.

public class GVRTeleport : MonoBehaviour {

	/*
	[Tooltip("Toggle, on for when you need to use the mouse to look around. off for when you want to use GVR look around.")]
	public bool debugWithMouse;
	*/

	/*
	[Tooltip("Toggle,used for when you want to test the line Renderer. On for no teleporting")]
	public bool debugNoJump;
	*/
	
	[Tooltip("Toggle, on for when applied to camera only. this ensures that the camera will always be set to the variable height")]
	public bool useViewHeight;

	/*
	[Tooltip("Toggle, turns on Debug.DrawLine.")]
	public bool debugLine;
	*/
	
	[Tooltip("height that you would like ensure the camera stays at. Y axis. ")]
	public float viewHeight = 7f;

	Vector3 fwd;
	public float maxDistance = 10f;
	public LineRenderer line;
	public GameObject parent;
	public GameObject targetIndicator;

	public StraightLineParam genLine;

	void Start(){
	}


	void Update(){
		RaycastHit hit;
		Ray ray;

		/*
		if(debugWithMouse){
			Vector2 mousePos = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);
			 ray = Camera.main.ViewportPointToRay(mousePos);
		}else{
			ray = new Ray(transform.position, transform.forward);
		}
		*/
		ray = new Ray(transform.position, transform.forward);

		if(Physics.Raycast(ray, out hit)){
			//Debug.Log(hit.collider);
			Debug.DrawLine(transform.position, hit.point, Color.red);	
		}

		if(Input.GetMouseButton(0)){
			if(Physics.Raycast(ray, out hit)){
				if(hit.transform.gameObject.GetComponent<EventTrigger>() == null){ //if pointer is on object without event triggers
					//teleLoc = hit.point;
					//targetIndicator.transform.position = new Vector3(hit.point.x, targetIndicator.transform.position.y, hit.point.z);
					if(useViewHeight){
						targetIndicator.transform.position = new Vector3(hit.point.x, hit.point.y + viewHeight, hit.point.z);
					}else{
						targetIndicator.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
					}
					targetIndicator.transform.LookAt(hit.point);
					targetIndicator.GetComponent<Light>().intensity = 8;

					//line.SetVertexCount(50);
					//genLineSin(new Vector3(ray.origin.x+2,ray.origin.y,ray.origin.z) /*- new Vector3(0, .5f, 0)*/, hit.point);
				
					genLine.genLine(new Vector3(ray.origin.x + 2, ray.origin.y-.5f, ray.origin.z), hit.point);

					line.material.SetTextureOffset("_MainTex", new Vector2(Time.timeSinceLevelLoad * -4f, 0f));
					line.material.SetTextureScale("_MainTex", new Vector2(hit.point.magnitude, 1f));
				}
			}
		}

		if(Input.GetMouseButtonUp(0)){	
			if(Physics.Raycast(ray, out hit)){
				//if(!debugNoJump){
				if(hit.transform.gameObject.GetComponent<EventTrigger>() == null){ //if pointer is on object without event triggers
					if(useViewHeight){
						parent.transform.position = new Vector3(hit.point.x, hit.point.y + viewHeight, hit.point.z);
					}else{
						parent.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
					}
				}
				//}
				
				//if(!debugLine){
					line.SetVertexCount(0);
				//}
			}
			targetIndicator.GetComponent<Light>().intensity = 0;
		}
		Debug.DrawRay(this.transform.position, ray.direction * 5, Color.blue);// .DrawLine(transform.position, hit.point, Color.red);
	}
}