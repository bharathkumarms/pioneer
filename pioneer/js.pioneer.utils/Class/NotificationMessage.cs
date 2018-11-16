using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace js.pioneer.utils
{
    public static class NotificationMessage
    {
        static Notification items;

        static NotificationMessage()
        {
            try
            {
                using (StreamReader r = new StreamReader("./notificationmessage.json"))
                {
                    string json = r.ReadToEnd();
                    items = JsonConvert.DeserializeObject<Notification>(json);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string SubscriberGetNotfound
        {
            get
            {
                try
                {
                    return items.subscriberGetNotfound;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static string SubscriberPostSuccess
        {
            get
            {
                try
                {
                    return items.subscriberPostSuccess;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static string SubscriberUpdateSuccess
        {
            get
            {
                try
                {
                    return items.subscriberUpdateSuccess;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static string SubscriberUpdateErrorNotFound
        {
            get
            {
                try
                {
                    return items.subscriberUpdateErrorNotFound;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static string SubscriberDeleteSuccess
        {
            get
            {
                try
                {
                    return items.subscriberDeleteSuccess;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static string SubscriberDeleteErrorNotFound
        {
            get
            {
                try
                {
                    return items.subscriberDeleteErrorNotFound;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }

    internal class Notification
    {
        public string subscriberGetNotfound;
        public string subscriberPostSuccess;
        public string subscriberUpdateSuccess;
        public string subscriberUpdateErrorNotFound;
        public string subscriberDeleteSuccess;
        public string subscriberDeleteErrorNotFound;
    }
}
