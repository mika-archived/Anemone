using System.Threading.Tasks;

namespace Anemone.Services
{
    public interface IFirstRunDisplayService
    {
        Task ShowIfAppropriateAsync();
    }
}
