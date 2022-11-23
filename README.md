# Repro Steps
- `cd ./FluxorExample` and run `dotnet watch`

# Problem
When the user visits /products TThe Products are always reloaded.
This is because the `<Virtualize>` component used in `FluxorExample\Features\Products\Pages\ProductsOverview.razor` does not play well together with the state `FluxorExample\Features\Products\State\ProductState.cs` yet.