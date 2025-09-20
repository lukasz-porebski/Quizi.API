using Application.Contracts.Modules.QuizResults.Dtos;
using Application.Contracts.Modules.QuizzesVerification.Commands;
using Application.Contracts.Modules.QuizzesVerification.Commands.Data;
using AutoMapper;
using Common.Domain.ValueObjects;
using PublishedLanguage.Modules.QuizResults.Responses;
using PublishedLanguage.Modules.QuizzesVerification.Requests;
using PublishedLanguage.Modules.QuizzesVerification.Requests.Sub;

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

        CreateMap<QuizResultDetailsDto, QuizResultDetailsResponse>();
        CreateMap<QuizResultDetailsOpenQuestionDto, QuizResultDetailsOpenQuestionResponse>();
        CreateMap<QuizResultDetailsClosedQuestionDto, QuizResultDetailsSingleChoiceQuestionResponse>()
            .ForMember(r => r.SelectedAnswerOrdinalNumber, o => o.MapFrom(d =>
                d.Answers.First(a => a.IsSelected).OrdinalNumber));
        CreateMap<QuizResultDetailsClosedQuestionAnswerDto, QuizResultDetailsSingleChoiceQuestionAnswerResponse>();
        CreateMap<QuizResultDetailsClosedQuestionDto, QuizResultDetailsMultipleChoiceQuestionResponse>();
        CreateMap<QuizResultDetailsClosedQuestionAnswerDto, QuizResultDetailsMultipleChoiceQuestionAnswerResponse>();
    }
}