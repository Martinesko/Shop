namespace Shop.Services.ColorService.Contract
{
    public interface IColorService
    {
       public Task<IEnumerable<string>> GetColors();
    }
}
