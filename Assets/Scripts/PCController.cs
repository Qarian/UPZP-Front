using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
using System;
using FlatBuffers;

public class PCController : MonoBehaviour
{
    public Transform character;
    public Transform target;
	public Vector3 dest;
	public bool isLoaded = false;
	public AbstractMap map;
    public GameObject rayPlane;
	public Camera cam;
	public CharacterManager CM;
	public LayerMask layerMask;
    Ray ray;
    RaycastHit hit;
    LayerMask raycastPlane;

    float clicktime;
    bool characterDisabled;

	Vector3 previousPos = Vector3.zero;
	Vector3 deltaPos = Vector3.zero;

	private void Start()
	{
		StartCoroutine(Send());
	}

	private void OnDestroy()
	{
		StopAllCoroutines();
	}

	void CamControl()
	{
		deltaPos = target.position - previousPos;
		deltaPos.y = 0;
		cam.transform.position = Vector3.Lerp(cam.transform.position, cam.transform.position + deltaPos, Time.time);
		previousPos = target.position;
	}
	
	void Update()
	{
		if (characterDisabled||!isLoaded)
			return;

		CamControl();

		bool click = false;

		if (UnityEngine.Input.GetMouseButtonDown(0))
		{
			clicktime = Time.time;
		}
		if (UnityEngine.Input.GetMouseButtonUp(0))
		{
			if (Time.time - clicktime < 0.15f)
			{	
				click = true;
			}
		}

		if (click)
		{
			ray = cam.ScreenPointToRay(UnityEngine.Input.mousePosition);

			if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
			{
				dest = hit.point;
			}
		}
	}

	IEnumerator Send()
	{
		while (true)
		{
			if (character && (dest - character.position).magnitude > 0.5)
			{
				float movementAngle = -1 * Vector2.SignedAngle(dest.ToVector2xz() - character.position.ToVector2xz(), Vector2.right);

				CM.Send((movementAngle > 0 ? movementAngle : 360 + movementAngle) / 180 * (float)Math.PI);
			}
			else
			{
				CM.Send(0, false);
			}

			yield return new WaitForSeconds(0.05f);
		}
	}

}
