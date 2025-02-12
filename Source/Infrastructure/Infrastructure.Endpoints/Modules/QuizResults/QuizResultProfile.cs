using Application.Contracts.Modules.QuizzesVerification.Commands;
using Application.Contracts.Modules.QuizzesVerification.Commands.Data;
using AutoMapper;
using Common.Domain.ValueObjects;
using PublishedLanguage.Modules.QuizResults.Requests;
using PublishedLanguage.Modules.QuizResults.Requests.Sub;

namespace Infrastructure.Endpoints.Modules.QuizResults;

public class QuizResultProfile : Profile
{
    public QuizResultProfile()
    {
        CreateMap<VerifyQuizRequest, VerifyQuizCommand>()
            .ForCtorParam(nameof(VerifyQuizCommand.QuizResulId), e => e.MapFrom(request => AggregateId.Generate()));
        CreateMap<VerifyQuizOpenQuestionRequest, VerifyQuizOpenQuestionCommandData>();
        CreateMap<VerifyQuizSingleChoiceQuestionRequest, VerifyQuizSingleChoiceQuestionCommandData>();
        CreateMap<VerifyQuizMultipleChoiceQuestionRequest, VerifyQuizMultipleChoiceQuestionCommandData>();
        CreateMap<VerifyQuizClosedQuestionAnswerRequest, VerifyQuizClosedQuestionAnswerCommandData>();
    }
}