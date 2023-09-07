
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class M_GameManager : MonoBehaviour
{
    public static M_GameManager instance = null;

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


    public int wave = 1;
    public float defaultWT = 10;
    public float increasingWT = 5;
    public float maxWaveTime = 60;

    public float waveTime;
    public float waveTimer;
    
    public float respawnTimer = 0;
    public float initialspawnDuration = 6;
    public float spawnDuration;
    public float waveContinued;

    Image waveDisabled;
    Image waveEnabled;

    public bool spawnMonster = false;

    public UnityEngine.UI.Slider slider;

    public int killedMonster = 0;

    public bool killmonster = false;
    public bool stopWave= false;
    public bool nextWave = false;
    public bool healDome = false;
    public bool immortableDome = false;
    public bool destroyDome = false;

    public float redtotal = 0;
    public float greentotal = 0;
    public float bluetotal = 0;


    public Text winlose;
    public Text jemDescription;
    public Text scroeDescription;
    public GameObject ending;
    public float playtime;

    public float domehp;
    public float stunTime = 50;
    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        waveDisabled = GetComponent<Image>();
        waveEnabled = GetComponent<Image>();

        waveEnabled = GameObject.Find("on").GetComponent<Image>();
        waveDisabled = GameObject.Find("off").GetComponent<Image>();
        ending.SetActive(false);
        stopWave = false;
    }
    private void Start()
    {
        int monsterCount = CountWithTag(monsterTag); // 몬스터 숫자 총합

        waveTime = defaultWT + (wave-1) * increasingWT;
        waveTimer = waveTime;
        spawnDuration = initialspawnDuration ;


      //  Make(mDiver); Make(mDiver); Make(mDiver); Make(mDiver); Make(mDiver); Make(mDiver);


        waveEnabled.enabled = false;
        waveDisabled.enabled = true;


    }

    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            killmonster = !killmonster;
            StartCoroutine(Setfalse());
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            stopWave = !stopWave;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            nextWave = !nextWave;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            healDome = !healDome;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            immortableDome = !immortableDome;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            destroyDome = !destroyDome;
        }



        if (nextWave)
        {
            nextWave = !nextWave;
            wave++;
            initialspawnDuration = initialspawnDuration - wave * 0.5f;
            if(initialspawnDuration < 2)
            {
                initialspawnDuration = 2;
            }
            waveTimer = waveTime;
        }



        slider.value = waveTimer / waveTime;


        if (!stopWave)
        {



            // 웨이브때 실행
            if (spawnMonster)
            {
                respawnTimer += Time.deltaTime;

                if (respawnTimer > spawnDuration)
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
                waveTimer = 0;
                spawnDuration = initialspawnDuration;
                StartCoroutine(WaveAlam());
                spawnMonster = !spawnMonster;

            }

            if (spawnMonster)
            {
                waveContinued += Time.deltaTime;
            }

            // 웨이브 끝남
            if (waveTimer <= 0 && waveContinued > waveTime / 2 && CountWithTag(monsterTag) == 0) // 웨이브 지속시간 끝, 몬스터 전부 처리, 타이머 0일떄
            {

                waveEnabled.enabled = false;
                waveDisabled.enabled = true;

                spawnMonster = false;
                wave++;
                waveTime = defaultWT + (wave - 1) * increasingWT;
                if (waveTime > maxWaveTime)
                {
                    waveTime = maxWaveTime;
                }

                waveTimer = waveTime;
                waveContinued = 0;
                respawnTimer = 0;
            }
            else if (waveContinued > waveTime * 2 / 3)
            {
                spawnDuration = initialspawnDuration * 2;
            }
            else if (waveContinued > waveTime * 4 / 3)
            {
                spawnDuration = initialspawnDuration * 4;
            }
        }


        if(wave >= 11)
        {
            EndingScene();
        }
    }
    IEnumerator Setfalse()
    {
        yield return new WaitForSeconds(0.1f);
        killmonster = !killmonster;
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
        Spawn((int)wave);

    }


    public void EndingScene()
    {
        killmonster = true;
        ending.SetActive(true);

        if (wave >= 11) winlose.text = "돔을 지켜냈습니다";
        else    winlose.text = "돔이 파괴되었습니다";


        string str;
        if (wave >= 11)
        {
            str = "클리어";
        }
        else
        {
            str = wave.ToString();
        }


        jemDescription.text = $"레드 스톤 : {redtotal} \n그린 스톤 : {greentotal} \n블루 스톤 : {bluetotal} ";
        
        scroeDescription.text = $"총 플레이 시간 : {(int)playtime/60}분 {(int)playtime%60}초\n최종 웨이브 : {str}\n죽인 몬스터 수 : {killedMonster}";

 
        stopWave = true;
        StartCoroutine(Setfalse());
        

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
        int z = x ;
        switch (z)
        {
            case 1:
                z = 2;
                break;
            case 2:
                z = 3;
                break;
            case 3:
                z = 5;
                break;
            case 4:
                z = 6;
                break;
            default:
                z = 8;
                break;
        }
        
        int y;

        for (int i = 0; i < Random.Range(2+(int)(z/2),z+4); i++)
        {
            Debug.Log(x);
            y = Random.Range(1, x + 3);
            Debug.Log(y);
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
        this.respawnTimer = 0;
    }

    
}
