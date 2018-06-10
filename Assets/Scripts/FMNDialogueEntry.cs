using System;
using System.Collections.Generic;
using MonoBehaviour;
using UnityEngine;
using UnityEngine.Events;
using Object = System.Object;

public abstract class FMNDialogueEntry
{
    private FMNDialogueEntry()
    {
        
    }

    public static FMNDialogueEntry Make(String content, FMNMethodMessage onFinish)
    {
        return new SimpleMessage(content, onFinish);
    }

    public static FMNDialogueEntry Make(String firstChoice, FMNMethodMessage onFirstChoice, String secondChoice,
        FMNMethodMessage onSecondChoice)
    {
        return new Choice(firstChoice, onFirstChoice, secondChoice, onSecondChoice);
    }

    public abstract void InitScene(GameObject sceneContainer);
    
    private class SimpleMessage : FMNDialogueEntry
    {
        private String _content;
        private FMNMethodMessage _onFinish;
        private GameObject _sceneContainer;

        public SimpleMessage(String content, FMNMethodMessage onFinish)
        {
            _content = content;
            _onFinish = onFinish;
        }

        public override void InitScene(GameObject sceneContainer)
        {
            _sceneContainer = sceneContainer;
            Dictionary<String, Object> args = new Dictionary<string, object>();
            args.Add("layout", Layout.Speach);
            args.Add("content", _content);
            args.Add("onFinish", (UnityAction) OnFinish);
            sceneContainer.SendMessage("MH_SetLayout", args);
        }

        public void OnFinish()
        {
            if(_onFinish != null)
                _onFinish.Call(_sceneContainer);
        }
    }
    
    private class Choice : FMNDialogueEntry
    {
        private GameObject _sceneContainer;
        
        private String _firstChoice;
        private FMNMethodMessage _onFirstChoice;
        
        private String _secondChoice;
        private FMNMethodMessage _onSecondChoice;
        
        public Choice(String firstChoice, FMNMethodMessage onFirstChoice, String secondCHoice,
            FMNMethodMessage onSecondChoice)
        {
            _firstChoice = firstChoice;
            _onFirstChoice = onFirstChoice;
            _secondChoice = secondCHoice;
            _onSecondChoice = onSecondChoice;
        }
        
        public override void InitScene(GameObject sceneContainer)
        {
            _sceneContainer = sceneContainer;
            Dictionary<String, Object> args = new Dictionary<string, object>();
            args.Add("layout", Layout.Speach);
            args.Add("bChoice1", _firstChoice);
            args.Add("onFirstChoice", (UnityAction) OnFirstChoice);
            args.Add("bChoice2", _secondChoice);
            args.Add("onSecondChoice", (UnityAction) OnSecondChoice);
            sceneContainer.SendMessage("MH_SetLayout", args);
        }

        public void OnFirstChoice()
        {
            if(_onFirstChoice != null)
                _onFirstChoice.Call(_sceneContainer);
        }

        public void OnSecondChoice()
        {
            if(_onSecondChoice != null)
                _onSecondChoice.Call(_sceneContainer);
        }
    }
}
