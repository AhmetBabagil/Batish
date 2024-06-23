using System.Collections;
using System;
#if UNITY_IOS
using Unity.Notifications.iOS;
#endif
using UnityEngine;

public class IosNotificationsController : MonoBehaviour
{
#if UNITY_IOS
    public IEnumerator RequestAuthorization()
    {
        var req = new AuthorizationRequest(AuthorizationOption.Alert | AuthorizationOption.Badge, true);

        while (!req.IsFinished)
        {
            yield return null;
        }
    }

    public void SendNotification(string title, string body, string subtitle, int fireTimeInSeconds)
    {
        var timeTrigger = new iOSNotificationTimeIntervalTrigger()
        {
            TimeInterval = new TimeSpan(0, 0, fireTimeInSeconds),
            Repeats = false
        };

        var notification = new iOSNotification()
        {
            Identifier = "hello_world_notification",
            Title = title,
            Body = body,
            Subtitle = subtitle,
            ShowInForeground = true,
            ForegroundPresentationOption = PresentationOption.Alert | PresentationOption.Sound,
            CategoryIdentifier = "default_category",
            ThreadIdentifier = "thread1",
            Trigger = timeTrigger
        };

        iOSNotificationCenter.ScheduleNotification(notification);
    }
#endif
}
