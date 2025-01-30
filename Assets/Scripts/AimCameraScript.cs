using UnityEngine;

public class AimCameraScript : MonoBehaviour
{
    // ���������� ���������� ��� �������� � ���������� �����
    public Camera mainCamera;
    public Camera aimCamera;

    // ����� Update ���������� ������ ����
    void Update()
    {
        // ��������, ������ �� ����� ������ ���� (��� ������ 1)
        if (Input.GetMouseButtonDown(1))
        {
            // ���������� �������� ������ � ��������� ���������� ������
            mainCamera.enabled = false;
            aimCamera.enabled = true;
        }

        // ��������, �������� �� ����� ������ ���� (��� ������ 1)
        if (Input.GetMouseButtonUp(1))
        {
            // ��������� �������� ������ � ���������� ���������� ������
            mainCamera.enabled = true;
            aimCamera.enabled = false;
        }
    }
}
