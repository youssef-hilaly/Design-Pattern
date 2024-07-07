using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutio
{
    // Liskov Substitution Principle
    // if C is a subtype of P, then objects of type P may be replaced with objects of type C
    internal class Post
    {
        public virtual void CreatePost(PostDatabase db, string post)
        {
            db.Add(post);
        }
    }

    internal class TagPost : Post
    {
        public override void CreatePost(PostDatabase db, string post)
        {
            db.AddTagPost(post);
        }
    }

    internal class MentionPost : Post
    {
        public override void CreatePost(PostDatabase db, string post)
        {
            db.AddMentionPost(post);
        }
    }

    // we can replace Post with TagPost or MentionPost
    // Post post = new TagPost();
    // post.CreatePost(new PostDatabase(), "post"); 




    internal class PostDatabase
    {
        public void Add(string post)
        {
            // add post to database
        }

        public void AddTagPost(string post)
        {
            // add tag to post
        }

        public void AddMentionPost(string post)
        {
            // add mention to post
        }
    }
}
