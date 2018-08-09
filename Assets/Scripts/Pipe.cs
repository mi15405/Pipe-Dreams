using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {

	[SerializeField]
	private List<PipeSegment> segmentPrefabs;

	[SerializeField]
	private int numberOfSegments;

	[SerializeField]
	private float moveSpeed;

	[SerializeField]
	private Transform cameraPivot;

	[SerializeField]
	private float cameraDistance;

	private List<PipeSegment> segments; 

	private Vector3 translateDirection;

	private void Start()
	{
		segments = new List<PipeSegment>();

		for (int i = 0; i < numberOfSegments; i++)	
			AddSegment(segmentPrefabs[Random.Range(0, segmentPrefabs.Count)]);

		UpdateTranslateDirection();
	}

	private void UpdateTranslateDirection()
	{
		translateDirection = (segments[0].transform.position - segments[1].transform.position).normalized;
		cameraPivot.position = translateDirection * cameraDistance;
	}

	private void Update()
	{
		transform.Translate(translateDirection * moveSpeed * Time.deltaTime, Space.World);

		if (segments.Count < numberOfSegments)
			AddSegment(segmentPrefabs[Random.Range(0, segmentPrefabs.Count)]);
	}
	
	private void AddSegment(PipeSegment segment)
	{
		var seg = Instantiate(segment, transform);

		if (segments.Count == 0)
			seg.transform.position = transform.position;
		else 
			seg.transform.position = segments[segments.Count - 1].End.position;

		seg.transform.Rotate(new Vector3(0f, Random.Range(0, 360), 0f));
		segments.Add(seg);
	}

	public void RemoveSegment()
	{
		segments.RemoveAt(0);
		UpdateTranslateDirection();
	}

}
