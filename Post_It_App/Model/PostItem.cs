using System;

namespace Post_It_App.Model;

public class PostItem(string? title, string? description) {
    public int Id { get; } = new Random().Next(1000, 9999);
    public string? Title { get; set; } = title;
    public string? Description { get; set; } = description;
}