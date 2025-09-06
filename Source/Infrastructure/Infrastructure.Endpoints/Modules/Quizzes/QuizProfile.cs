using Application.Contracts.Modules.Quizzes.Commands;
using Application.Contracts.Modules.Quizzes.Dtos;
using Application.Contracts.Modules.Quizzes.Queries;
using Application.Contracts.Modules.SharedQuizzes.Commands;
using AutoMapper;
using Common.Domain.ValueObjects;
using Common.PublishedLanguage.Requests;
using Domain.Modules.Quizzes.Data.Models.Sub;
using Domain.Modules.Quizzes.ValueObjects;
using PublishedLanguage.Modules.Quizzes.Requests;
using PublishedLanguage.Modules.Quizzes.Requests.Sub;
using PublishedLanguage.Modules.Quizzes.Responses;

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

        CreateMap<PaginationRequest, GetQuizzesQuery>()
            .ForCtorParam(nameof(GetQuizzesQuery.Pagination), e => e.MapFrom(request => request));

        CreateMap<QuizzesListItemDto, QuizzesListItemResponse>();

        CreateMap<QuizDetailsDto, QuizDetailsViewModel>();
        CreateMap<QuizDetailsOpenQuestionDto, QuizDetailsOpenQuestionViewModel>();
        CreateMap<QuizDetailsChoiceQuestionDto, QuizDetailsChoiceQuestionViewModel>();
        CreateMap<QuizDetailsChoiceQuestionAnswerDto, QuizDetailsChoiceQuestionAnswerViewModel>();
    }
}