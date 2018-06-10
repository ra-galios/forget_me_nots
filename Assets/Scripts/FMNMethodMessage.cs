using System;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class FMNMethodMessage
{
    private String _name;
    private Dictionary<String, Object> _args = new Dictionary<string, object>();

    public FMNMethodMessage(String name, Dictionary<String, Object> args)
    {
        _name = "MH_" + name;
        foreach (var item in args)
        {
            _args.Add(item.Key, item.Value);
        }
    }

    public void Call(GameObject gameObject)
    {
        gameObject.SendMessage(_name, _args);
    }

    public void AddArg(String name, Object value)
    {
        _args.Add(name, value);
    }
}

