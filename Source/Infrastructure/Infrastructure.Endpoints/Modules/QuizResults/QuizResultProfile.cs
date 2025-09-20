using Application.Contracts.Modules.QuizResults.Dtos;
using AutoMapper;
using Common.PublishedLanguage.Requests;
using PublishedLanguage.Modules.QuizResults.Responses;

namespace Infrastructure.Endpoints.Modules.QuizResults;

public class QuizResultProfile : Profile
{
    public QuizResultProfile()
    {
        CreateMap<QuizResultDetailsDto, QuizResultDetailsResponse>()
            .ForMember(r => r.QuizRunningPeriod, o => o.MapFrom(d =>
                new PeriodRequest<DateTime>(d.QuizRunningPeriodStart, d.QuizRunningPeriodEnd)));
        CreateMap<QuizResultDetailsOpenQuestionDto, QuizResultDetailsOpenQuestionResponse>();
        CreateMap<QuizResultDetailsClosedQuestionDto, QuizResultDetailsSingleChoiceQuestionResponse>()
            .ForMember(r => r.SelectedAnswerOrdinalNumber, o => o.MapFrom(d =>
                d.Answers.First(a => a.IsSelected).OrdinalNumber));
        CreateMap<QuizResultDetailsClosedQuestionAnswerDto, QuizResultDetailsSingleChoiceQuestionAnswerResponse>();
        CreateMap<QuizResultDetailsClosedQuestionDto, QuizResultDetailsMultipleChoiceQuestionResponse>();
        CreateMap<QuizResultDetailsClosedQuestionAnswerDto, QuizResultDetailsMultipleChoiceQuestionAnswerResponse>();
    }
}