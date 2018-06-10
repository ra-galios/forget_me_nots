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

		private Transform _transform;
		private Layout _current = Layout.UDEF;

	    void Start()
	    {
		    _transform = GetComponent<Transform>();
		    
		    Dictionary<String, Object> args1 = new Dictionary<string, object>();
		    args1.Add("slotName", "Slot2");
		    
		    Dictionary<String, Object> args2 = new Dictionary<string, object>();
		    args2.Add("slotName", "Slot3");
		    
		    FMNDialogueEntry e2 = FMNDialogueEntry.Make("Text 23", new FMNMethodMessage("ShowSlot", args1), "Text 24", new FMNMethodMessage("ShowSlot", args2));
		   
		    Dictionary<String, Object> args = new Dictionary<string, object>();
		    args.Add("slotName", "Slot1");
		    FMNDialogueEntry entry = FMNDialogueEntry.Make(e2, "Text 1", new FMNMethodMessage("ShowSlot", args));
		    entry.InitScene(gameObject);
	    }

		public void MH_SetLayout(Dictionary<String, Object> args)
		{
			Layout layout = (Layout) args["layout"];
			if (_current != layout)
			{
				switch (layout)
				{
					case Layout.Speach:
						SpeachLayout.SetActive(true);
						ChoiceLayout.SetActive(false);
						Transform speach = SpeachLayout.transform.Find("Speach");
						speach.GetComponent<Text>().text = (string) args["content"];
						
						Transform button = SpeachLayout.transform.Find("BNext");
						button.GetComponent<Button>().onClick.AddListener((UnityAction) args["onFinish"]);
						break;
					case Layout.Choice:
						ChoiceLayout.SetActive(true);
						SpeachLayout.SetActive(false);
						Transform bChoice1 = ChoiceLayout.transform.Find("BChoice1");
						bChoice1.GetChild(1).GetComponent<Text>().text = (string) args["bChoice1"];
						bChoice1.GetComponent<Button>().onClick.AddListener((UnityAction) args["onFirstChoice"]);
						
						Transform bChoice2 = ChoiceLayout.transform.Find("BChoice2");
						bChoice2.GetChild(1).GetComponent<Text>().text = (string) args["bChoice2"];
						bChoice2.GetComponent<Button>().onClick.AddListener((UnityAction) args["onSecondChoice"]);
						break;
				}

				_current = layout;
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
	}

	public enum Layout
	{
		Choice, Speach, UDEF
	}
}
