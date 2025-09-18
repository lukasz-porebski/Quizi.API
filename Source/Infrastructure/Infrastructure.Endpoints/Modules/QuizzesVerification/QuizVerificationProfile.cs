using Application.Contracts.Modules.QuizzesVerification.Commands;
using Application.Contracts.Modules.QuizzesVerification.Commands.Data;
using AutoMapper;
using Common.Domain.ValueObjects;
using PublishedLanguage.Modules.QuizzesVerification.Requests;
using PublishedLanguage.Modules.QuizzesVerification.Requests.Sub;

namespace Infrastructure.Endpoints.Modules.QuizzesVerification;

public class QuizVerificationProfile : Profile
{
    public QuizVerificationProfile()
    {
        CreateMap<VerifyQuizRequest, VerifyQuizCommand>()
            .ForCtorParam(nameof(VerifyQuizCommand.QuizResulId), e => e.MapFrom(request => AggregateId.Generate()));
        CreateMap<VerifyQuizOpenQuestionRequest, VerifyQuizOpenQuestionCommandData>();
        CreateMap<VerifyQuizSingleChoiceQuestionRequest, VerifyQuizSingleChoiceQuestionCommandData>();
        CreateMap<VerifyQuizMultipleChoiceQuestionRequest, VerifyQuizMultipleChoiceQuestionCommandData>();
        CreateMap<VerifyQuizClosedQuestionAnswerRequest, VerifyQuizClosedQuestionAnswerCommandData>();
    }
}