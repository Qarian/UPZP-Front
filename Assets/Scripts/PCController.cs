﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;

public class PCController : MonoBehaviour
{
    public GameObject character;
    public Transform target;
    public AbstractMap map;
    public GameObject rayPlane;
	public Camera cam;
	public Mock YOURSERVER;
	LayerMask layerMask;
    Ray ray;
    RaycastHit hit;
    LayerMask raycastPlane;

    float clicktime;
    bool characterDisabled;

	Vector3 previousPos = Vector3.zero;
	Vector3 deltaPos = Vector3.zero;
	void CamControl()
	{
		deltaPos = target.position - previousPos;
		deltaPos.y = 0;
		cam.transform.position = Vector3.Lerp(cam.transform.position, cam.transform.position + deltaPos, Time.time);
		previousPos = target.position;
	}
	void Update()
	{
		if (characterDisabled)
			return;

		CamControl();

		bool click = false;

		if (Input.GetMouseButtonDown(0))
		{
			clicktime = Time.time;
		}
		if (Input.GetMouseButtonUp(0))
		{
			if (Time.time - clicktime < 0.15f)
			{
				click = true;
			}
		}

		if (click)
		{
			ray = cam.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
			{
				target.position = hit.point;
				float movementVector = Vector2.Angle( target.position.ToVector2xz(), transform.position.ToVector2xz());
				YOURSERVER.Send(movementVector);
			}
		}
	}
}