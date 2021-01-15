using System.Collections;
using System.Collections.Generic;
using UnityEngine;


	public class CharMovement : MonoBehaviour
	{
		public Material[] Materials;
		public Transform Target;
		public float Speed;


		void Update()
		{
			var distance = Vector3.Distance(transform.position, Target.position);
			if (distance > 0.1f)
			{
				transform.LookAt(Target.position);
				transform.position = Vector3.Lerp(transform.position,Target.position, Speed);

			}

		}
	}
