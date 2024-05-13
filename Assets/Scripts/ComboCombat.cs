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
    public bool onBlock = false;
    //public bool onProcess = false;
    public bool onPress = false;
    [Space]
    public float timeInputProcess = 0;
    public float inputKeyProcess = 0.1f;

    private float holdPressProcess = 0;

    public Combo matchedCombo;
    public List<KeyCode> inputedKeys = new List<KeyCode>();
    [Space]
    public List<Combo> combos = new List<Combo>();


    private float attackTimeProcess = 0;
    private float attackTime;
    private PositionHandler positionHandler;

    private float flipPos = 1;


    [HideInInspector]
    public Rigidbody rb;

    private void OnValidate()
    {
        foreach (Combo combo in combos)
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
        positionHandler = GetComponent<PositionHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (onBlock)
        {
            return;
        }

        if (onAttack)
        {
            attackTimeProcess += Time.deltaTime;
            Debug.Log(attackTimeProcess);
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

        if (onPress)
        {
            timeInputProcess += Time.deltaTime;
            if (timeInputProcess >= inputKeyProcess)
                StartAnim();
        }
    }

    void CheckKeys(KeyCode key)
    {
        inputedKeys.Add(key);
        onPress = true && !onAttack;
        timeInputProcess = 0;
        /*        if (!onProcess)
                onProcess = true;*/
    }

    private void StartAnim()
    {
        //Combo matchedCombo = null;
        bool match;
        for (int i = 0; i < combos.Count; i++)
        {
            match = false;
            for (int j = 0; j < combos[i].sequence.Count && inputedKeys.Count == combos[i].sequence.Count; j++)
            {
                if (inputedKeys[j] == combos[i].sequence[j])
                    match = true;
                else
                {
                    match = false;
                    break;
                }
            }

            if (match)
            {
                Debug.Log("Match Found");
                matchedCombo = combos[i];
                attackTimeProcess = 0;
                matchedCombo = combos[i];
                attackTime = matchedCombo.animationDelay;
                Attack(matchedCombo.functionName);
                break;
            }
        }

        inputedKeys.Clear();
        onPress = false;
        //onProcess = false;
    }

    public abstract void Attack(string function);

    private IEnumerator Item1()
    {
        yield return null;
        Debug.Log("Item 1 is use");
    }

    private IEnumerator Item2()
    {
        yield return null;
        Debug.Log("Item 2 is use");
    }

    private IEnumerator Item3()
    {
        yield return null;
        Debug.Log("Item 3 is use");
    }

    private IEnumerator Item4()
    {
        yield return null;
        Debug.Log("Item 3 is use");
    }

    public void HitDamagable()
    {
        flipPos = positionHandler.isFlip ? -1f : 1f;
        Vector3 pos = transform.position + new Vector3(flipPos, 0.5f);

        //Collider2D[] collide = Physics2D.OverlapCircleAll(pos, 0.4f);

        Collider[] collide = Physics.OverlapSphere(pos, 0.4f);

        foreach(Collider collision in collide)
        {
            if(collision.gameObject.name != gameObject.name && collision.TryGetComponent(out Damagable damagable))
            {
                damagable.Damage(10);
                break;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + new Vector3(flipPos, 0.5f), 0.4f);
    }
}
