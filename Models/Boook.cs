namespace WebApi4Boooks.Models
{
    public class Boook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        public string Excerpt { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
//{
//    "id": 0,
//    "title": "string",
//    "description": "string",
//    "pageCount": 0,
//    "excerpt": "string",
//    "publishDate": "2025-02-11T21:47:12.079Z"
//  }
