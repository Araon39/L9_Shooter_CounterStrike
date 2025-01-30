using UnityEngine;

public class Shoot : MonoBehaviour
{
   
    private float range = 100;      // ��������� ��������   
    public Camera mainCamera;       // ������ �� �������� ������
    public GameObject bulletEffects;// ������ ����, ������� ����� ���������������� ��� ��������   
    public GameObject bulletPoint;  // ������ ����� �� ����, ������� ����� ���������������� ��� ���������    
    public float damage = 10;       // ����, ��������� �����

    void Update()
    {
        // ���������, ������ �� ����� ������ ����
        if (Input.GetMouseButtonDown(0))
        {
            // �������� ����� ��� ��������� ��������
            Shoots();
        }
    }

    // ����� ��� ��������� ��������
    private void Shoots()
    {
        // ���������� ��� �������� ���������� � ��������� ����
        RaycastHit hit;

        // ���������, ����� �� ��� � ������ � �������� �������� ���������
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, range))
        {
            // ���� ��������� ���������, ������� ��� �������, � ������� ������
            Debug.Log(hit.transform.name);

            // �������� ��������� Target �� �������, � ������� ����� ���
            Target target = hit.transform.GetComponent<Target>();

            // ���������, ��� ��������� Target ����������
            if (target != null)
            {
                // ���� ��������� Target ����������, ������� ���� �������
                target.TakeDamage(damage);
            }


            // ������� ���� � ����� ��������� ����
            GameObject bullet = Instantiate(bulletEffects, hit.point, Quaternion.LookRotation(hit.normal));
            // ������� ����� �� ���� � ����� ��������� ����
            GameObject point = Instantiate(bulletPoint, hit.point, Quaternion.LookRotation(hit.normal));

            // ���������� ���� ����� 2 �������
            Destroy(bullet, 2f);
            // ���������� ����� �� ���� ����� 10 �������
            Destroy(point, 10f);
        }
    }
}
