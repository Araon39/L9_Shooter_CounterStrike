using UnityEngine;

public class MouseController : MonoBehaviour
{
    // �������� �������� ������ �� �����������
    private float speedHor = 9;
    // �������� �������� ������ �� ���������
    private float speedVert = 9;

    // ����������� �������� ���� �������� �� ���������
    private float minVert = -45;
    // ������������ �������� ���� �������� �� ���������
    private float maxVert = 45;

    // ������� ���� �������� �� ��� X (���������)
    private float rotationX;
    // ������� ���� �������� �� ��� Y (�����������)
    private float rotationY;

    // ����� ���������� ��� ������� �������
    void Start()
    {
        // ����������� ������ � ������ ��� ���������
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // ����� ���������� ���� ��� �� ������ ����
    void Update()
    {
        // �������� ������� ��������� ���� �� ��� Y, �������� �� �������� � ��������� ���� �������� �� ��� X
        rotationX -= Input.GetAxis("Mouse Y") * speedVert;
        // ������������ ���� �������� �� ��� X � �������� minVert � maxVert
        rotationX = Mathf.Clamp(rotationX, minVert, maxVert);

        // �������� ������� ��������� ���� �� ��� X, �������� �� �������� � ��������� ���� �������� �� ��� Y
        float delta = Input.GetAxis("Mouse X") * speedHor;
        rotationY = transform.localEulerAngles.y + delta;

        // ��������� ����� ���� �������� � �������
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
    }
}
