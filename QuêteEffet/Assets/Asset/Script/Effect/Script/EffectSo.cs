using UnityEngine;

[CreateAssetMenu(fileName = "EffectSo", menuName = "Scriptable Objects/EffectSo")]
[ExecuteInEditMode]
public class EffectSo : ScriptableObject
{
    public string EffectName;
    public int damage ;
    public float damageDuration;
    public float delayBeforeEffectReactivation;
    public float slowModifier;
    public float slowModifierDuration;
    public float jumpModifier;
    public float jumpModifierDuration;
    public bool stun = false;
    public float stunDuration;

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
        public bool Stun;
        public float StunDuration;
    }

    EffectsStruct effectsStruct = new EffectsStruct();


    public EffectsStruct GetEffectData()
    {
        return effectsStruct;
    }

    public void SetStruct(EffectSo value)
    {
        effectsStruct.EffectName = value.EffectName;
        effectsStruct.damage = value.damage;
        effectsStruct.damageDuration = value.damageDuration;
        effectsStruct.delayBeforeEffectReactivation = value.delayBeforeEffectReactivation;
        effectsStruct.slowModifier = value.slowModifier;
        effectsStruct.slowModifierDuration = value.slowModifierDuration;
        effectsStruct.jumpModifier = value.jumpModifier;
        effectsStruct.jumpModifierDuration = value.jumpModifierDuration;
        effectsStruct.Stun = value.stun;
        effectsStruct.StunDuration = value.stunDuration;
    }
}
