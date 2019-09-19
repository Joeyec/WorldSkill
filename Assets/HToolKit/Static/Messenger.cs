using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public delegate void CallBack();
public delegate void CallBack<T>(T t);
public delegate void CallBack<T, D>(T t, D d);
public delegate void CallBack<T, D, U>(T t, D d, U u);

public class Messenger
{
    public static Dictionary<MessengerEventType, Delegate> eventTable = new Dictionary<MessengerEventType, Delegate>();

    #region AddListener

    static void OnListenerAdding(MessengerEventType eventkey, Delegate listenerDelegate)
    {
        if (!eventTable.ContainsKey(eventkey))
        {
            eventTable.Add(eventkey, null);
        }
    }

    public static void AddListener(MessengerEventType eventtype, CallBack handler)
    {
        OnListenerAdding(eventtype, handler);
        eventTable[eventtype] = (eventTable[eventtype] as CallBack) + (handler);
    }

    public static void AddListener<T>(MessengerEventType eventtype, CallBack<T> handler)
    {
        OnListenerAdding(eventtype, handler);
        eventTable[eventtype] = (eventTable[eventtype] as CallBack<T>) + (handler);
    }

    public static void AddListener<T, D>(MessengerEventType eventtype, CallBack<T, D> handler)
    {
        OnListenerAdding(eventtype, handler);
        eventTable[eventtype] = (eventTable[eventtype] as CallBack<T, D>) + (handler);
    }

    public static void AddListener<T, D, U>(MessengerEventType eventtype, CallBack<T, D, U> handler)
    {
        OnListenerAdding(eventtype, handler);
        eventTable[eventtype] = (eventTable[eventtype] as CallBack<T, D, U>) + (handler);
    }
    
    #endregion

    #region RemveListener

    static public void OnListenerRemoving(MessengerEventType eventType, Delegate listenerBeingRemoved)
    {
        if (eventTable.ContainsKey(eventType))
        {
            Delegate d = eventTable[eventType];

            if (d == null)
            {
                throw new ListenerException(string.Format("Attempting to remove listener with for event type \"{0}\" but current listener is null.", eventType));
            }
            else if (d.GetType() != listenerBeingRemoved.GetType())
            {
                throw new ListenerException(string.Format("Attempting to remove listener with inconsistent signature for event type {0}. Current listeners have type {1} and listener being removed has type {2}", eventType, d.GetType().Name, listenerBeingRemoved.GetType().Name));
            }
        }
        else
        {
            //throw new ListenerException(string.Format("Attempting to remove listener for type \"{0}\" but Messenger doesn't know about this event type.", eventType));
        }
    }

    static public void OnListenerRemoved(MessengerEventType eventType)
    {
        if (eventTable[eventType] == null)
        {
            eventTable.Remove(eventType);
        }
    }

    static public void RemoveListener(MessengerEventType eventType, CallBack handler)
    {
        OnListenerRemoving(eventType, handler);
        eventTable[eventType] = (CallBack)eventTable[eventType] - handler;
        OnListenerRemoved(eventType);
    }

    static public void RemoveListener<T>(MessengerEventType eventType, CallBack<T> handler)
    {
        OnListenerRemoving(eventType, handler);
        eventTable[eventType] = (CallBack<T>)eventTable[eventType] - handler;
        OnListenerRemoved(eventType);
    }

    static public void RemoveListener<T, D>(MessengerEventType eventType, CallBack<T, D> handler)
    {
        OnListenerRemoving(eventType, handler);
        eventTable[eventType] = (CallBack<T, D>)eventTable[eventType] - handler;
        OnListenerRemoved(eventType);
    }

    static public void RemoveListener<T, D, U>(MessengerEventType eventType, CallBack<T, D, U> handler)
    {
        OnListenerRemoving(eventType, handler);
        eventTable[eventType] = (CallBack<T, D, U>)eventTable[eventType] - handler;
        OnListenerRemoved(eventType);
    }

    #endregion

    #region BroadCase
    static void OnBroadcast(MessengerEventType eventtype)
    {
        if (!eventTable.ContainsKey(eventtype))
        {
            throw new ListenerException("不包含此监听");
        }
    }
    public static void Broadcast(MessengerEventType eventtype)
    {
        OnBroadcast(eventtype);
        CallBack callback;
        if (eventTable.ContainsKey(eventtype))
        {
            callback = eventTable[eventtype] as CallBack;
            callback();//如果不为空调用，unity2017以下不可简写
        }
    }
    public static void Broadcast<T>(MessengerEventType eventtype, T t)
    {
        OnBroadcast(eventtype);
        CallBack<T> callback;
        if (eventTable.ContainsKey(eventtype))
        {
            callback = eventTable[eventtype] as CallBack<T>;
            if (null != callback)
            {
                callback(t);//如果不为空调用，unity2017以下不可简写
            }
        }
    }
    public static void Broadcast<T, D>(MessengerEventType eventtype, T t, D d)
    {
        OnBroadcast(eventtype);
        CallBack<T, D> callback;
        if (eventTable.ContainsKey(eventtype))
        {
            callback = eventTable[eventtype] as CallBack<T, D>;
            if (null != callback)
            {
                callback(t, d);//如果不为空调用，unity2017以下不可简写
            }
        }
    }
    public static void Broadcast<T, D, U>(MessengerEventType eventtype, T t, D d, U u)
    {
        CallBack<T, D, U> callback;
        if (eventTable.ContainsKey(eventtype))
        {
            callback = eventTable[eventtype] as CallBack<T, D, U>;
            if (null != callback)
            {
                callback(t, d, u); //如果不为空调用，unity2017以下不可简写
            }
        }
    }
    #endregion

}

public class ListenerException : Exception
{
    public ListenerException(string msg)
        : base(msg)
    {
    }
}
