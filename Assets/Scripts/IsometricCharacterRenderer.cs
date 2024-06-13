using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricCharacterRenderer : MonoBehaviour
{
    public static readonly string[] staticDirections = { "Stay U", "Stay D", "Stay L", "Stay R" };
    public static readonly string[] runDirections = { "Walk U", "Walk D", "Walk L", "Walk R" };

    Animator animator;
    int lastDirection;

	private void Awake()
	{
		animator = GetComponent<Animator>();	
	}

	public void SetDirection(Vector2 direction)
	{

		string[] directionArray = null;

		if (direction.magnitude < .01f)
		{
			directionArray = staticDirections;

		}
		else
		{

			directionArray = runDirections;
			lastDirection = DirectionToIndex(direction, 8);
		}

		animator.Play(lastDirection);

	}


	public static int DirectionToIndex(Vector2 direction, int sliceCount)
	{

		Vector2 normDir = direction.normalized;

		float step = 360f / sliceCount;

		float halfstep = step / 2;

		float angle = Vector2.SignedAngle(Vector2.up, normDir);

		angle += halfstep;

		if (angle < 0)
		{
			angle += 360;
		}

		float stepCount = angle / step;

		return Mathf.FloorToInt(stepCount);


	}



}
