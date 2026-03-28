using Application.Contracts.Modules.QuizzesVerification.Commands;
using Application.Contracts.Modules.QuizzesVerification.Commands.Data;
using Application.Contracts.Modules.QuizzesVerification.Data;
using Application.Contracts.Modules.QuizzesVerification.Dtos;
using AutoMapper;
using Infrastructure.Endpoints.Modules.QuizzesVerification.Requests;
using Infrastructure.Endpoints.Modules.QuizzesVerification.Requests.Sub;
using Infrastructure.Endpoints.Modules.QuizzesVerification.Responses;
using LP.Common.Domain.ValueObjects;

namespace Infrastructure.Endpoints.Modules.QuizzesVerification;

public class QuizVerificationProfile : Profile
{
    public QuizVerificationProfile()
    {
        CreateMap<VerifyQuizRequest, VerifyQuizCommand>()
            .ForCtorParam(nameof(VerifyQuizCommand.QuizResultId), e => e.MapFrom(request => AggregateId.Generate()));
        CreateMap<VerifyQuizOpenQuestionRequest, VerifyQuizOpenQuestionCommandData>();
        CreateMap<VerifyQuizSingleChoiceQuestionRequest, VerifyQuizSingleChoiceQuestionCommandData>();
        CreateMap<VerifyQuizMultipleChoiceQuestionRequest, VerifyQuizMultipleChoiceQuestionCommandData>();
        CreateMap<VerifyQuizClosedQuestionAnswerRequest, VerifyQuizClosedQuestionAnswerCommandData>();

        CreateMap<QuizOpenQuestionAnswerForVerificationDto, QuizOpenQuestionAnswerForVerificationResponse>();

        CreateMap<QuizToRunData, QuizToRunResponse>();
        CreateMap<QuizToRunOpenQuestionData, QuizToRunOpenQuestionResponse>();
        CreateMap<QuizToRunClosedQuestionData, QuizToRunClosedQuestionResponse>();
        CreateMap<QuizToRunClosedQuestionAnswerData, QuizToRunClosedQuestionAnswerResponse>();
    }
}