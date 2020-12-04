using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Domain.Model.Base
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        string Id { get; set; }

        string Uuid { get; set; }

        DateTime CreatedAt { get; }

        DateTime? UpdatedAt { get; set; }
    }
}
