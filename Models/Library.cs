﻿namespace poprawa_kol1.Models;

public class Library
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }

    public List<Book> Books { get; set; }
}