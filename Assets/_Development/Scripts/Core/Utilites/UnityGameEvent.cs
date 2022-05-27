using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityGameEvent
{
    public enum EventType { ScreenEvent, GameEvent }

    public EventType eventType;

    public UnityEvent OnScreenEnable;
    public UnityEvent OnScreenDisable;
    public UnityEvent OnGameStart;
}

[System.Serializable]
public class UnityScreenEvent
{
    public enum EventType { ScreenEvent }

    public EventType eventType;

    public UnityEvent OnScreenEnable;
    public UnityEvent OnScreenDisable;
}
