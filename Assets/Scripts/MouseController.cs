using UnityEngine;

public class MouseController : MonoBehaviour
{
    // —корость поворота камеры по горизонтали
    private float speedHor = 9;
    // —корость поворота камеры по вертикали
    private float speedVert = 9;

    // ћинимальное значение угла поворота по вертикали
    private float minVert = -45;
    // ћаксимальное значение угла поворота по вертикали
    private float maxVert = 45;

    // “екущий угол поворота по оси X (вертикаль)
    private float rotationX;
    // “екущий угол поворота по оси Y (горизонталь)
    private float rotationY;

    // ћетод вызываетс€ при запуске скрипта
    void Start()
    {
        // «ахватываем курсор и делаем его невидимым
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // ћетод вызываетс€ один раз за каждый кадр
    void Update()
    {
        // ѕолучаем текущее положение мыши по оси Y, умножаем на скорость и обновл€ем угол поворота по оси X
        rotationX -= Input.GetAxis("Mouse Y") * speedVert;
        // ќграничиваем угол поворота по оси X в пределах minVert и maxVert
        rotationX = Mathf.Clamp(rotationX, minVert, maxVert);

        // ѕолучаем текущее положение мыши по оси X, умножаем на скорость и обновл€ем угол поворота по оси Y
        float delta = Input.GetAxis("Mouse X") * speedHor;
        rotationY = transform.localEulerAngles.y + delta;

        // ѕримен€ем новые углы поворота к объекту
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
    }
}
