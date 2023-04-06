using UnityEngine;

public class ShowButton : MonoBehaviour
{
    public GameObject hiddenObject; // الكائن المخفي

    private bool isInCube = false; // متغير لتتبع ما إذا كان اللاعب داخل المكعب
    
    // يتم استدعاء هذه الوظيفة عندما يدخل اللاعب المكعب
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // التأكد من أن الكائن الذي دخل المكعب هو اللاعب
        {
            isInCube = true; // تعيين المتغير isInCube على true لتشير إلى أن اللاعب داخل المكعب
            hiddenObject.SetActive(true); // إظهار الكائن المخفي
            Cursor.visible = true; // إظهار الفأرة
        }
    }

    // يتم استدعاء هذه الوظيفة عندما يخرج اللاعب من المكعب
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // التأكد من أن الكائن الذي خرج من المكعب هو اللاعب
        {
            isInCube = false; // تعيين المتغير isInCube على false لتشير إلى أن اللاعب خارج المكعب
            hiddenObject.SetActive(false); // إخفاء الكائن المخفي
            Cursor.visible = false; // إخفاء الفأرة
        }
    }
}