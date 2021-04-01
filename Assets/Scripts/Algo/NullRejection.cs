using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TP5.Algo
{
	public class NullRejection
	{
		//T = min{DTW(i, j)}, pour tout i et j de l’ensemble d’apprentissage tel que i ≠j
		// DTW(x, null) = α.min{abs(T –DTW(x, i))}, pour tout i de l’ensemble d’apprentissage

		#region Members
		protected List<float> interDistances = new List<float>();
		protected float threshold;
		protected List<float> thresholds = new List<float>();
		#endregion

		#region Public methods
		public void Train(IList<Classifier.Gesture> gestures)
		{
			// TODO
			float c = gestures.Count;
			if (c > 0)
			{

				interDistances.Clear();
				for (int i = 0; i < c-1; i++)
				{
					for (int j = i+1; j < c; j++) {
						interDistances.Add(DTW.Distance(gestures[i].frames, gestures[j].frames));
					}
				}
				if (interDistances.Count > 0)
                {
					threshold = interDistances.Min();
                }
			}
		}

		public void AddNullClass(List<Classifier.Prediction> data, float factor)
		{
			int c = data.Count;
			if(c > 0)
			{
				// TODO
				List<float> dists = new List<float>();
				foreach (Classifier.Prediction p in data)
				{
					dists.Add(Mathf.Abs(p.distance - threshold));
				}
				if (dists.Count > 0)
				{
					data.Add(new Classifier.Prediction(factor * dists.Min()));
				}
				Softmax.Normalize(data);
			}
		}
		#endregion
	}
}
