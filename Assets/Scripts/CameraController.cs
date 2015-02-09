using UnityEngine;
using System.Collections;

/// <summary>
/// Adapted Camera controller based on http://wiki.unity3d.com/index.php/CarSmoothFollow by David O'Donoghue (a.k.a Trooper from ODD Games)
/// </summary>
public class CameraController : MonoBehaviour {

 public Transform target_mesh;
 public float distance = 3.0f;
 public float height = 3.0f;
 public float heightDamping = 2.0f;
 public float lookAtHeight = 0.0f;
 public float rotationSnapTime = 0.5F;
 public float distanceSnapTime;
 public float distanceMultiplier;
 private Vector3 lookAtVector;
 private float usedDistance;
 private float wantedRotationAngle;
 private float wantedHeight;
 private float currentRotationAngle;
 private float currentHeight;
 private Quaternion currentRotation;
 private Vector3 wantedPosition;
 private float yVelocity = 0.0F;
 private float zVelocity = 0.0F;
	
 void Start () {
	lookAtVector = new Vector3(0, lookAtHeight, 0);
 }

 void LateUpdate () {
	
	wantedHeight = target_mesh.position.y + height;
	currentHeight = transform.position.y;

	wantedRotationAngle = target_mesh.eulerAngles.y;
	currentRotationAngle = transform.eulerAngles.y;

	currentRotationAngle = Mathf.SmoothDampAngle(currentRotationAngle, wantedRotationAngle, ref yVelocity, rotationSnapTime);

	currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);

	wantedPosition = target_mesh.position;
	wantedPosition.y = currentHeight;

	usedDistance = Mathf.SmoothDampAngle(usedDistance, distance + distanceMultiplier, ref zVelocity, distanceSnapTime); 

	wantedPosition += Quaternion.Euler(0, currentRotationAngle, 0) * new Vector3(0, 0, -usedDistance);

	transform.position = wantedPosition;

	transform.LookAt(target_mesh.position + lookAtVector);
	
 }
}
