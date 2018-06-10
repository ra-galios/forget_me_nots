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
		public GameObject Strip;

		private Layout _current = Layout.UDEF;

	    void Start()
	    {
		    Dialog.DialogueEntry().InitScene(gameObject);
	    }

		public void MH_SetLayout(Dictionary<String, Object> args)
		{
			Layout layout = (Layout) args["layout"];
			switch (layout)
			{
				case Layout.Speach:
					SpeachLayout.SetActive(true);
					ChoiceLayout.SetActive(false);
					Transform speach = SpeachLayout.transform.Find("Speach");
					speach.GetComponent<Text>().text = (string) args["content"];
					
					Transform button = SpeachLayout.transform.Find("BNext");
					button.GetComponent<Button>().onClick.RemoveAllListeners();
					button.GetComponent<Button>().onClick.AddListener((UnityAction) args["onFinish"]);
					break;
				case Layout.Choice:
					ChoiceLayout.SetActive(true);
					SpeachLayout.SetActive(false);
					Transform bChoice1 = ChoiceLayout.transform.Find("BChoice1");
					bChoice1.GetChild(1).GetComponent<Text>().text = (string) args["bChoice1"];
					bChoice1.GetComponent<Button>().onClick.RemoveAllListeners();
					bChoice1.GetComponent<Button>().onClick.AddListener((UnityAction) args["onFirstChoice"]);
					
					Transform bChoice2 = ChoiceLayout.transform.Find("BChoice2");
					bChoice2.GetChild(1).GetComponent<Text>().text = (string) args["bChoice2"];
					bChoice2.GetComponent<Button>().onClick.RemoveAllListeners();
					bChoice2.GetComponent<Button>().onClick.AddListener((UnityAction) args["onSecondChoice"]);
					break;
			}
		}
		
		public void MH_ShowSlot(Dictionary<String, Object> args)
		{
			Transform slot = Strip.transform.Find((string) args["slotName"]);
			if (slot)
			{
				GameObject slotGO = slot.gameObject;
				slotGO.SendMessage("Show");
			}
		}
		
		public void MH_ShowStrip(Dictionary<String, Object> args)
		{
			Transform slot = Strip.transform.Find((string) args["slotName"]);
			if (slot)
			{
				GameObject slotGO = slot.gameObject;
				slotGO.SendMessage("Show");
			}
		}
		
		public void MH_Door(Dictionary<String, Object> args)
		{
			Transform slot = Strip.transform.Find((string) args["slotName"]);
			if (slot)
			{
				GameObject slotGO = slot.gameObject;
				slotGO.SendMessage("Show");
			}
		}
	}

	public enum Layout
	{
		Choice, Speach, UDEF
	}
}
