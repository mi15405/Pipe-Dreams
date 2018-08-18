using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {

	[SerializeField]
	private List<PipeSegment> segmentPrefabs;  // Lista segmenata koji se generisu

	[SerializeField]
	private int numberOfSegments;   // Broj konstantno aktivnih segmenata

	[SerializeField]
	private float moveSpeed;   		// Brzina kretanja cevi (igraca)

	[SerializeField]
	private Transform cameraPivot;   // Tacka za koju se vezuje kamera

	[SerializeField]
	private float cameraDistance;    // Udaljenost kamere od cameraPivot-a

	[SerializeField]
	private List<GameObject> objectsToSpawn;

	private List<PipeSegment> segments;   // Segmenti cevi

	private Vector3 translateDirection;   // Smer translacije cele cevi

	private void Start()
	{
		segments = new List<PipeSegment>();

		// Dodaju se pocetni segmenti
		for (int i = 0; i < numberOfSegments; i++)	
			AddRandomSegment();

		// Azurira se smer translacije cevi
		UpdateTranslateDirection();
	}

	private void UpdateTranslateDirection()
	{
		// Smer translacije je od kraja (End) prve cevi do globalnog koordinatnog pocetka
		translateDirection = -segments[0].End.position.normalized;

		/* 
		 * Pozicija kamere je pomerena u odnosu na globalni koordinatni pocekat u pravcu translacije,
		 * na zadatom rastojanju cameraDistance
		 */
		cameraPivot.position = translateDirection * cameraDistance;
	}

	private void Update()
	{
		// Translira se cela cev
		transform.Translate(translateDirection * moveSpeed * Time.deltaTime, Space.World);
	}
	
	private void AddSegment(PipeSegment segment)
	{
		// Segment se instancira kao dete cele cevi (PipeRoot)
		var seg = Instantiate(segment, transform);

		// Generisu se objekti unutar cevi
		seg.SpawnObjects(objectsToSpawn);

		/* 
		 * Segment se postavlja na lokalni koordinatni pocetak ukoliko je prvi u nizu,
		 * inace se postavlja na End poziciju poslednje cevi u nizu
		 */
		if (segments.Count == 0)
			seg.transform.position = transform.position;
		else 
			seg.transform.position = segments[segments.Count - 1].End.position;

		// Random rotacija cevi oko pravca pruzanja. Postize se utisak skretanja u random smer, ukoliko je kosa cev
		seg.transform.Rotate(new Vector3(0f, Random.Range(0, 360), 0f));

		// Dodaje se instancirani segment 
		segments.Add(seg);
	}

	private void AddRandomSegment()
	{
		// Dodaje se random segment iz liste prefab-a
		AddSegment(segmentPrefabs[Random.Range(0, segmentPrefabs.Count)]);
	}

	public void RemoveSegment()
	{
		// Uklanja se prvi segment
		segments.RemoveAt(0);

		// Azurira se smer translacije
		UpdateTranslateDirection();

		// Dodaje se novi segment na kraj cevi
		AddRandomSegment();
	}

}
