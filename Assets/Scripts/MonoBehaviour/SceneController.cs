using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Object = System.Object;

namespace MonoBehaviour
{
	public class SceneController : UnityEngine.MonoBehaviour
	{
		public GameObject ChoiceLayout;
		public GameObject SpeachLayout;

		private Transform _transform;
		private Layout _current;

	    void Start()
	    {
		    _transform = GetComponent<Transform>();
	    }

		public void MH_SetLayout(Dictionary<String, Object> args)
		{
			Layout layout = (Layout) args["layout"];
			if (_current != layout)
			{
				switch (layout)
				{
					case Layout.Choice:
						SpeachLayout.SetActive(false);
						ChoiceLayout.SetActive(true);
						Transform speach = _transform.Find("Speach");
						speach.GetComponent<Text>().text = (string) args["content"];
						Transform button = _transform.Find("BNext");
						button.GetComponent<Button>().onClick.AddListener((UnityAction) args["onFinish"]);
						break;
					case Layout.Speach:
						ChoiceLayout.SetActive(false);
						SpeachLayout.SetActive(true);
						Transform bChoice1 = _transform.Find("BChoice1");
						bChoice1.GetComponent<Text>().text = (string) args["bChoice1"];
						bChoice1.GetComponent<Button>().onClick.AddListener((UnityAction) args["onFirstChoice"]);
						
						Transform bChoice2 = _transform.Find("BChoice2");
						bChoice2.GetComponent<Text>().text = (string) args["bChoice2"];
						bChoice2.GetComponent<Button>().onClick.AddListener((UnityAction) args["onSecondChoice"]);
						break;
				}

				_current = layout;
			}
		}
		
		public void MH_ShowSlot(Dictionary<String, Object> args)
		{
			Transform slot = _transform.Find((string) args["slotName"]);
			if (slot)
			{
				GameObject slotGO = slot.gameObject;
				slotGO.SendMessage("Show");
			}
		}
	}

	public enum Layout
	{
		Choice, Speach
	}
}
