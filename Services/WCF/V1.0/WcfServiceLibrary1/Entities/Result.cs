using System.Runtime.Serialization;

namespace WcfServiceLibrary1.Entities
{
    [DataContract]
    public class Result<T>
    {
        [DataMember]
        public T Data { set; get; }
        [DataMember]
        public string Message { set; get; }

        public Result()
        {
            this.Data = default(T);
        }
        public Result(T data)
        {
            this.Data = data;
        }
    }
}
