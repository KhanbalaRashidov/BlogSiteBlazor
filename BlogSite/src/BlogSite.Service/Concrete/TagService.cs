using AutoMapper;
using BlogSite.Data;
using BlogSite.Entities;
using BlogSite.Service.Abstract;
using BlogSite.Shared.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BlogSite.Service.Concrete
{
    public class TagService : ITagService
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public TagService(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TagDTO>> GetTags()
        {
            var tags = await _db.Tags.ToListAsync();
            return _mapper.Map<IEnumerable<TagDTO>>(tags);
        }


        public async Task<IEnumerable<TagDTO>> GetUnselectedTags(int postId)
        {
            var postTags = _db.PostTags.Where(_ => _.PostId.Equals(postId))
                                        .Select(_ => _.TagId).ToList();
            var tags = await _db.Tags.Where(_ => !postTags.Contains(_.Id))
                                      .Select(_ => new TagDTO { Id = _.Id, Name = _.Name })
                                      .ToListAsync();
            return tags;
        }

        public async Task AddTag(AddTagDTO tagDTO)
        {
            var tag = _mapper.Map<Tag>(tagDTO);
            await _db.Tags.AddAsync(tag);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateTag(UpdateTagDTO tagDTO)
        {
            var tag = _mapper.Map<Tag>(tagDTO);

            _db.Entry(tag).State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
