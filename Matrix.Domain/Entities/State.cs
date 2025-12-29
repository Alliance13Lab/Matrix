using System;
using System.Collections.Generic;
using System.Text;

namespace Matrix.Domain.Entities;

public class State : IEntity<int>
{
    public int Id { get; set; }
    public int CountryId { get; set; }    
    public string Name { get; set; }
}
