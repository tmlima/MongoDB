using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB_Basic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Beginning...");

            const string ConnectionString = "mongodb://localhost/?safe=true";
            MongoClient client = new MongoClient(ConnectionString);
            MongoServer server = client.GetServer();
            MongoDatabase blog = server.GetDatabase("blog");

            MongoCollection<Post> posts = blog.GetCollection<Post>("posts");

            const string POST_TITLE = "First post!";

            Post firstPost = new Post(
                POST_TITLE,
                "This is the first post on my very popular blog.");
            posts.Save(firstPost);

            firstPost = GetPostByTitle(posts, POST_TITLE);

            Console.WriteLine("Done!");
            Console.ReadKey();
        }

        static void Write(Post post, MongoCollection collection)
        {
            collection.Save(post);
        }

        static Post GetPostByTitle(MongoCollection<Post> posts, string title)
        {
            IMongoQuery query = Query.EQ("Title", title);
            MongoCursor<Post> cursor = posts.Find(query);
            return cursor.First();
        }
    }
}
