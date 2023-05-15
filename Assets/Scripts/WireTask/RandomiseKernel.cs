using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomiseKernel : MonoBehaviour
{
	[SerializeField] private Vector3[] positions;
	private int index;
	private void Start()
	{
		index = Random.Range(0,3);
		transform.position = positions[index];	
	}

	private void Update()
	{
		
	}
}