using System;
using System.Collections.Generic;

namespace BookStoreAPI.Entities

{
    public class Achat
    {

        // Une prop mets a dispostion des accesseurs (getters et setters)
        // ceci est une property
        public int Id { get; set; }
        public Client Client { get; set; } = default!;
        public Book Book { get; set; } = default!;
        public int Quantity { get; set; }
        public DateTime DateAchat { get; set; } = DateTime.Now;

    }
}