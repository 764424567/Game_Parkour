using UnityEngine;

public class Control_Player : MonoBehaviour
{
    //前进速度
    public float m_ForwardSpeeed = 7.0f;
    //动画组件
    private Animator m_Anim;
    //动画现在状态
    private AnimatorStateInfo m_CurrentBaseState;

    //动画状态参照
    static int m_jumpState = Animator.StringToHash("Base Layer.jump");
    static int m_slideState = Animator.StringToHash("Base Layer.slide");

    //场景控制对象
    Control_Scenes m_ControlScenes;

    //游戏结束
    bool m_IsEnd = false;

    // Use this for initialization
    void Start()
    {
        m_Anim = GetComponent<Animator>();
        m_ControlScenes = GameObject.Find("Control_Scenes").GetComponent<Control_Scenes>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * m_ForwardSpeeed * Time.deltaTime;
        m_CurrentBaseState = m_Anim.GetCurrentAnimatorStateInfo(0);
        if (Input.GetKeyDown(KeyCode.W))
        {
            m_Anim.SetBool("jump", true);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            m_Anim.SetBool("slide", true);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Change_PlayerZ(true);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Change_PlayerZ(false);
        }
        if (m_CurrentBaseState.fullPathHash == m_jumpState)
        {
            m_Anim.SetBool("jump", false);
        }
        else if (m_CurrentBaseState.fullPathHash == m_slideState)
        {
            m_Anim.SetBool("slide", false);
        }
    }

    public void Change_PlayerZ(bool IsAD)
    {
        if (IsAD)
        {
            if (transform.position.z == -14.7f)
                return;
            else if (transform.position.z == -9.69f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -14.7f);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -9.69f);
            }
        }
        else
        {
            if (transform.position.z == -6.2f)
                return;
            else if (transform.position.z == -9.69f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -6.2f);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -9.69f);
            }

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Vehicle_DumpTruck" || other.gameObject.name == "Vehicle_MixerTruck")
        {
            m_IsEnd = true;
            m_ForwardSpeeed = 0;
            m_Anim.SetBool("idle", true);
        }
        if (other.gameObject.name == "MonitorPos0")
        {
            m_ControlScenes.Change_Road(0);
        }
        else if (other.gameObject.name == "MonitorPos1")
        {
            m_ControlScenes.Change_Road(1);
        }
        else if (other.gameObject.name == "MonitorPos2")
        {
            m_ControlScenes.Change_Road(2);
        }
    }

    void OnGUI()
    {
        if (m_IsEnd)
        {
            GUIStyle style = new GUIStyle();
            style.alignment = TextAnchor.MiddleCenter;
            style.fontSize = 40;
            style.normal.textColor = Color.red;
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "你输了~", style);
        }
    }
}
