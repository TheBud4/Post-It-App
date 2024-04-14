using System;

namespace Post_It_App.Model;
internal class PostItem {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public PostItem(string title, string description) {
        Title = title;
        Description = description;
        Id = new Random().Next(1000, 9999);
    }
}
