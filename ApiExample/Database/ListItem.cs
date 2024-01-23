using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ApiExample.Database;
public class ListItem(string description)
{
    public int Id { get; init; }
    public string Description { get; set; } = description;
}