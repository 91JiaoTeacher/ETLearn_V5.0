using ETModel;
using MongoDB.Bson.Serialization.Attributes;

namespace ETHotfix
{
    [BsonIgnoreExtraElements]
    public class PlayerInfoDB : Entity
    {
        public int account;

        public string pwd;
    }
}
