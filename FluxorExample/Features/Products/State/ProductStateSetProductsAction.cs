using Fluxor;
using System.Collections.Generic;

namespace FluxorExample.Products;

public record ProductsStateSetProductsAction(IEnumerable<Product> products);

public static partial class ProductsStateReducers
{
    [ReducerMethod]
    public static ProductsState Reduce(ProductsState state, ProductsStateSetProductsAction action)
        => state with { Products = action.products };
}