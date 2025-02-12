using Application.Contracts.Modules.Quizzes.Commands;
using Application.Contracts.Modules.SharedQuizzes.Commands;
using AutoMapper;
using Common.Domain.ValueObjects;
using Domain.Modules.Quizzes.Data.Models.Sub;
using Domain.Modules.Quizzes.ValueObjects;
using PublishedLanguage.Modules.Quizzes.Requests;
using PublishedLanguage.Modules.Quizzes.Requests.Sub;

namespace Infrastructure.Endpoints.Modules.Quizzes;

public class QuizProfile : Profile
{
    public QuizProfile()
    {
        CreateMap<CreateQuizRequest, CreateQuizCommand>()
            .ForCtorParam(nameof(CreateQuizCommand.Id), e => e.MapFrom(request => AggregateId.Generate()));
        CreateMap<QuizClosedQuestionCreateRequest, QuizClosedQuestionCreateData>();

        CreateMap<QuizSettingsPersistRequest, QuizSettings>();
        CreateMap<QuizClosedQuestionAnswerPersistRequest, QuizClosedQuestionAnswerPersistData>();
        CreateMap<QuizOpenQuestionPersistRequest, QuizOpenQuestionPersistData>();

        CreateMap<UpdateQuizRequest, UpdateQuizCommand>();
        CreateMap<QuizClosedQuestionUpdateRequest, QuizClosedQuestionUpdateData>();

        CreateMap<AddQuizUserRequest, AddQuizUserCommand>();

        CreateMap<RemoveQuizUserRequest, RemoveQuizUserCommand>();
    }
}