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

        public static string UserGetNotfound
        {
            get
            {
                try
                {
                    return items.userGetNotfound;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static string UserPostSuccess
        {
            get
            {
                try
                {
                    return items.userPostSuccess;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static string UserUpdateSuccess
        {
            get
            {
                try
                {
                    return items.userUpdateSuccess;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static string UserUpdateErrorNotFound
        {
            get
            {
                try
                {
                    return items.userUpdateErrorNotFound;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static string UserDeleteSuccess
        {
            get
            {
                try
                {
                    return items.userDeleteSuccess;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static string UserDeleteErrorNotFound
        {
            get
            {
                try
                {
                    return items.userDeleteErrorNotFound;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        //Start Type
        public static string TypeGetNotfound
        {
            get
            {
                try
                {
                    return items.typeGetNotfound;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static string TypePostSuccess
        {
            get
            {
                try
                {
                    return items.typePostSuccess;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static string TypeUpdateSuccess
        {
            get
            {
                try
                {
                    return items.typeUpdateSuccess;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static string TypeUpdateErrorNotFound
        {
            get
            {
                try
                {
                    return items.typeUpdateErrorNotFound;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static string TypeDeleteSuccess
        {
            get
            {
                try
                {
                    return items.typeDeleteSuccess;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static string TypeDeleteErrorNotFound
        {
            get
            {
                try
                {
                    return items.typeDeleteErrorNotFound;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        //End Type

        //Start Loyaltyuser
        public static string LoyaltyuserGetNotfound
        {
            get
            {
                try
                {
                    return items.loyaltyuserGetNotfound;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static string LoyaltyuserPostSuccess
        {
            get
            {
                try
                {
                    return items.loyaltyuserPostSuccess;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static string LoyaltyuserUpdateSuccess
        {
            get
            {
                try
                {
                    return items.loyaltyuserUpdateSuccess;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static string LoyaltyuserUpdateErrorNotFound
        {
            get
            {
                try
                {
                    return items.loyaltyuserUpdateErrorNotFound;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static string LoyaltyuserDeleteSuccess
        {
            get
            {
                try
                {
                    return items.loyaltyuserDeleteSuccess;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static string LoyaltyuserDeleteErrorNotFound
        {
            get
            {
                try
                {
                    return items.loyaltyuserDeleteErrorNotFound;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        //End Loyaltyuser

        //Start Complaint

        public static string ComplaintGetNotfound
        {
            get
            {
                try
                {
                    return items.complaintGetNotfound;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static string ComplaintPostSuccess
        {
            get
            {
                try
                {
                    return items.complaintPostSuccess;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static string ComplaintUpdateSuccess
        {
            get
            {
                try
                {
                    return items.complaintUpdateSuccess;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static string ComplaintUpdateErrorNotFound
        {
            get
            {
                try
                {
                    return items.complaintUpdateErrorNotFound;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static string ComplaintDeleteSuccess
        {
            get
            {
                try
                {
                    return items.complaintDeleteSuccess;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static string ComplaintDeleteErrorNotFound
        {
            get
            {
                try
                {
                    return items.complaintDeleteErrorNotFound;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        //End Complaint
    }

    internal class Notification
    {
        public string subscriberGetNotfound;
        public string subscriberPostSuccess;
        public string subscriberUpdateSuccess;
        public string subscriberUpdateErrorNotFound;
        public string subscriberDeleteSuccess;
        public string subscriberDeleteErrorNotFound;

        public string userGetNotfound;
        public string userPostSuccess;
        public string userUpdateSuccess;
        public string userUpdateErrorNotFound;
        public string userDeleteSuccess;
        public string userDeleteErrorNotFound;


        public string typeGetNotfound;
        public string typePostSuccess;
        public string typeUpdateSuccess;
        public string typeUpdateErrorNotFound;
        public string typeDeleteSuccess;
        public string typeDeleteErrorNotFound;

        public string loyaltyuserGetNotfound;
        public string loyaltyuserPostSuccess;
        public string loyaltyuserUpdateSuccess;
        public string loyaltyuserUpdateErrorNotFound;
        public string loyaltyuserDeleteSuccess;
        public string loyaltyuserDeleteErrorNotFound;

        public string complaintGetNotfound;
        public string complaintPostSuccess;
        public string complaintUpdateSuccess;
        public string complaintUpdateErrorNotFound;
        public string complaintDeleteSuccess;
        public string complaintDeleteErrorNotFound;
    }
}
