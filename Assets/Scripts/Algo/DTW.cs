using System.Collections.Generic;
using UnityEngine;

namespace TP5.Algo
{
	public class DTW
	{
		public static float Distance(IList<Classifier.Frame> gesture, IList<Classifier.Frame> data)
		{
			float shortest_distance = float.MaxValue;

			if (gesture == null || data == null)
			{
				return shortest_distance;
			}
			if (gesture.Count == 0 || data.Count == 0)
            {
				return shortest_distance;
			}
			// TODO
			int x = gesture.Count;
			int y = data.Count;
			float[,] DTW = new float[x, y];

			for (int i = 0; i < x; i++)
			{
				for (int j = 0; j < y; j++)
				{
					DTW[i, j] = shortest_distance;
					//zfzf
				}
			}

			DTW[0, 0] = FramesDistance(gesture[0], data[0]);
			for (int i = 1; i < x; i++)
			{
				float cost = FramesDistance(gesture[i], data[0]);
				DTW[i, 0] = cost + DTW[i - 1, 0];
			}

			for (int j = 1; j < y; j++)
			{
				float cost = FramesDistance(gesture[0], data[j]);
				DTW[0, j] = cost + DTW[0, j - 1];
			}

			for (int i = 1; i < x; i++)
			{
				for (int j = 1; j < y; j++)
				{
					float cost = FramesDistance(gesture[i], data[j]);
					DTW[i, j] = cost + Mathf.Min(DTW[i - 1, j], Mathf.Min(DTW[i, j - 1], DTW[i - 1, j - 1]));
				}
			}
			return DTW[x - 1, y - 1];
		}

		protected static float FramesDistance(Classifier.Frame f1, Classifier.Frame f2)
		{
			// TODO
			if (f1 == null || f2 == null)
			{
				return float.MaxValue;
			}

			return Vector3.SqrMagnitude(f1.thumb - f2.thumb) +
				Vector3.SqrMagnitude(f1.index - f2.index) +
				Vector3.SqrMagnitude(f1.middle - f2.middle) +
				Vector3.SqrMagnitude(f1.ring - f2.ring) +
				Vector3.SqrMagnitude(f1.pinky - f2.pinky);
		}
	}
}
