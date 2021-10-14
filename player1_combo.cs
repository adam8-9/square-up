using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public enum AttackType { kick=0,punch= 1 }
public class player1_combo : MonoBehaviour
{
    [Header("Inputs")]
    public KeyCode punch;
    public KeyCode kick;

    [Header("Attacks")]
    public Attack punch_Atk;
    public Attack kick_Atk;
    public List<Combo> combos;
    public float comboleeway = 0.2f;

    [Header("Components")]
    public Animator anim;

    Attack curAtttack = null;
    ComboInput last_Input = null;
    List<int> currentCombos = new List<int>();

    float timer = 0;
    float leeway = 0;
    bool skip = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        PrimeCombos();
    }

    void PrimeCombos()
    {
        for (int i = 0; i < combos.Count; i++)
        {
            Combo c = combos[i];
            c.onInput.AddListener(() =>
            {
                //Call atk function with combo attack
                skip = true;
                Attack(c.comboAttack);
                ResetCombos();

            });

        }
       
    }


    // Update is called once per frame
    void Update()
    {
        if (curAtttack != null)
        {
            if (timer > 0)
                timer -= Time.deltaTime;
            else
                curAtttack = null;

            return;
        }

        if (currentCombos.Count > 0)
        {
            leeway += Time.deltaTime;
            if (leeway >= comboleeway)
            {
                if (last_Input != null)
                {
                    Attack(getAttackFromType(last_Input.type));
                    last_Input = null;
                }
                ResetCombos();

            }
        }
        else
            leeway = 0;

            ComboInput input = null;
        if (Input.GetKeyDown(punch))
            input = new ComboInput(AttackType.punch);
        if (Input.GetKeyDown(kick))   
            input = new ComboInput(AttackType.kick);


        if (input == null) return;
        last_Input = input;



        List<int> remove = new List<int>();
        for (int i = 0; i < currentCombos.Count; i++)
        {
            Combo c = combos[currentCombos[i]];
            if (c.conCombo(input))
                leeway = 0;
            else
                remove.Add(i);
            
        }
        if (skip)
        {
            skip = false;
            return;
        }

        for (int i = 0; i < combos.Count; i++)
        {
            if (currentCombos.Contains(i)) continue;
            if (combos[i].conCombo(input))
            {
                currentCombos.Add(i);
                leeway = 0;
            }

        }


        foreach (int i in remove)
            currentCombos.Remove(i);

        if (currentCombos.Count <= 0)
            Attack(getAttackFromType(input.type));
    }
     void ResetCombos()
    {
        leeway = 0;
        for(int i = 0;  i < currentCombos.Count; i++)
        {
            Combo c = combos[currentCombos[i]];
            c.ResetCombo();
       }

        currentCombos.Clear();
    }
    void Attack(Attack att)
    {
        curAtttack = att;
        timer = att.length;
        anim.Play(att.name, -1, 0);
    }

    Attack getAttackFromType(AttackType t)
    {
        if (t == AttackType.kick)
            return kick_Atk;
        if (t == AttackType.punch)
            return punch_Atk;
        return null;
    }

}

    [System.Serializable]
    public class Attack
    {
        public string name;
        public float length;

    }

    [System.Serializable]
    public class ComboInput
    {
        public AttackType type;

        public ComboInput(AttackType t)
        {
            type = t;
        }

        public bool isSameAs(ComboInput test)
        {
            return (type == test.type);// add direction 
        }
    }

    [System.Serializable]
    public class Combo
    {
        public string name;
        public List<ComboInput> Inputs;
        public Attack comboAttack;
        public UnityEvent onInput;
        int curInput = 0;

        public bool conCombo (ComboInput i)
        {
            if (Inputs[curInput].isSameAs(i))
            {
                curInput++;
                if (curInput >= Inputs.Count)
                {
                    onInput.Invoke();
                    curInput = 0;

                }
                return true;
            }
            else
            {
                curInput = 0;
                return false;

            }
        }
        public ComboInput currentComboInput()
        {
            if (curInput >= Inputs.Count) return null;
            return Inputs[curInput];
        }
        public void ResetCombo()
        {
            curInput = 0;
        }






    }


   






 










