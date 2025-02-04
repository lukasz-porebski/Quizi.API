using Common.Application.Contracts.Interfaces;
using Domain.Modules.SharedQuizzes.Models;

namespace Application.Contracts.Modules.SharedQuizzes.Interfaces;

public interface ISharedQuizRepository : IRepository<SharedQuiz>;