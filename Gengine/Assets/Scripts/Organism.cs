using UnityEngine;
using System.Collections;

public class Organism : MonoBehaviour
{
	public Gene mommaGene;
	public Gene pappaGene;

	public Gene spriteGene;
	// Use this for initialization
	void Start ()
	{
		spriteGene = Gene.cross(mommaGene, pappaGene);
		GetComponent<SpriteRenderer>().sprite = (Sprite)spriteGene.firstAllele;
	}

	// Update is called once per frame
	void Update ()
	{

	}
}
