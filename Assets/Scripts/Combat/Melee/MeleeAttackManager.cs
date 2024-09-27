using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MeleeAttackManager : MonoBehaviour
{
    public static MeleeAttackManager instance; void Awake() { instance = this; }

    public bool inCombat;

    [SerializeField]
    private List<GameObject> attackFabs;
    [SerializeField]
    private List<GameObject> attackPos;
    [SerializeField]
    private List<string> animSetBools;
    [SerializeField]
    private List<int> attackAnimTimes;
    [SerializeField]
    private List<int> attackWindowTimes;
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private List<bool> attackAnims;
    [SerializeField]
    private List<bool> attackWindows;
    [SerializeField]
    private List<GameObject> attackHits;

    void Start()
    {
        attackAnims = new List<bool> {false, false, false};
        attackWindows = new List<bool> {false, false, false};
        attackHits = new List<GameObject> {null, null, null};

        inCombat = false;
    }

    private async void Attack(int attackNum) {
        inCombat = true;

        Debug.Log("Performing attack " + attackNum);
        attackHits[attackNum] = Instantiate(attackFabs[attackNum], attackPos[attackNum].transform.position, attackPos[attackNum].transform.rotation);
        attackAnims[attackNum] = true;
        anim.SetBool(animSetBools[attackNum], true);

        await Task.Delay(attackAnimTimes[attackNum]);
        attackWindows[attackNum] = true;
        await Task.Delay(attackWindowTimes[attackNum]);

        Destroy(attackHits[attackNum]);
        attackWindows[attackNum] = false;
        attackAnims[attackNum] = false;
        anim.SetBool(animSetBools[attackNum], false);

        await Task.Delay(3000);
        Debug.Log("Turned off combat");
        inCombat = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            if (!attackAnims.Contains(true)) {
                Attack(0);
            } else
            {
                for (int i = 1; i < attackWindows.Count; i++) {
                    if (attackWindows[i - 1] && !attackAnims[i]) {
                        Attack(i);
                    }
                }
            }
        }
    }
}
