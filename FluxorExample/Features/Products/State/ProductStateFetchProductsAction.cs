using Fluxor;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FluxorExample.Products;

public record ProductsStateFetchProductsAction(TaskCompletionSource<ProductResponse> taskSource, string Category, int Skip, int Take);

public class ProductsStateFetchProductsActionEffect : Effect<ProductsStateFetchProductsAction>
{
    public readonly HttpClient _http;

    public ProductsStateFetchProductsActionEffect(HttpClient http)
    {
        _http = http;
    }

    public async override Task HandleAsync(ProductsStateFetchProductsAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new ProductsStateSetLoadingAction(true));

        ProductResponse productResponse;
        if (action.Category == "all")
        {
            productResponse = await _http.GetFromJsonAsync<ProductResponse>($"https://dummyjson.com/products?limit={action.Take}0&skip={action.Skip}");
        }
        else
        {
            productResponse = await _http.GetFromJsonAsync<ProductResponse>($"https://dummyjson.com/products/category/{action.Category}?limit={action.Take}0&skip={action.Skip}");
        }
        dispatcher.Dispatch(new ProductsStateSetProductsAction(productResponse.Products));
        action.taskSource.SetResult(productResponse);

        dispatcher.Dispatch(new ProductsStateSetLoadingAction(false));
    }
}