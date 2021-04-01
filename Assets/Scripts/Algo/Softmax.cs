using System.Collections.Generic;
using UnityEngine;

namespace TP5.Algo
{
	public class Softmax
	{
		public static void Normalize(List<Classifier.Prediction> data, float b = 1)
		{
			if(data != null)
			{
				// TODO
				float sum = 0;
				foreach (Classifier.Prediction p in data)
                {
					sum += Mathf.Exp(-b * p.distance);
                }

				foreach (Classifier.Prediction p in data)
				{
					p.probability = Mathf.Exp(-b * p.distance)/sum;
				}
			}
		}
	}
}
