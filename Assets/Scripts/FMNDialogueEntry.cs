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

    public static FMNDialogueEntry Make(FMNDialogueEntry next, String content, FMNMethodMessage onFinish)
    {
        return new SimpleMessage(next, content, onFinish);
    }

    public static FMNDialogueEntry Make(String firstChoice, FMNMethodMessage onFirstChoice, String secondChoice,
        FMNMethodMessage onSecondChoice)
    {
        return new Choice(firstChoice, null, onFirstChoice, secondChoice, null, onSecondChoice);
    }

    public abstract void InitScene(GameObject sceneContainer);
    
    private class SimpleMessage : FMNDialogueEntry
    {
        private String _content;
        private FMNMethodMessage _onFinish;
        private GameObject _sceneContainer;
        private FMNDialogueEntry _next;

        public SimpleMessage(FMNDialogueEntry next, String content, FMNMethodMessage onFinish)
        {
            _next = next;
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
            
            if(_next != null)
                _next.InitScene(_sceneContainer);
        }
    }
    
    private class Choice : FMNDialogueEntry
    {
        private GameObject _sceneContainer;

        private FMNDialogueEntry _nextFirst;
        private String _firstChoice;
        private FMNMethodMessage _onFirstChoice;
        
        private FMNDialogueEntry _nextSecond;
        private String _secondChoice;
        private FMNMethodMessage _onSecondChoice;
        
        public Choice(String firstChoice, FMNDialogueEntry nextFirst, FMNMethodMessage onFirstChoice, String secondCHoice,
            FMNDialogueEntry nextSecond, FMNMethodMessage onSecondChoice)
        {
            _firstChoice = firstChoice;
            _nextFirst = nextFirst;
            _onFirstChoice = onFirstChoice;
            _secondChoice = secondCHoice;
            _nextSecond = nextSecond;
            _onSecondChoice = onSecondChoice;
        }
        
        public override void InitScene(GameObject sceneContainer)
        {
            _sceneContainer = sceneContainer;
            Dictionary<String, Object> args = new Dictionary<string, object>();
            args.Add("layout", Layout.Choice);
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
            
            if(_nextFirst != null)
                _nextFirst.InitScene(_sceneContainer);
                
        }

        public void OnSecondChoice()
        {
            if(_onSecondChoice != null)
                _onSecondChoice.Call(_sceneContainer);
            
            if(_nextSecond != null)
                _nextSecond.InitScene(_sceneContainer);
        }
    }
}
