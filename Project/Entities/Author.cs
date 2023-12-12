using System.Collections.Generic;

namespace BookStoreAPI.Entities
{
    public class Author
    {

        // Une prop mets a dispostion des accesseurs (getters et setters)
        // ceci est une property
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();

    }
}