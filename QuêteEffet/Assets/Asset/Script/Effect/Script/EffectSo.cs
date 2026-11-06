using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "EffectSo", menuName = "Scriptable Objects/EffectSo")]
[ExecuteInEditMode]
public class EffectSo : ScriptableObject
{
    public string EffectName;
    public int damage = 0;
    public float damageDuration = 0;
    public float delayBeforeEffectReactivation = 0;
    public float slowModifier = 0;
    public float slowModifierDuration = 0;
    public float jumpModifier = 0;
    public float jumpModifierDuration = 0;

    public struct EffectsStruct
    {
        public string EffectName;
        public int damage;
        public float damageDuration;
        public float delayBeforeEffectReactivation;
        public float slowModifier;
        public float slowModifierDuration;
        public float jumpModifier;
        public float jumpModifierDuration;
    }

    EffectsStruct effectsStruct = new EffectsStruct();


    private void OnValidate()
    {
        SetData();
    }
    private void Awake()
    {
        SetData();
    }

    [ContextMenu("testEffect")]
    private void Test()
    {
        Debug.Log(this.GetComponentInParent<GameObject>().name);
        EffectDispatcher.instance.SetEffect(effectsStruct, this.GetComponentInParent<GameObject>(), this.GetComponentInParent<GameObject>());
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(this.GetComponentInParent<GameObject>().name);
        EffectDispatcher.instance.SetEffect(effectsStruct,this.GetComponentInParent<GameObject>(),collision.gameObject);
    }

    private void SetData()
    {
        effectsStruct.EffectName = EffectName;
        effectsStruct.damage = damage;
        effectsStruct.damageDuration = damageDuration;
        effectsStruct.delayBeforeEffectReactivation = delayBeforeEffectReactivation;
        effectsStruct.slowModifier = slowModifier;
        effectsStruct.slowModifierDuration = slowModifierDuration;
        effectsStruct.jumpModifier = jumpModifier;
        effectsStruct.jumpModifierDuration = jumpModifierDuration;
    }
}
