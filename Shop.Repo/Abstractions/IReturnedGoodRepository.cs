using Shop.Repo.Models;

namespace Shop.Repo.Abstractions
{
    public interface IReturnedGoodRepository
    {
        Task ReturnGood(ReturnGoodModel returnGoodModel);
    }
}
