namespace BlogSite.Shared.Dtos
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> UserRoles { get; set; }
    }
}
