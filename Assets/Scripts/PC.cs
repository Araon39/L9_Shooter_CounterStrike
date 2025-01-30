using UnityEngine;

public class PC : MonoBehaviour
{
    // ���������� ���������� ��� �������� ������ �� CharacterController
    public UnityEngine.CharacterController controller;

    // ���������� ��������� ���������� ��� �������� �������� ��������, ���������� � ������ ������
    private float speed = 5f;
    private float gravity = -9.81f;
    private float jumpHeight = 5f;

    // ���������� ��������� ���������� ��� �������� ������� ��������
    private Vector3 velocity;

    // ����� Update ���������� ������ ����
    void Update()
    {
        // ��������� ��������������� � ������������� ����� �� ������
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // �������� ������� �������� �� ������ ����� ������ � ����������� ���������
        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        // ����������� ��������� � �������������� CharacterController
        controller.Move(move * speed * Time.deltaTime);

        // ��������, ������ �� ������� �������
        if (Input.GetKey(KeyCode.Space))
        {
            // ��������� ��������� �������� ������ �� ��� Y
            velocity.y = jumpHeight;
        }

        // ���������� ���������� � �������� �� ��� Y
        velocity.y += gravity * Time.deltaTime;

        // ����������� ��������� �� ��� Y � �������������� CharacterController
        controller.Move(velocity * Time.deltaTime);
    }
}
