namespace BlogSite.Shared.Dtos
{
    public class GroupedUserDTO
    {
        public List<UserDTO> Users { get; set; }
        public List<UserDTO> Admins { get; set; }
    }
}
