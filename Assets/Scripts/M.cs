using System;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class M
{
    private String _name;
    private Dictionary<String, Object> _args = new Dictionary<string, object>();

    public M(String name)
    {
        _name = "MH_" + name;
    }

    public static M showSlot(String slotName)
    {
        M message = new M("ShowSlot");
        message.AddArg("slotName", slotName);
        return message;
    }

    public static M showStrip(String stripName)
    {
        M mesage = new M("ShowStrip");
        mesage.AddArg("stripName", stripName);
        return mesage;
    }
    
    public static M startRain()
    {
        M mesage = new M("StartRain");
        return mesage;
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

