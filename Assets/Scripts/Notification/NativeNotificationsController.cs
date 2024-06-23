using System.Collections;
using UnityEngine;

public class NativeNotificationsController : MonoBehaviour
{
    [SerializeField]
    private AndroidNotificationsController androidNotificationsController;

    [SerializeField]
    private IosNotificationsController iosNotificationsController;

    private void Start()
    {
#if UNITY_ANDROID
        androidNotificationsController.RegisterNotificationChannel();
        androidNotificationsController.SendNotification("My Bou", "My Boubouu, I miss you", 180);

#elif UNITY_IOS
        StartCoroutine(iosNotificationsController.RequestAuthorization());
        iosNotificationsController.SendNotification("My Bou", "My Boubouu, I miss you", "See you soon", 180);
#endif
    }

}
