namespace Common.Domain.Specification;

public interface ISpecification<in T>
{
    string FailureMessageCode { get; }
    bool IsValid(T data);
}