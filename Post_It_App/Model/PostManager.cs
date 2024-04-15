using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Post_It_App.Model {
    public class PostManager {
        private readonly List<PostItem> _posts;

        public PostManager() {
            _posts = new List<PostItem>();
        }

        public void AddPost(PostItem post) {
            _posts.Add(post);
        }

        public void UpdatePost(int id, string title, string description) {
            var post = _posts.FirstOrDefault(p => p.Id == id);
            if (post != null) {
                post.Title = title;
                post.Description = description;
            }
        }

        public void DeletePost(int id) {
            var post = _posts.FirstOrDefault(p => p.Id == id);
            if (post != null) {
                _posts.Remove(post);
            }
        }

        public List<PostItem> GetAllPosts() {
            return _posts.ToList();
        }

        public PostItem GetPostById(int id) {
            return _posts.FirstOrDefault(p => p.Id == id);
        }
    }
}
