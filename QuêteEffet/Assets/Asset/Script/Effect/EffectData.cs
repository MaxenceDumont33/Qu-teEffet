using System.Collections.Generic;
using UnityEngine;
using static EffectSo;

public class EffectData : MonoBehaviour
{
    EffectSo.EffectsStruct effectData = new();

    public GameObject owner;

    public int effectIndex;
    public List<EffectSo> listOfEffect;

    [ContextMenu("testEffect")]
    private void Test()
    {
        Debug.Log(gameObject.name);
        EffectDispatcher.instance.SetEffect(listOfEffect[effectIndex].GetEffectData(), owner, owner);
    }

    [ContextMenu("SetEffectData")]
    private void SetEffectData()
    {
        effectData = listOfEffect[effectIndex].GetEffectData();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            GameObject playerTouch = collision.gameObject;
            EffectDispatcher.instance.SetEffect(listOfEffect[effectIndex].GetEffectData(), owner, playerTouch);
        }
    }
}
