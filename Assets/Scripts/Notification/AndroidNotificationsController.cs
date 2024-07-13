using UnityEngine;
#if UNITY_ANDROID
using Unity.Notifications.Android;

public class AndroidNotificationsController : MonoBehaviour
{
    public void RegisterNotificationChannel()
    {
        var channel = new AndroidNotificationChannel()
        {
            Id = "default_channel",
            Name = "Default Name",
            Importance = Importance.High,
            Description = "Generic Description"
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    public void SendNotification(string title, string text, int fireTimeInSeconds)
    {
        var notification = new AndroidNotification()
        {
            Title = title,
            Text = text,
            FireTime = System.DateTime.Now.AddSeconds(fireTimeInSeconds)
        };

        AndroidNotificationCenter.SendNotification(notification, "default_channel");
    }
#endif
}
