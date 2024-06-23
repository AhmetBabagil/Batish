using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.Notifications.Android;
using NotificationSamples.Android;

namespace NotificationSamples
{
    public class AndroidNotificationDenemesi : MonoBehaviour
    {
        private string channelId = "default_channel";
        private bool Initialized;
        private AndroidNotificationsPlatform Platform;
        private List<PendingNotification> PendingNotifications;
        private IPendingNotificationsSerializer Serializer;

        void Start()
        {
            Initialize();
            SendNotification("My Bou", "My Boubouu, I miss you", 500);
        }

        private void Initialize()
        {
            if (Initialized)
                throw new InvalidOperationException("NotificationsManager already initialized.");

            Initialized = true;
            Platform = new AndroidNotificationsPlatform();
            PendingNotifications = new List<PendingNotification>();

            RegisterNotificationChannel();
        }

        private void RegisterNotificationChannel()
        {
            var channel = new AndroidNotificationChannel()
            {
                Id = channelId,
                Name = "Default Channel",
                Importance = Importance.Default,
                Description = "Generic notifications"
            };
            AndroidNotificationCenter.RegisterNotificationChannel(channel);
        }

        private void SendNotification(string title, string text, int delayInSeconds)
        {
            var notification = new AndroidNotification()
            {
                Title = title,
                Text = text,
                FireTime = DateTime.Now.AddSeconds(delayInSeconds),
                SmallIcon = "small_icon",
                LargeIcon = "large_icon"
            };

            var notificationId = AndroidNotificationCenter.SendNotification(notification, channelId);
            notification.IntentData = "{\"title\": \"Custom Data\", \"message\": \"This is a test\"}";
            AndroidNotificationCenter.UpdateScheduledNotification(notificationId, notification, channelId);

            AndroidNotificationCenter.OnNotificationReceived += OnNotificationReceived;
        }

        private void OnNotificationReceived(AndroidNotificationIntentData data)
        {
            var msg = $"Notification received : {data.Id}\n" +
                      $"Title: {data.Notification.Title}\n" +
                      $"Body: {data.Notification.Text}\n" +
                      $"Channel: {data.Channel}";
            Debug.Log(msg);

            if (data.Notification.IntentData != null)
                Debug.Log("Custom data: " + data.Notification.IntentData);
        }

        void OnDestroy()
        {
            AndroidNotificationCenter.OnNotificationReceived -= OnNotificationReceived;
        }
    }
}
