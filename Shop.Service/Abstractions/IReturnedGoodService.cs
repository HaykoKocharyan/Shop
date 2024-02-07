using Shop.Repo.Models;

namespace Shop.Service.Abstractions
{
    public interface IReturnedGoodService
    {
        Task ReturnGood(ReturnGoodModel returnGoodModel);
    }
}
