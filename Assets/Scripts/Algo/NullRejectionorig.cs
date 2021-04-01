using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TP5.Algo
{
	public class NullRejectionorig
	{
		#region Members
		protected List<float> interDistances = new List<float>();
		protected float threshold;
		#endregion

		#region Public methods
		public void Train(IList<Classifier.Gesture> gestures)
		{
			// TODO
		}

		public void AddNullClass(List<Classifier.Prediction> data, float factor)
		{
			if(data.Count > 0)
			{
				// TODO
			}
		}
		#endregion
	}
}
