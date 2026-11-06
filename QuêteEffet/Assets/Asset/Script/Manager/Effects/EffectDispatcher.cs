using System;
using UnityEngine;

public class EffectDispatcher : MonoBehaviour
{
    private static EffectDispatcher effectDispatcher;

    public static EffectDispatcher instance => effectDispatcher;

    public Array[] effectHistory = new Array[10];
    private int arrayIndex = 0;


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

    public void SetEffect(EffectSo.EffectsStruct effectStruct,GameObject effectOwner,GameObject playerTouch)
    {
        SetEffectHistory(effectStruct, effectOwner, playerTouch);
        SetEffectToPlayer(effectStruct, playerTouch.GetComponent<EffectHandler>());
    }
    private void SetEffectHistory(EffectSo.EffectsStruct effectStruct, GameObject effectOwner, GameObject playerTouch)
    {
        string stringHistory = effectOwner.name + "has inflicted" + effectStruct.EffectName + "to" + playerTouch.name;
        effectHistory.SetValue(stringHistory, arrayIndex);
        arrayIndex += 1;
        if (arrayIndex >= effectHistory.LongLength) arrayIndex = 0;
    }
    private void SetEffectToPlayer(EffectSo.EffectsStruct effectStruct,EffectHandler playerTouchByEffect)
    {
        playerTouchByEffect.AddToList(effectStruct);
    }

    public void ReadEffectHistory()
    {
        for (int i = 0; i < effectHistory.Length; i++)
        {
            Debug.Log(effectHistory[i]);
        }
    }
}
