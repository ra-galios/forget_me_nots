using System;
using System.Collections.Generic;
using MonoBehaviour;
using UnityEngine;
using UnityEngine.Events;
using Object = System.Object;

public abstract class D
{
    private D()
    {

    }

    public static D Say(String phrase)
    {
        return new SimpleMessage(null, phrase, null);
    }

    public static D Say(String phrase, D next)
    {
        return new SimpleMessage(next, phrase, null);
    }

    public static D Say(String phrase, M onFinish)
    {
        return new SimpleMessage(null, phrase, onFinish);
    }

    public static D Say(String phrase, D next, M onFinish)
    {
        return new SimpleMessage(next, phrase, onFinish);
    }

    public static D Sequence(String[] repliques, D finaly)
    {
        D next = finaly;
        for (int i = repliques.Length - 1; i >= 0; i--)
        {
            String phrase = repliques[i];
            D dialog = Say(phrase, next);
            next = dialog;
        }

        return next;
    }
   

    public static D Choose(String firstChoice, D firstNext, String secondChoice, D secondNext)
    {
        return new Choice(firstChoice, firstNext, null, secondChoice, secondNext, null);
    }
    
    public static D Choose(String firstChoice, D firstNext, M onFirst, String secondChoice, D secondNext, M onSecond)
    {
        return new Choice(firstChoice, firstNext, onFirst, secondChoice, secondNext, onSecond);
    }

    public abstract void InitScene(GameObject sceneContainer);
    
    private class SimpleMessage : D
    {
        private String _content;
        private M _onFinish;
        private GameObject _sceneContainer;
        private D _next;

        public SimpleMessage(D next, String content, M onFinish)
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
    
    private class Choice : D
    {
        private GameObject _sceneContainer;

        private D _nextFirst;
        private String _firstChoice;
        private M _onFirstChoice;
        
        private D _nextSecond;
        private String _secondChoice;
        private M _onSecondChoice;
        
        public Choice(String firstChoice, D nextFirst, M onFirstChoice, String secondCHoice,
            D nextSecond, M onSecondChoice)
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
