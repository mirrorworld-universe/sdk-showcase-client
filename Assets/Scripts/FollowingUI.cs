using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingUI : MonoBehaviour
{
    private Canvas canvas;
    private GameObject target;

    private Camera uiCamera;

    public void Init(Canvas c,GameObject target)
    {
        canvas = c;
        this.target = target;

        if (canvas == null || target ==null)
        {
            Debug.LogError("FollowingUI: No canvas!");
            return;
        }
        if (canvas.renderMode == RenderMode.ScreenSpaceCamera
            || canvas.renderMode == RenderMode.WorldSpace)
        {
            uiCamera = canvas.worldCamera;
        }
        else if (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
        {
            uiCamera = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canvas == null || target == null)
        {
            Debug.LogError("FollowingUI: No params!");
            return;
        }
        Vector3 uiPoint = WorldPointToUIPoint(target);
        transform.position = uiPoint;
    }

    private Vector3 WorldPointToUIPoint(GameObject gameObject)
    {
        //world to screen
        Vector2 screenPoint = WorldPointToScreenPoint(gameObject.transform.position);
        //screen to ui
        // 将屏幕坐标转换为 UI transform.position
        RectTransform rt = this.gameObject.GetComponent<RectTransform>();
        Vector3 uiPoint = ScreenPointToUIPoint(rt, screenPoint);

        return uiPoint;
    }

    /// <summary>
    /// 世界坐标转换为屏幕坐标
    /// </summary>
    /// <param name="worldPoint">屏幕坐标</param>
    /// <returns></returns>
    public Vector2 WorldPointToScreenPoint(Vector3 worldPoint)
    {
        // Camera.main 世界摄像机
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(worldPoint);
        return screenPoint;
    }

    /// <summary>
    /// 屏幕坐标转换为世界坐标
    /// </summary>
    /// <param name="screenPoint">屏幕坐标</param>
    /// <param name="planeZ">距离摄像机 Z 平面的距离</param>
    /// <returns></returns>
    public static Vector3 ScreenPointToWorldPoint(Vector2 screenPoint, float planeZ)
    {
        // Camera.main 世界摄像机
        Vector3 position = new Vector3(screenPoint.x, screenPoint.y, planeZ);
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(position);
        return worldPoint;
    }

    // RectTransformUtility.WorldToScreenPoint
    // RectTransformUtility.ScreenPointToWorldPointInRectangle
    // RectTransformUtility.ScreenPointToLocalPointInRectangle
    // 上面三个坐标转换的方法使用 Camera 的地方
    // 当 Canvas renderMode 为 RenderMode.ScreenSpaceCamera、RenderMode.WorldSpace 时 传递参数 canvas.worldCamera
    // 当 Canvas renderMode 为 RenderMode.ScreenSpaceOverlay 时 传递参数 null

    // UI 坐标转换为屏幕坐标
    public Vector2 UIPointToScreenPoint(Vector3 worldPoint)
    {
        // RectTransform：target
        // worldPoint = target.position;

        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(uiCamera, worldPoint);
        return screenPoint;
    }

    // 屏幕坐标转换为 UGUI 坐标
    public Vector3 ScreenPointToUIPoint(RectTransform rt, Vector2 screenPoint)
    {
        Vector3 globalMousePos;

        // 当 Canvas renderMode 为 RenderMode.ScreenSpaceCamera、RenderMode.WorldSpace 时 uiCamera 不能为空
        // 当 Canvas renderMode 为 RenderMode.ScreenSpaceOverlay 时 uiCamera 可以为空
        RectTransformUtility.ScreenPointToWorldPointInRectangle(rt, screenPoint, uiCamera, out globalMousePos);
        // 转换后的 globalMousePos 使用下面方法赋值
        // target 为需要使用的 UI RectTransform
        // rt 可以是 target.GetComponent<RectTransform>(), 也可以是 target.parent.GetComponent<RectTransform>()
        // target.transform.position = globalMousePos;
        return globalMousePos;
    }


    // 屏幕坐标转换为 UGUI RectTransform 的 anchoredPosition
    public Vector2 ScreenPointToUILocalPoint(RectTransform parentRT, Vector2 screenPoint)
    {
        Vector2 localPos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRT, screenPoint, uiCamera, out localPos);
        // 转换后的 localPos 使用下面方法赋值
        // target 为需要使用的 UI RectTransform
        // parentRT 是 target.parent.GetComponent<RectTransform>()
        // 最后赋值 target.anchoredPosition = localPos;
        return localPos;
    }
}
