using System.Collections.Generic;
using System.Linq;


namespace Post_It_App.Model;
public class PostManager {

    private readonly List<PostItem?> _posts = [];

    public static PostManager Instance { get; } = new();

    public void AddPost(PostItem? post) {
        _posts.Add(post);
    }

    public void UpdatePost(int id, string? title, string? description) {
        var post = _posts.FirstOrDefault(p => p != null && p.Id == id);
        if (post == null) return;
        post.Title = title;
        post.Description = description;
    }

    public void DeletePost(int id) {
        var post = _posts.FirstOrDefault(p => p != null && p.Id == id);
        if (post != null) {
            _posts.Remove(post);
        }
    }

    public List<PostItem?> GetAllPosts() {
        return _posts.ToList();
    }

    public PostItem? GetPostById(int id) {
        return _posts.FirstOrDefault(p => p != null && p.Id == id);
    }

    public List<PostItem?> SearchPostsReturn(string searchTerm) {
        return _posts.FindAll(p => p?.Description != null && p is { Title: not null } && (p.Title.Contains(searchTerm) || p.Description.Contains(searchTerm)));
    }
}

