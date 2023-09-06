
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class M_GameManager : MonoBehaviour
{
    string monsterTag = "Monster";

    public GameObject beast;
    public GameObject driller;
    public GameObject diver;
    public GameObject ticker;
    public GameObject flyer;
    public GameObject worm;
    public GameObject shifter;
    public GameObject bolter;

    public Transform domeCenter;

    string mBeast = "Beast";
    string mDriller = "Driller";
    string mDiver = "Diver";
    string mTicker = "Ticker";
    string mWorm = "Worm";
    string mShifter = "Shifter";
    string mBolter = "Bolter";
    string mFlyer = "Flyer";

    public float x = 0;

    public float waveTime;
    public float waveTimer;
    public int wave = 1;
    public float waveSpawnTime;
    public float spawnDuration;

    Image waveDisabled;
    Image waveEnabled;

    public bool spawnMonster = false;

    public UnityEngine.UI.Slider slider;


    private void Awake()
    {
        waveDisabled = GetComponent<Image>();
        waveEnabled = GetComponent<Image>();

        waveEnabled = GameObject.Find("on").GetComponent<Image>();
        waveDisabled = GameObject.Find("off").GetComponent<Image>();
    }
    private void Start()
    {
        int monsterCount = CountWithTag(monsterTag);
        Debug.Log(" 몬스터 숫자 : " + monsterCount);

        waveTime = 10 + wave * 5;
        waveTimer = waveTime;
        spawnDuration = 6;


        Make(mDiver); Make(mDiver); Make(mDiver); Make(mDiver); Make(mDiver); Make(mDiver);


        waveEnabled.enabled = false;
        waveDisabled.enabled = true;

        Debug.Log("MyImage is: " + waveEnabled);
        Debug.Log("MyImage is: " + waveDisabled);

    }

    private void Update()
    {
        slider.value = waveTimer / waveTime;


        // 웨이브때 실행
        if (spawnMonster)
        {

            x += Time.deltaTime;

            if (x > spawnDuration)
            {
                Spawn(wave);
                int monsterCount = CountWithTag(monsterTag);
                Debug.Log(" 몬스터 숫자 : " + monsterCount);
            }

        }


        if (waveTimer > 0)
        {
            waveTimer -= Time.deltaTime;
        }


        // 웨이브 시작
        if (waveTimer <= 0 && !spawnMonster)
        {
            spawnDuration = 6;
            StartCoroutine(WaveAlam());
            spawnMonster = !spawnMonster;

        }

        if (spawnMonster)
        {
            waveSpawnTime += Time.deltaTime;
        }

        // 웨이브 끝남
        if (waveTimer < 0 && waveSpawnTime > waveTime / 2 && CountWithTag(monsterTag) == 0) // 웨이브 지속시간 끝, 몬스터 전부 처리, 타이머 0일떄
        {

            waveEnabled.enabled = false;
            waveDisabled.enabled = true;

            spawnMonster = false;
            wave++;
            waveTime = 10 + wave * 5;
            if (waveTime > 60)
            {
                waveTime = 60;
            }

            waveTimer = waveTime;
            waveSpawnTime = 0;
            x = 0;
        }
        else if (waveSpawnTime > waveTime / 2)
        {
            spawnDuration = 12;
        }
    }

    IEnumerator WaveAlam()
    {

        waveEnabled.enabled = true;
        waveDisabled.enabled = false;
        yield return new WaitForSeconds(0.2f);
        waveEnabled.enabled = false;
        waveDisabled.enabled = true;
        yield return new WaitForSeconds(0.8f);

        waveEnabled.enabled = true;
        waveDisabled.enabled = false;
        yield return new WaitForSeconds(0.2f);
        waveEnabled.enabled = false;
        waveDisabled.enabled = true;
        yield return new WaitForSeconds(0.8f);

        waveEnabled.enabled = true;
        waveDisabled.enabled = false;
        yield return new WaitForSeconds(0.2f);
        waveEnabled.enabled = false;
        waveDisabled.enabled = true;
        yield return new WaitForSeconds(0.8f);

        waveEnabled.enabled = true;
        waveDisabled.enabled = false;
        Spawn(wave);

    }



    private int CountWithTag(string tag)
    {
        GameObject[] tagNum = GameObject.FindGameObjectsWithTag(tag);
        return tagNum.Length;
    }

    void Make(string name)
    {
        Vector2 pos;
        int toggle = (int)((Random.Range(0, 2) - 0.5f) * 2);
        float diverX;


        switch (name)
        {
            case "Beast":
                pos = new Vector2(25 * toggle, Random.Range(-7f + domeCenter.position.x, -9f + (domeCenter.position.y + 9.6f))); ;
                Instantiate(beast, pos, Quaternion.identity);
                break;

            case "Bolter":
                pos = new Vector2(25 * toggle, Random.Range(-2f + domeCenter.position.x, 3f + (domeCenter.position.y + 9.6f)));
                Instantiate(bolter, pos, Quaternion.identity);
                break;

            case "Diver":
                diverX = Random.Range(0f + domeCenter.position.x, 40f + (domeCenter.position.y + 9.6f));
                if (diverX < 15f) pos = new Vector2(27 * toggle, diverX);
                else pos = new Vector2((diverX - 15) * toggle, 15);
                Instantiate(diver, pos, Quaternion.identity);
                break;

            case "Driller":
                pos = new Vector2(25 * toggle, Random.Range(-7f + domeCenter.position.x, -8f + (domeCenter.position.y + 9.6f)));
                Instantiate(driller, pos, Quaternion.identity);
                break;

            case "Flyer":
                diverX = Random.Range(0f + domeCenter.position.x, 40f + (domeCenter.position.y + 9.6f));
                if (diverX < 15f) pos = new Vector2(27 * toggle, diverX);
                else pos = new Vector2((diverX - 15) * toggle, 15);
                Instantiate(flyer, pos, Quaternion.identity);
                break;

            case "Shifter":
                pos = new Vector2(25 * toggle, Random.Range(-7f + domeCenter.position.x, -8f + (domeCenter.position.y + 9.6f)));
                Instantiate(shifter, pos, Quaternion.identity);
                break;

            case "Ticker":
                for (int i = 0; i < Random.Range(11, 26); i++)
                {
                    pos = new Vector2(Random.Range(25f + domeCenter.position.x, 28f + (domeCenter.position.y + 9.6f)) * toggle, Random.Range(-8f + domeCenter.position.x, -10f + (domeCenter.position.y + 9.6f)));
                    Instantiate(ticker, pos, Quaternion.identity);
                }
                break;

            case "Worm":
                pos = new Vector2(Random.Range(10f + domeCenter.position.x, 18f + (domeCenter.position.y + 9.6f)) * toggle, Random.Range(-7f + domeCenter.position.x, -8f + (domeCenter.position.y + 9.6f)));
                Instantiate(worm, pos, Quaternion.identity);
                break;
        }
    }
    void Spawn(int x)
    {
        switch (x)
        {
            case 1:
                x = 2;
                break;
            case 2:
                x = 3;
                break;
            case 3:
                x = 5;
                break;
            case 4:
                x = 6;
                break;
            default:
                x = 8;
                break;
        }

        int y;

        for (int i = 0; i < Random.Range(1,x+1); i++)
        {
            y = Random.Range(1, x + 1);

            switch (y)
            {
                case 1:
                    Make(mTicker);
                    break;
                case 2:
                    Make(mBeast);
                    break;
                case 3:
                    Make(mFlyer);
                    break;
                case 4:
                    Make(mShifter);
                    break;
                case 5:
                    Make(mWorm);
                    break;
                case 6:
                    Make(mDiver);
                    break;
                case 7:
                    Make(mDriller);
                    break;
                case 8:
                    Make(mBolter);
                    break;

            }
        }
        this.x = 0;
    }

    
}
