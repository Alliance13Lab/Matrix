using System;
using System.Collections.Generic;
using System.Text;

namespace Matrix.Domain.Entities;

public class City : IEntity<int>
{
    public int Id { get; set; }
    public int StateId { get; set; }    
    public string Name { get; set; }
}
