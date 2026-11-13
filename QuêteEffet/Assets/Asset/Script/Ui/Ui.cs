using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    public List<EffectSo> listOfEffect;
    private List<GameObject> effectButton;

    [SerializeField]
    private GameObject buttonHolder;
    [SerializeField]
    private GameObject effectOption;
    [SerializeField]
    private GameObject createEffect;
    [SerializeField]
    private GameObject playerUi;

    public TMP_InputField effectName;
    public TMP_InputField damage;
    public TMP_InputField damageDuration;
    public TMP_InputField delayBeforeEffectReactivation;
    public TMP_InputField slowModifier;
    public TMP_InputField slowModifierDuration;
    public TMP_InputField jumpModifier;
    public TMP_InputField jumpModifierDuration;
    List<TMP_InputField> listOfText;

    public TMP_Dropdown playerSelectionDropdown;
    public List<GameObject> playerList;

    [ContextMenu("test button")]
    public void SetButton()
    {
        
        if (listOfEffect.Count!= effectButton.Count)
        {
            effectButton.Clear();

            for( int i = 0; i <=listOfEffect.Count-1; i++)
            {
               GameObject newButton = DefaultControls.CreateButton(new DefaultControls.Resources());
                newButton.transform.SetParent(buttonHolder.transform);
                newButton.GetComponentInChildren <Text>().text = listOfEffect[i].name;
                newButton.name = listOfEffect[i].name;
                newButton.GetComponent<Button>().onClick.AddListener(EffectButtonClick);
                effectButton.Add(newButton);
;            }
        }
    }

    private void Start()
    {
        effectButton = new();
        listOfText = new();
        SetTextList();
    }

    [ContextMenu("Destroy Button")]
    public void DestroyButton()
    {
        for(int i = 0;i <=effectButton.Count-1;i++)
        {
            Debug.Log("enter");
            GameObject ButtonObject = effectButton[i];
            effectButton.Remove(effectButton[i]);
            Destroy(ButtonObject);
            i--;
        }
    }

    private void UseEffect(int buttonNumber)
    {
        EffectDispatcher.instance.SetEffect(listOfEffect[buttonNumber].GetEffectData(), this.gameObject, playerList[playerSelectionDropdown.value]);
    }

    public void EffectButtonClick()
    {
       GameObject test = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;
       for(int i =0; i <= effectButton.Count-1; i++)
        {
            if (effectButton[i] == test)
            {
                UseEffect(i);
            }
        }
    }
    
    public void CreateNewEffect()
    {
        if (TestIfInputFieldEmpty())
        {
            EffectSo newEffect = ScriptableObject.CreateInstance<EffectSo>();
            newEffect.EffectName = effectName.text;
            newEffect.name = effectName.text;
            newEffect.damage = Convert.ToInt32(damage.text) ;
            newEffect.damageDuration = Convert.ToInt32(damageDuration.text);
            newEffect.delayBeforeEffectReactivation = Convert.ToInt32(delayBeforeEffectReactivation.text);
            newEffect.slowModifier = Convert.ToInt32(slowModifier.text);
            newEffect.slowModifierDuration = Convert.ToInt32(slowModifierDuration.text);
            newEffect.jumpModifier = Convert.ToInt32(jumpModifier.text);
            newEffect.jumpModifierDuration = Convert.ToInt32(jumpModifierDuration.text);
            listOfEffect.Add(newEffect);
            playerUi.SetActive(true);
            createEffect.SetActive(false);
            ResetTextValue();
        }
        else
            Debug.Log("erreur de code");
    }
    private bool TestIfInputFieldEmpty()
    {
        Debug.Log(listOfText.Count);
        for (int i = 0; i <= listOfText.Count -1; i++)
        {
            if (listOfText[i].text == string.Empty)
                return false;
        }
        return true;
    }
    private void SetTextList()
    {
        listOfText.Add(effectName);
        listOfText.Add(damage);
        listOfText.Add(damageDuration);
        listOfText.Add(delayBeforeEffectReactivation);
        listOfText.Add(slowModifier);
        listOfText.Add(slowModifierDuration);
        listOfText.Add(jumpModifier);
        listOfText.Add(jumpModifierDuration);
    }

    private void ResetTextValue()
    {
        for(int i = 0; i <=  listOfText.Count -1; i++)
        {
            listOfText[i].text = string.Empty;
        }
    }
}
