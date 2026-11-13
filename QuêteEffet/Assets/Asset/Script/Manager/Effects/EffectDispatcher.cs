using System;
using System.Collections.Generic;
using UnityEngine;

public class EffectDispatcher : MonoBehaviour
{
    private static EffectDispatcher effectDispatcher;

    public static EffectDispatcher instance => effectDispatcher;

    private List<string> effectHistory;
    public int HistoryMaxLength = 0;


    void Awake()
    {
        if (effectDispatcher)
        {
            Destroy(this);
        }
        else
        {
            effectDispatcher = this;
        }
    }

    public void Start()
    {
        effectHistory = new();
    }

    public void SetEffect(EffectSo.EffectsStruct effectStruct,GameObject effectOwner,GameObject playerTouch)
    {
        SetEffectHistory(effectStruct.EffectName, effectOwner, playerTouch);
        SetEffectToPlayer(effectStruct, playerTouch.GetComponent<EffectHandler>());
    }
    private void SetEffectHistory(string effectName, GameObject effectOwner, GameObject playerTouch)
    {
        effectHistory.Add(effectOwner.name + "has inflicted" + effectName + "to" + playerTouch.name);
        if (effectHistory.Count >= HistoryMaxLength) effectHistory.RemoveAt(0);
    }
    private void SetEffectToPlayer(EffectSo.EffectsStruct effectStruct,EffectHandler playerTouchByEffect)
    {
        playerTouchByEffect.AddToList(effectStruct);
    }

    public void ReadEffectHistory()
    {
        for (int i = 0; i <= effectHistory.Count-1; i++)
        {
            Debug.Log(effectHistory[i]);
        }
    }

    public List<string> GetEffectHistory()
    {
        return effectHistory;
    }
}
