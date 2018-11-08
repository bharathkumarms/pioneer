﻿using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace js.pioneer.model
{
    public class User
    {
        [BsonId]
        // standard BSonId generated by MongoDb
        public ObjectId InternalId { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public Role Roleid { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
