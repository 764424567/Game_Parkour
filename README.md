# Game_Parkour
 Unity开发跑酷游戏

## 一、前言
这篇文章就带着大家一步一步开发出来一个跑酷类的游戏，教程比较基础，适合大部分Unity开发的初学者。

## 二、效果图&下载链接
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109102238804.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
Github地址：https://github.com/764424567/Game_Parkour

## 三、教程
在教程开始之前，我们分析一下跑酷类游戏制作思路。
首先是道路和障碍物，我们可以先设置三段道路，然后障碍物随机生成
道路中间有抵达点，角色到达抵达点判断是否将后面的道路移动到前面接起来。
首先到达第一段的抵达点，肯定是不切换
到达第二段的抵达点，将1号路段移动到最前面
到达第三段的抵达点，将2号路段移动到最前面
循环往复，无穷尽也
然后是主角的移动脚本，躲避障碍物，移动位置固定三个点，可以跳，可以铲地
主角碰到障碍物就挂，游戏结束
### 一、新建项目
博主的Unity版本是Unity5.6.1f1，推荐大家使用我这个版本，或者其他的5.6.x版本，不然可能会出现各种各样奇奇怪怪的问题。
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109102415952.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
文件目录的话就按照我这个目录来，比较清晰明了。

### 二、导入资源
资源已经上传到Github，需要的可以下载
https://github.com/764424567/Unity-plugin/tree/master/Menu/Unity3D-ParkourDemoAssets
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109102658617.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109102707491.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109102723508.png)

### 三、处理动画资源
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109102754905.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
可以看到所有的动画文件都有。
接着我们就可以新建一个Animator Controller文件来管理动画文件。
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109102851294.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
命名随意。
![在这里插入图片描述](https://img-blog.csdnimg.cn/202001091028573.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
接着我们将动画剪辑拖到Animator处理面板中：
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109102904844.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
默认状态是run，然后有jump 、slide、idle
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200110124610382.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
接着就是“Take Transition”将run和jump  以及 run 、slide、idle连下线。

设置两个bool值，来控制动画的切换：
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200110124535674.png)
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200110124608200.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109103259134.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
接下来我们就可以在场景中看一下动画效果了：
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109103219253.gif)

### 四、处理路段模型
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109103356408.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
首先我们找到导入的资源SimpleRoadwork，里面有一个Demo场景，点进去可以看一下各类模型：
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109103500268.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
在Prefabs文件夹中，可以找到我们需要的各类模型，包括路面、路标、障碍物：
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109103440186.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
接下来，我们就设计一下路面：
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109103540901.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109103559696.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
接着摆放路标：
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109103609217.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
接着摆放障碍物：
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109103635757.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
因为障碍物我们要后期自动生成，现在就可以先隐藏起来。
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109103657293.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
然后设置到达点（到达点的目的是当角色到达这个位置的时候，自动切换路线）：
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109103747881.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
隐藏它的Mesh Renderer ，将BoxCollider IsTrigger设置成true：
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109103800721.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
路段就完成了：

![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109103850613.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
整个目录如下：
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109104005579.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
不会摆放也没有关系，我已经设置好了，用我的也行。

### 五、主角模型处理
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109104050478.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)

明显是有点大，我们给它同比例缩小一下：
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109104141838.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109104156343.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
接着设置一下摄像机的视角：

![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109104105642.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109104224945.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
### 六、生成障碍物
新建脚本Control_Scenes.cs
我们首先来生成障碍物：
```csharp
using UnityEngine;

public class Control_Scenes : MonoBehaviour
{
    public GameObject[] m_ObstacleArray;
    public Transform[] m_ObstaclePosArray;

    void Start()
    {
        Spawn_Obstacle(1);
    }
	
	//生成障碍物
	public void Spawn_Obstacle(int index)
    {
        //销毁原来的对象
        GameObject[] obsPast = GameObject.FindGameObjectsWithTag("Obstacle" + index);
        for (int i = 0; i < obsPast.Length; i++)
        {
            Destroy(obsPast[i]);
        }
        //生成障碍物
        foreach (Transform item in m_ObstaclePosArray[index])
        {
            GameObject prefab = m_ObstacleArray[Random.Range(0, m_ObstacleArray.Length)];
            Vector3 eulerAngle = new Vector3(0, Random.Range(0, 360), 0);
            GameObject obj = Instantiate(prefab, item.position, Quaternion.Euler(eulerAngle));
            obj.tag = "Obstacle" + index;
        }
    }
}

```
将脚本挂在Control_Scenes对象上：
将Prefab文件夹里面的模型拖入到ObstacleArray对象数组卡槽中
将隐藏以后的障碍物拖入到ObstaclePosArray对象数组卡槽中
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109104523577.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
添加Tag:
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200110125918410.png)
运行看一下：
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109104421142.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
### 七、路段切换
我们接着打开Control_Scenes.cs
添加函数：

