using Fluxor;

namespace FluxorExample.Products;

public record ProductsStateSetLoadingAction(bool isLoading);

public static partial class ProductsStateReducers
{
    [ReducerMethod]
    public static ProductsState Reduce(ProductsState state, ProductsStateSetLoadingAction action)
        => state with { IsLoading = action.isLoading };
}