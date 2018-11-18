﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace js.pioneer.model
{
    public class Complaint
    {
        [BsonId]
        // standard BSonId generated by MongoDb
        public ObjectId InternalId { get; set; }

        public int ComplaintId { get; set; }
        public string SubscriptionNo { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}