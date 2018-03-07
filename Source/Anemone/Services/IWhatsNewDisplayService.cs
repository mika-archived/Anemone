using System.Threading.Tasks;

namespace Anemone.Services
{
    public interface IWhatsNewDisplayService
    {
        Task ShowIfAppropriateAsync();
    }
}
