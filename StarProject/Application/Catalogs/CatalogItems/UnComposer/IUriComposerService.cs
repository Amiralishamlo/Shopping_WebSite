namespace Application.Catalogs.CatalogItems.UnComposer
{
    public interface IUriComposerService
    {
        string ComposeImageUri(string src);
    }
    public class UriComposerService : IUriComposerService
    {
        public string ComposeImageUri(string src)
        {
            return "https://localhost:7099/" + src.Replace("\\","//");
        }
    }
}
