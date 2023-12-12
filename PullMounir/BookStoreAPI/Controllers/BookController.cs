using System.Collections.Generic;
using BookStoreAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookStoreAPI.Controllers; // BookStoreAPI est l'espace de nom racine de mon projet 



// Ceci est une annotation, elle permet de définir des métadonnées sur une classe
// Dans ce contexte elle permet de définir que la classe BookController est un contrôleur d'API
// On parle aussi de decorator / décorateur
[ApiController]
public class BookController : ControllerBase
{

    // C'est un méthode GET qui permet de récupérer les livres, j'en créer égakelent un nouveau que j'ajoute à ma liste et je la retourne
    [HttpGet("books")]
    public ActionResult<List<Book>> GetBooks()
    {
        // je créer une liste de livres
        var books = new List<Book>
        {
            // je créer un nouveau livre et je l'ajoute à ma liste
            new() { Id = 1, Title = "Le seigneur des anneaux", Author = "J.R.R Tolkien" }
        };

        return Ok(books);

    }

    // je créer ma route qui me permet de créer un nouveau livre
    [HttpPost("books")]
    public ActionResult<Book> CreateBook([FromBody] Book book)
    {

        Console.WriteLine("appel de la méthode CreateBook");
        // je créer un nouveau livre et je l'ajoute à ma liste
        var newBook = new Book { Id = 2, Title = book.Title, Author = book.Author };

        return Ok(newBook);
    }

}