namespace BlogSite.Entities
{
    public class Tag:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<PostTag> PostTags { get; set; } = new HashSet<PostTag>();
    }
}
