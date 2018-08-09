using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentChangeOnExit : MonoBehaviour {

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Pipe"))
		{
			other.GetComponentInParent<Pipe>().RemoveSegment();
		}
	}
}
