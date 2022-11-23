using Fluxor;
using System.Collections.Generic;

namespace FluxorExample.Products;

[FeatureState]
public record ProductsState
{
    public bool IsLoading { get; init; } = false;
    public IEnumerable<Product> Products { get; set; } = new List<Product>();
}

