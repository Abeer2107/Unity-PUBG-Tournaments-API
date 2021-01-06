using System.Collections.Generic;

namespace JSONData
{
    [System.Serializable]
    public class Attributes
    {
        public string createdAt;
    }
    [System.Serializable]
    public class Data
    {
        public string type;
        public string id;
        public Attributes attributes;
    }
    [System.Serializable]
    public class Links
    {
        public string self;
    }
    [System.Serializable]
    public class Meta
    {
    }
    [System.Serializable]
    public class Root
    {
        public List<Data> data;
        public Links links;
        public Meta meta;
    }

}

