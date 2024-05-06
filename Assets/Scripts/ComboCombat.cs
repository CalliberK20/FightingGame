using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class Combo
{
    [HideInInspector]
    public string comboName;

    public List<KeyCode> sequence = new List<KeyCode>();
    public string functionName;
    public float animationDelay = 0.5f;
}

public abstract class ComboCombat : MonoBehaviour
{
    public KeyCode downKey;
    public KeyCode upKey;
    public KeyCode leftKey;
    public KeyCode rightKey;
    [Space]
    public KeyCode key1;
    public KeyCode key2;
    public KeyCode key3;
    public KeyCode key4;
    [Space]
    public bool onAttack = false;
    public bool onProcess = false;
    public float inputKeyProcess = 0.1f;


    public Combo matchedCombo;
    public List<KeyCode> inputedKeys = new List<KeyCode>();
    [Space]
    public List<Combo> combos = new List<Combo>();

    private float timeInputProcess = 0;

    private float attackTimeProcess = 0;
    private float attackTime;

    [HideInInspector]
    public Rigidbody rb;

    private void OnValidate()
    {
        foreach(Combo combo in combos)
        {
            string comboName = "";
            for (int i = 0; i < combo.sequence.Count; i++)
            {
                comboName += combo.sequence[i].ToString() + ", ";
            }
            combo.comboName = comboName;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onAttack)
        {
            attackTimeProcess += Time.deltaTime;
            if (attackTimeProcess >= attackTime)
                onAttack = false;
            return;
        }

        if (Input.GetKeyDown(downKey))
        {
            CheckKeys(downKey);
        }
        if (Input.GetKeyDown(upKey))
        {
            CheckKeys(upKey);
        }
        if (Input.GetKeyDown(leftKey))
        {
            CheckKeys(leftKey);
        }
        if (Input.GetKeyDown(rightKey))
        {
            CheckKeys(rightKey);
        }

        if (Input.GetKeyDown(key1))
        {
            CheckKeys(key1);
        }
        if (Input.GetKeyDown(key2))
        {
            CheckKeys(key2);
        }
        if (Input.GetKeyDown(key3))
        {
            CheckKeys(key3);
        }
        if (Input.GetKeyDown(key4))
        {
            CheckKeys(key4);
        }

        if (onProcess)
        {
            timeInputProcess += Time.deltaTime;
            if (timeInputProcess >= inputKeyProcess)
                StartAnim();
        }
    }

    void CheckKeys(KeyCode key)
    {
        inputedKeys.Add(key);
        if (!onProcess)
            timeInputProcess = 0;
        onProcess = true;
    }

    private void StartAnim()
    {
        bool match = false;
        Combo matchedCombo = null;
        for (int i = 0; i < combos.Count; i++)
        {
            if (combos[i].sequence.Count == inputedKeys.Count)
                for (int j = 0; j < combos[i].sequence.Count; j++)
                {
                    if (inputedKeys[j] == combos[i].sequence[j])
                        match = true;
                }

            if(match)
            {
                matchedCombo = combos[i];
                attackTimeProcess = 0;
                this.matchedCombo = matchedCombo;
                attackTime = matchedCombo.animationDelay;
                Attack(matchedCombo.functionName);
                onAttack = true;
                break;
            }
        }

        inputedKeys.Clear();
        onProcess = false;
    }

    public abstract void Attack(string function);
}
