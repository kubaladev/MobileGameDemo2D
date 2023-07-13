using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScreenAdjuster : MonoBehaviour
{
	Vector2 resolution;
	public UnityEvent OnScreenChanged;
	private void Awake()
	{
		resolution = new Vector2(Screen.width, Screen.height);
	}

	private void Update()
	{
		if (resolution.x != Screen.width || resolution.y != Screen.height)
		{ 
			resolution.x = Screen.width;
			resolution.y = Screen.height;
			OnScreenChanged?.Invoke();
		}

	}
}
