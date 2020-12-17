using System.Runtime.Serialization;

namespace Example.AdminApi.Dto
{
    [DataContract]
    public class UserDto
    {
        [DataMember( Name = "id" )]
        public int Id { get; set; }

        [DataMember( Name = "username" )]
        public string Username { get; set; }
    }
}