```csharp
void Start()
{
        //Spawn_Obstacle(1);
        Change_Road(1);
}
public void Change_Road(int index)
{
        if (m_ISFirst && index == 0)
        {
            m_ISFirst = false;
            return;
        }
        else
        {
            int lastIndex = index - 1;
            if (lastIndex < 0)
                lastIndex = 2;
            m_RoadArray[lastIndex].transform.position = m_RoadArray[lastIndex].transform.position - new Vector3(150, 0, 0);
            Spawn_Obstacle(lastIndex);
        }
}
```
PS：这里解释一下代码，怎么切换的呢
举个例子，角色跑到了第二段，那么第一段要移动到第三段后面隔一个路段长度的距离，接下来画个图：
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109162935838.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
那么为啥x轴减去150。这是因为我发现这三条路段的距离都差了50，坐标轴是负轴，所以就减去了150。
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109163221578.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)


我们可以测试一下效果：
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109162424401.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
但是仅仅这样是不够的，我们还需要在角色到达抵达点的时候，切换路线，当然第一段路不用切换，因为再切就没了。。
这个在我们写完角色移动以后再补充。

## 八、角色移动
新建脚本：Control_Player.cs
说明一下：因为我们设定的三条道，所以角色只能在三条道里面切换。那么只需要改变角色的z值就可以了。如果角色在最左边，那么只能往右移动，同理在最右边，只能往左移动，在中间两边都可以移动。

接着我们就可以看一下z轴的值：
中间：
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109164046151.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109164213143.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)

左边：
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109164119365.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109164202681.png)
右边：
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109164138823.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200109164154429.png)
代码：

```csharp
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

    // Use this for initialization
    void Start()
    {
        m_Anim = GetComponent<Animator>();
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
}

```
键盘WSAD控制上跳，下滑，左右移动等操作。现在就可以去试试啦。
![在这里插入图片描述](https://img-blog.csdnimg.cn/202001091718491.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)

但是，有一点哈，角色怎么越跑越远离开了我们呢，因为，还没有写摄像机跟随脚本，接下来继续吧。

### 九、摄像机跟随
新建脚本Control_Camera.cs

```csharp
using UnityEngine;

public class Control_Camera : MonoBehaviour
{
	//间隔距离
	public float m_DistanceAway = 5f;
	//间隔高度
	public float m_DistanceHeight = 10f;
	//平滑值
	public float smooth = 2f;               
	//目标点
	private Vector3 m_TargetPosition;      
	//参照点
	Transform m_Follow;        

	void Start()
	{
		m_Follow = GameObject.Find("Player").transform;
	}

	void LateUpdate()
	{
		m_TargetPosition = m_Follow.position + Vector3.up * m_DistanceHeight - m_Follow.forward * m_DistanceAway;
		transform.position = Vector3.Lerp(transform.position, m_TargetPosition, Time.deltaTime * smooth);
	}
}

```
OK 摄像机跟着Player跑起来了
### 十、碰撞检测
我们需要不停的躲避障碍物，一旦碰撞到障碍物就dead了
我们首先修改障碍物的碰撞器属性：
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200110125227316.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
Mesh Collider  ： Is Trigger=true
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200110125240742.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
我们给Player加上刚体和碰撞体：
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200110124448104.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
注意要勾上Is Trigger

打开Control_Player.cs脚本：

```csharp
//游戏结束
bool m_IsEnd = false;
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
void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Vehicle_DumpTruck" || other.gameObject.name == "Vehicle_MixerTruck")
        {
            m_IsEnd = true;
            m_ForwardSpeeed = 0;
            m_Anim.SetBool("idle", true);
        }
    }
```
### 十一、切换道路
在第七章的时候就已经写好了道路切换，但是一直没有讲到碰撞检测，那么现在我们就结合碰撞检测，检测到抵达点然后切换道路吧

我们首先找到三个抵达点：MonitorPos
然后改名叫做MonitorPos0 MonitorPos1 MonitorPos2
![在这里插入图片描述](https://img-blog.csdnimg.cn/20200110125517463.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
修改一下BoxCollider的Is Trigger属性：
![在这里插入图片描述](https://img-blog.csdnimg.cn/2020011012553999.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3E3NjQ0MjQ1Njc=,size_16,color_FFFFFF,t_70)
修改Control_Player.cs的代码：
```csharp
 //场景控制对象
Control_Scenes m_ControlScenes;
void Start()
{
        m_Anim = GetComponent<Animator>();
        m_ControlScenes = GameObject.Find("Control_Scenes").GetComponent<Control_Scenes>();
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
```

