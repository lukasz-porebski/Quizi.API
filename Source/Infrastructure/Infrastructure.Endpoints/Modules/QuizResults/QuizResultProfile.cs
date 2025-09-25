using Application.Contracts.Modules.QuizResults.Dtos;
using Application.Contracts.Modules.QuizResults.Queries;
using AutoMapper;
using Common.PublishedLanguage.Requests;
using Common.PublishedLanguage.ViewModels;
using PublishedLanguage.Modules.QuizResults.Responses;

namespace Infrastructure.Endpoints.Modules.QuizResults;

public class QuizResultProfile : Profile
{
    public QuizResultProfile()
    {
        CreateMap<QuizResultDetailsDto, QuizResultDetailsResponse>()
            .ForMember(r => r.QuizRunningPeriod, o => o.MapFrom(d =>
                new PeriodViewModel<DateTime>(d.QuizRunningPeriodStart, d.QuizRunningPeriodEnd)));
        CreateMap<QuizResultDetailsOpenQuestionDto, QuizResultDetailsOpenQuestionResponse>();
        CreateMap<QuizResultDetailsClosedQuestionDto, QuizResultDetailsSingleChoiceQuestionResponse>()
            .ForMember(r => r.SelectedAnswerOrdinalNumber, o => o.MapFrom(d => GetSelectedAnswerOrdinalNumber(d)));
        CreateMap<QuizResultDetailsClosedQuestionAnswerDto, QuizResultDetailsSingleChoiceQuestionAnswerResponse>();
        CreateMap<QuizResultDetailsClosedQuestionDto, QuizResultDetailsMultipleChoiceQuestionResponse>();
        CreateMap<QuizResultDetailsClosedQuestionAnswerDto, QuizResultDetailsMultipleChoiceQuestionAnswerResponse>();

        CreateMap<PaginationRequest, GetQuizResultsQuery>()
            .ForCtorParam(nameof(GetQuizResultsQuery.Pagination), e => e.MapFrom(request => request));

        CreateMap<QuizResultsListItemDto, QuizResultsListItemResponse>();
    }

    private static int? GetSelectedAnswerOrdinalNumber(QuizResultDetailsClosedQuestionDto dto) =>
        dto.Answers.FirstOrDefault(a => a.IsSelected)?.OrdinalNumber;
}