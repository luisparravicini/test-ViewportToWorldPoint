using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
		public Vector2 position;
		public GUIText posLabel;
		public GUIText awakeLabel;
		public GUIText startLabel;
		public bool frameDelay = true;
		public bool arbitraryDelay = false;

		void Start ()
		{
				ViewportPos ("start", startLabel);
		}

		void Awake ()
		{
				StartCoroutine(CoDelayedAwake());
		}

		void DelayedAwake()
		{
				posLabel.text = "pos: " + position;
				ViewportPos ("awake", awakeLabel);
		}

		IEnumerator CoDelayedAwake()
		{
				if (frameDelay)
						yield return null;	 // One frame delay
				else if (arbitraryDelay)
						yield return new WaitForSeconds(0.25f); // Arbitrary delay

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
