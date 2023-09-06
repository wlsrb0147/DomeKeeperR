using UnityEngine;

public class Dome : MonoBehaviour
{
    #region
    [Header("µ¼")]

    [SerializeField] float MaxHp;
    [SerializeField] public float CurHp;
    [SerializeField] public float Def;
    [SerializeField] float trueatk;

    public GameObject Damaged;
    public GameObject DestroyDome;
    [Header("µ¼ ½¯µå")]
    [SerializeField] bool isShield = false;
    SpriteRenderer SI;
    SpriteRenderer Dd;
    public GameObject ShieldIg;
    [SerializeField] public float Shield;
    [SerializeField] float RespawnTime;
    [SerializeField] float CoolTimer;

    [Header("°Ë")]
    [SerializeField] float Atk;

    #endregion

    private void Start()
    {
        SI = ShieldIg.GetComponent<SpriteRenderer>();
        Dd = Damaged.GetComponent<SpriteRenderer>();
        MaxHp = CurHp;
        CoolTimer = 29f;
    }

    private void Update()
    {
        if (SkillTreeManager.Instance.isShield == true)
        {
            if (!isShield)
            {
                CoolTimer += Time.deltaTime;
            }
            if (CoolTimer > RespawnTime)
            {

                Shield = 100f;
                isShield = true;
                SI.enabled = true;
                CoolTimer = 0f;

            }

        }
    }

    void SetHeal(int heal)
    {
        CurHp += heal;
        if (CurHp > MaxHp)
        {
            CurHp = MaxHp;
        }

    }
    public void SetDamage(float atk)
    {
        if (!isShield)
        {
            trueatk = atk - Def;
            if (trueatk <= 0)
            {
                trueatk = 0;
            }

            CurHp -= trueatk;

            if (CurHp < MaxHp / 2)
            {
                Dd.enabled = true;
            }
            else

                Dd.enabled = false;
            if (CurHp < 0)
            {
                DestroyDome.SetActive(true);
                //¾î¶»°Ô Ã³¸®ÇÒ°ÇÁö ¸ð¸§ ? 
            }
        }
        else if (isShield)
        {

            trueatk = atk - Def;
            if (trueatk <= 0)
            {
                trueatk = 0;
            }
            Shield -= trueatk;
            if (Shield < 0)
            {
                Shield = 0f;
                SI.enabled = false;
                isShield = false;
            }
        }
    }


}
