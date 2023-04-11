using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerForMap3 : MonoBehaviour
{
    public GameObject objectToHide; // كائن للإخفاء عند الصفر
    public GameObject objectToShow; // كائن للإظهار عند الصفر
    public Text timerText; // نص يعرض الوقت المتبقي
    public Button stopButton1; // زر لإيقاف العد التنازلي
    public Button stopButton2;
    public Button stopButton3;
    public Button stopButton4;

    private float timeLeft = 155f; // عدد الثواني المتبقية
    private bool timerFinished = false; // تحقق من إنزال العد التنازلي
    private bool stopButtonPressed = false; // تحقق من ضغط الزر

    void Start()
    {
        stopButton1.onClick.AddListener(StopTimer); // إضافة دالة StopTimer كمستمع للضغط على الزر
        stopButton2.onClick.AddListener(StopTimer);
        stopButton3.onClick.AddListener(StopTimer);
        stopButton4.onClick.AddListener(StopTimer);
    }

    void Update()
    {
        if (!timerFinished && !stopButtonPressed)
        {
            timeLeft -= Time.deltaTime; // تحديث الوقت المتبقي
            int minutes = Mathf.FloorToInt(timeLeft / 60f); // حساب عدد الدقائق المتبقية
            int seconds = Mathf.FloorToInt(timeLeft % 60f); // حساب عدد الثواني المتبقية

            // تحديث نص الوقت المتبقي
            timerText.text = string.Format("{0:0}:{1:00}", minutes, seconds);

            if (timeLeft <= 0f)
            {
                // إخفاء كائن وإظهار كائن آخر عند الصفر
                objectToHide.SetActive(false);
                objectToShow.SetActive(true);
                timerFinished = true; // تم إنزال العد التنازلي
            }
        }
    }

    void StopTimer()
    {
        timeLeft = 0f; // إنزال العد التنازلي عند الضغط على الزر
        stopButtonPressed = true; // تحديث متغير الضغط على الزر
    }
    public void LoadMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}