using UnityEngine;
using System.Collections;

/// <summary>
/// C# port of the Smooth Follow Script of the Standard Assets Pack
/// </summary>
public class CameraController : MonoBehaviour {
	
	public Transform target;
	public float distance = 2f;
	public float height = 1f;
	public float heightDamping = 2.0f;
	public float rotationDamping = 3.0f;
	
	public float RotationXSpeed = 250f;
	public float RotationYSpeed = 120f;
	
	public float yMinLimit = -20;
	public float yMaxLimit = 80;
	
	private float x;
	private float y;
	
	private bool free_mode;
	
	void Start() {
		Vector3 angles = this.transform.eulerAngles;
		this.x = angles.y;
		this.y = angles.x;
		
		this.free_mode = false;
	}
	
	void Update() {
		if(Input.GetButton("Fire1") && Input.GetButton("Fire2")) {
			this.free_mode = true;
		} else {
			this.free_mode = false;
		}
	}
	
	// Update is called once per frame
	void LateUpdate() {
	
		// Early out if we don't have a target
		if(this.target == null) {
			return;
		}
		
		if(this.free_mode) {
			this.x += Input.GetAxis("Mouse X") * this.RotationXSpeed * 0.02f;
			this.y -= Input.GetAxis("Mouse Y") * this.RotationYSpeed * 0.02f;
			
			y = ClampAngle(y, yMinLimit, yMaxLimit);
			
			Quaternion rotation = Quaternion.Euler(y, x, 0);
			Vector3 position = rotation * (new Vector3(0, 0, -this.distance)) + this.target.position;
			
			this.transform.rotation = rotation;
			this.transform.position = position;
		} else {
			// Calculate the current rotation angles
			float wantedRotationAngle = this.target.eulerAngles.y;
			float wantedHeight = this.target.position.y + height;
		
			float currentRotationAngle = this.transform.eulerAngles.y;
			float currentHeight = this.transform.position.y;
		
			// Damp the rotation around the y-axis
			currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, this.rotationDamping * Time.deltaTime);
		
			// Damp the height
			currentHeight = Mathf.Lerp(currentHeight, wantedHeight, this.heightDamping * Time.deltaTime);
		
			// Convert the angle into a rotation
			Quaternion currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);
		
			// Set the position of the camera on the x-z plane to:
			// distance meters behind the target
			this.transform.position = this.target.position;
			this.transform.position -= currentRotation * Vector3.forward * distance;
		
			// Set the height of the camera
			Vector3 tmp = this.transform.position;
			tmp.y = currentHeight;
			this.transform.position = tmp;
		
			// Always look at the target
			this.transform.LookAt(target);
		}
	}
	
	private float ClampAngle(float angle, float min, float max) {
		if(angle < -360) {
			angle += 360;
		}
		if(angle > 360) {
			angle -= 360;
		}
		return Mathf.Clamp(angle, min, max);
	}
	
}
