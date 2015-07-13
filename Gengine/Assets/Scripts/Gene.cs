﻿using UnityEngine;
using System.Collections;

[CreateAssetMenuAttribute]
public class Gene : ScriptableObject
{

		public static System.Random random;

		public string type;
		public Object firstAllele;
		public Dominance firstDominance;
		public Object secondAllele;
		public Dominance secondDominance;

		public enum Dominance
		{
				Recessive = 0,
				Dominant = 1,
				Codominant = 2
		};

		public Gene(string geneType, Object all1, Dominance dom1, Object all2, Dominance dom2)
		{
			this.type = geneType;
			this.firstAllele = all1;
			this.secondAllele = all2;
			this.firstDominance = dom1;
			this.secondDominance = dom2;
		}

		public static Gene cross(Gene g1, Gene g2)
		{
			if (g1.type != g2.type)
			{
				Debug.Log("Genes don't match up!");
				return null; //Error: Names don't match
			}

			//TODO: When you make a game controller, put it there so we get real, reliable results
			random = new System.Random();

			int randomNumber = random.Next(1, 5);
			Gene offspring;

			if (randomNumber == 1)
					if (g1.firstDominance >= g2.firstDominance)
							offspring = new Gene(g1.type, g1.firstAllele, g1.firstDominance, g2.firstAllele, g2.firstDominance);
					else
							offspring = new Gene(g1.type, g2.firstAllele, g2.firstDominance, g1.firstAllele, g1.firstDominance);

			else if (randomNumber == 2)
					if (g1.firstDominance >= g2.secondDominance)
							offspring = new Gene(g1.type, g1.firstAllele, g1.firstDominance, g2.secondAllele, g2.secondDominance);
					else
							offspring = new Gene(g1.type, g2.secondAllele, g2.secondDominance, g1.firstAllele, g1.firstDominance);

			else if (randomNumber == 3)
					if (g1.secondDominance >= g2.firstDominance)
							offspring = new Gene(g1.type, g1.secondAllele, g1.secondDominance, g2.firstAllele, g2.firstDominance);
					else
							offspring = new Gene(g1.type, g2.firstAllele, g2.firstDominance, g1.secondAllele, g1.secondDominance);

			else
					if (g1.secondDominance >= g2.secondDominance)
							offspring = new Gene(g1.type, g1.secondAllele, g1.secondDominance, g2.secondAllele, g2.secondDominance);
					else
							offspring = new Gene(g1.type, g2.secondAllele, g2.secondDominance, g1.secondAllele, g1.secondDominance);

			return offspring;
		}

}
