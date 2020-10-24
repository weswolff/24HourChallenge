using _24HourChallenge.Data;
using _24HourChallenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HourChallenge.Services
{
    public class CommentService
    {
        private readonly Guid _userId;

        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    //Id = _userId,
                    Text = model.Text
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new CommentListItem
                                {
                                    Id = e.Id,
                                    Text = e.Text,
                                    //Author = e.Author.ToString()
                                }
                        );
                return query.ToArray();
            }
        }

        public bool UpdateComment(Comment model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.Id == model.Id && e.OwnerId == _userId);

                
                entity.Text = model.Text;
                
                //entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
