using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Post_It_App.Model;
public class PostItem {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public PostItem(string title, string description) {
        Title = title;
        Description = description;
        Id = new Random().Next(1000, 9999);
    }


}
