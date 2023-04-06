using UnityEngine;

public class FPS : MonoBehaviour
{
    public float speed = 5f; // سرعة اللاعب
    public float sensitivity = 100f; // حساسية حركة الماوس
    public Rigidbody rb; // المكون الذي يتحرك به اللاعب
    private float rotation = 0f; // التدوير الأفقي
    private bool isGrounded; // متغير يحدد إذا كان اللاعب على الأرض

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // الحصول على المكون Rigidbody من اللاعب
        Cursor.lockState = CursorLockMode.Locked; // إخفاء المؤشر عند تشغيل اللعبة
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // حركة اللاعب الأفقية
        float moveVertical = Input.GetAxis("Vertical"); // حركة اللاعب العمودية

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); // حركة اللاعب في الفضاء الثلاثي الأبعاد

        if (isGrounded) // تمكين اللاعب من السير فقط إذا كان على الأرض
        {
            rb.AddForce(movement * speed); // إضافة القوة لحركة اللاعب
        }

        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime; // حركة الماوس الأفقية
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime; // حركة الماوس العمودية

        rotation -= mouseY; // دوران الكاميرا عند حركة الماوس العمودية
        rotation = Mathf.Clamp(rotation, -90f, 90f); // حدود الدوران الأفقي

        transform.localRotation = Quaternion.Euler(rotation, 0f, 0f); // تدوير اللاعب بشكل أفقي
        transform.Rotate(Vector3.up * mouseX); // تدوير اللاعب بشكل عمودي
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "Ground") // التحقق إذا كان اللاعب على الأرض
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Ground") // التحقق إذا خرج اللاعب عن الأرض
        {
            isGrounded = false;
        }
    }
}