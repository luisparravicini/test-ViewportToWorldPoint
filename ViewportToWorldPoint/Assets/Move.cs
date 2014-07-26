using UnityEngine;

public class Move : MonoBehaviour
{
		public Vector2 position;
		public GUIText posLabel;
		public GUIText awakeLabel;
		public GUIText startLabel;

		void Start ()
		{
				ViewportPos ("start", startLabel);
		}

		void Awake ()
		{
				posLabel.text = "pos: " + position;
				ViewportPos ("awake", awakeLabel);
		}

		void ViewportPos (string label, GUIText guiText)
		{
				Vector2 pos = Camera.main.ViewportToWorldPoint (position);
				Debug.Log (string.Format ("[{0}] pos={1}", label, pos));
				guiText.text = string.Format ("{0}: {1}", label, pos);
		}
}
