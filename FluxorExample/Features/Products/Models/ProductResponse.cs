using System.Collections.Generic;

namespace FluxorExample.Products; 

public class ProductResponse
{
    public IEnumerable<Product> Products { get; set; }
    public int Limit { get; set; }
    public int Skip { get; set; }
    public int Total { get; set; }
}

