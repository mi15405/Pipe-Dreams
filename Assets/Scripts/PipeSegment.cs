using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSegment : MonoBehaviour {

	[SerializeField]
	private Transform end;
	public Transform End
	{ 
		get { return end; } 
		set { end = value; } 
	}

}
