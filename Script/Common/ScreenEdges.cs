using UnityEngine;

public class ScreenEdges : MonoBehaviour
{
    [SerializeField] float m_Thickness = 2;
    [SerializeField] float m_SizeOffset = 2;
    [SerializeField] Vector2 m_PositionOffset = Vector2.zero;

    [SerializeField] bool Top = false;
    [SerializeField] bool Bottom = false;
    [SerializeField] bool Right = false;
    [SerializeField] bool Left = false;

    Vector2 m_CameraPosition;
    float m_HalfScreenHeight;
    float m_HalfScreenLength;
        
    Transform m_TopCollider;
    Transform m_BottomCollider;
    Transform m_RightCollider;
    Transform m_LeftCollider;

    // Const
    const string TOP = "TopCollider";
    const string BOTTOM = "BottomCollider";
    const string RIGHT = "RightCollider";
    const string LEFT = "LeftCollider";

    private void Awake()
    {
        if (transform.childCount < 1)
        {
            CreateScreenEdges();
        }
    }

    [ContextMenu("Create Edge Colliders")]
    public void CreateScreenEdges()
    {
        DeleteChildren();
        GetCamInfo();

        if (Top)
        {
            m_TopCollider = GetEdge(TOP);
            SetTopCollider();
        }
        if (Bottom)
        {
            m_BottomCollider = GetEdge(BOTTOM);
            SetBottomCollider();
        }
        if (Right)
        {
            m_RightCollider = GetEdge(RIGHT);
            SetRightCollider();
        }
        if (Left)
        {
            m_LeftCollider = GetEdge(LEFT);
            SetLeftCollider();
        }
    }

    [ContextMenu("Clear All")]
    public void DeleteChildren()
    {
        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }

    public void GetCamInfo()
    {
        var cam = Camera.main;
        m_CameraPosition = cam.transform.position;

        if (cam.orthographic)
        {
            m_HalfScreenHeight = cam.orthographicSize;
            m_HalfScreenLength = m_HalfScreenHeight * cam.aspect;
        }
        else
        {
            //////////////////////// WORK IN PROGRESS ////////////////////////

            //var perspectiveCam = cam.ScreenToWorldPoint(m_CameraPosition);
            //var perspectiveWidth = cam.ScreenToWorldPoint(new Vector2(Screen.width, perspectiveCam.y));
            //var perspectiveHeight = cam.ScreenToWorldPoint(new Vector2(perspectiveCam.x, Screen.height));

            var perspectiveBase = cam.ScreenToWorldPoint(Vector2.zero);
            var perspectiveWidth = cam.ScreenToWorldPoint(new Vector2(Screen.width, 0));
            var perspectiveHeight = cam.ScreenToWorldPoint(new Vector2(0, Screen.height));

            m_HalfScreenLength = Vector2.Distance(perspectiveBase, perspectiveWidth) / 2;
            m_HalfScreenHeight = Vector2.Distance(perspectiveBase, perspectiveHeight) / 2;
        }

        //Debug.Log("height: " + m_HalfScreenHeight);
        //Debug.Log("length: " + m_HalfScreenLength);
        //return new Vector2(m_HalfScreenLength, m_HalfScreenHeight);
    }

    Transform GetEdge(string _name)
    {
        var trans = new GameObject().transform;             // Create new GO.
        trans.parent = base.transform;                      // Set parent for GO.
        trans.name = _name;                                 // Name the GO.
        trans.gameObject.AddComponent<BoxCollider2D>();     // Add BoxCollider component.
        return trans;
    }

    void SetTopCollider()
    {
        if (m_TopCollider.TryGetComponent(out BoxCollider2D _col))
        {
            _col.size = new Vector2((m_HalfScreenLength + m_SizeOffset) * 2, m_Thickness);
            _col.transform.position = new Vector2(m_CameraPosition.x, m_CameraPosition.y + m_HalfScreenHeight);
            _col.offset = new Vector2(0, m_Thickness / 2 + m_PositionOffset.y);
        }
        else
            Debug.LogError("TopEdge doesn't have BoxCollider2D");
    }

    void SetBottomCollider()
    {
        if (m_BottomCollider.TryGetComponent(out BoxCollider2D _col))
        {
            _col.size = new Vector2((m_HalfScreenLength + m_SizeOffset) * 2, m_Thickness);
            _col.transform.position = new Vector2(m_CameraPosition.x, m_CameraPosition.y - m_HalfScreenHeight);
            _col.offset = new Vector2(0, -(m_Thickness / 2 + m_PositionOffset.y));
        }
        else
            Debug.LogError("BottomEdge doesn't have BoxCollider2D");
    }

    void SetRightCollider()
    {
        if (m_RightCollider.TryGetComponent(out BoxCollider2D _col))
        {
            _col.size = new Vector2(m_Thickness, (m_HalfScreenHeight + m_SizeOffset) * 2);
            _col.transform.position = new Vector2(m_CameraPosition.x + m_HalfScreenLength, m_CameraPosition.y);
            _col.offset = new Vector2(m_Thickness / 2 + m_PositionOffset.x, 0);
        }
        else
            Debug.LogError("RightEdge doesn't have BoxCollider2D");
    }

    void SetLeftCollider()
    {
        if (m_LeftCollider.TryGetComponent(out BoxCollider2D _col))
        {
            _col.size = new Vector2(m_Thickness, (m_HalfScreenHeight + m_SizeOffset) * 2);
            _col.transform.position = new Vector2(m_CameraPosition.x - m_HalfScreenLength, m_CameraPosition.y);
            _col.offset = new Vector2(-(m_Thickness / 2 + m_PositionOffset.x), 0);
        }
        else
            Debug.LogError("LeftEdge doesn't have BoxCollider2D");
    }
}
