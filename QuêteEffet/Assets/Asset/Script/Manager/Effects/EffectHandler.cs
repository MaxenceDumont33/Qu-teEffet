using System.Collections.Generic;
using UnityEngine;

public class EffectHandler : MonoBehaviour
{
    private List<savedStruct> effectList = new List<savedStruct>() ;
    public PlayerStats ownerStat;
    struct savedStruct {
        public string EffectName;
        public int    damage;
        public float damageDuration;
        public float delayBeforeEffectReactivation;
        public float delayBeforeEffectReactivationSave;
        public float slowModifier;
        public float slowModifierDuration;
        public bool slowModifierRemove;
        public float jumpModifier;
        public float jumpModifierDuration;
        public bool jumpModifierRemove;
        public float effectDuration;
        public bool stun;
        public float stunDuration;
        public bool stunRemove;
        public float startTime;
    }
    private int numberOfStun = 0;
    private float targetTimeSecond = 1;
    private float targetTimeMillisecond = 1;
    private int seconde = 0;
    private float milliseconds = 0;

    private void Update()
    {
        targetTimeSecond -= Time.deltaTime;
        targetTimeMillisecond -= Time.deltaTime*10;
        if (targetTimeMillisecond <= 0)
        {
            targetTimeMillisecond = 1;
            milliseconds += 1;
            ReadAndApplyEffect();
            if (milliseconds >=10)
                milliseconds = 0;
        }
        if (targetTimeSecond <= 0)
        {
            targetTimeSecond = 1;
            seconde += 1;
            ReduceEffectDuration();
        }
    }

    public void AddToList(EffectSo.EffectsStruct effectStruct)
    {
        savedStruct effectData = SetSavedStruct(effectStruct);
        ownerStat.SetSpeedModifier(effectData.slowModifier);
        ownerStat.SetJumpModifier(effectData.jumpModifier);
        if(effectData.stun == true)
        {
            ownerStat.LockMovement();
            numberOfStun++;
        }
        effectList.Add(effectData);
    }
    private void DeleteFromList(int index)
    {
        effectList.RemoveAt(index);
        Debug.Log("removeFromList");
    }

    private void ApplyEffects(savedStruct effectData)
    {
        Debug.Log("ApplyEffect");
        ownerStat.TakeDamage(effectData.damage);
    }

    private savedStruct SetSavedStruct(EffectSo.EffectsStruct effectStruct)
    {
        savedStruct effectData = new ();
        effectData.EffectName =effectStruct.EffectName;
        effectData.damage = effectStruct.damage;
        effectData.damageDuration = effectStruct.damageDuration;
        effectData.delayBeforeEffectReactivation = effectStruct.delayBeforeEffectReactivation;
        effectData.delayBeforeEffectReactivationSave = effectStruct.delayBeforeEffectReactivation;
        effectData.slowModifier = effectStruct.slowModifier;
        effectData.slowModifierDuration = effectStruct.slowModifierDuration;
        effectData.slowModifierRemove = false;
        effectData.jumpModifier = effectStruct.jumpModifier;
        effectData.jumpModifierDuration = effectStruct.jumpModifierDuration;
        effectData.jumpModifierRemove = false;
        effectData.effectDuration = Mathf.Max(effectStruct.damageDuration,effectStruct.jumpModifierDuration,effectStruct.slowModifierDuration,effectStruct.StunDuration);
        effectData.stun = effectStruct.Stun;
        effectData.stunDuration = effectStruct.StunDuration;
        effectData.stunRemove = false;
        effectData.startTime = milliseconds;
        return effectData;
    }        
    
    private void ReduceEffectDuration()
    {
        for (int i = 0; i < effectList.Count; i++)
        {
            savedStruct copyStruct = effectList[i];
            copyStruct.effectDuration -= 1;
            copyStruct.damageDuration -= 1;
            copyStruct.delayBeforeEffectReactivation -= 1;
            copyStruct.slowModifierDuration -= 1;
            copyStruct.jumpModifierDuration -= 1;
            copyStruct.stunDuration -= 1;
            effectList[i] = copyStruct;
            Debug.Log(effectList[i].effectDuration);
            if (effectList[i].effectDuration <= 0)
            {
                if (effectList[i].slowModifierRemove == false)
                    ownerStat.SetSpeedModifier(-effectList[i].slowModifier);
                if (effectList[i].jumpModifierRemove == false)
                    ownerStat.SetSpeedModifier(-effectList[i].jumpModifier);
                if (effectList[i].stunRemove == false)
                {
                    numberOfStun--;
                    if(numberOfStun <= 0)
                        ownerStat.UnLockMovement();
                }
                DeleteFromList(i);
                i =-  1;
            }
        }
    }

    private void ReadAndApplyEffect()
    {
        for(int i = 0;i < effectList.Count; i++)
        {
            if (effectList[i].startTime == milliseconds)
            {
                savedStruct copyStruct = effectList[i];
                if (effectList[i].delayBeforeEffectReactivation <= 0 && effectList[i].damageDuration > 0)
                {
                    Debug.Log("enter");
                    ApplyEffects(effectList[i]);
                    copyStruct.delayBeforeEffectReactivation = copyStruct.delayBeforeEffectReactivationSave;
                    effectList[i] = copyStruct;
                } 
                if (effectList[i].jumpModifierDuration <= 0 && effectList[i].jumpModifierRemove == false)
                {                   
                    copyStruct.jumpModifierRemove = true;
                    effectList[i] = copyStruct;
                    ownerStat.SetJumpModifier(effectList[i].jumpModifier *- 1);
                }
                if (effectList[i].slowModifierDuration <= 0 && effectList[i].slowModifierRemove == false)
                {
                    copyStruct.slowModifierRemove = true;
                    effectList[i] = copyStruct;
                    ownerStat.SetSpeedModifier(effectList[i].slowModifier *- 1);
                }
                if (effectList[i].stunDuration <= 0 && effectList[i].stunRemove == false)
                {
                    copyStruct.stunRemove = true;
                    effectList[i] = copyStruct;
                    numberOfStun--;
                    if (numberOfStun <= 0)
                        ownerStat.UnLockMovement();
                }
            }
        }
    }
}                  
                   
                   
                   
                   
                   