namespace FluentBuilderDemo_BlazorServer.Services;
/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public sealed class Result<T>
{
    public bool IsSuccess { get; }
    public T? Value { get; }
    public IReadOnlyList<string> Errors { get; }
    private Result(bool ok, T? value, IReadOnlyList<string> errors) => (IsSuccess, Value, Errors) = (ok, value, errors);
    public static Result<T> Success(T value) => new(true, value, []);
    public static Result<T> Failure(params string[] errors) => new(false, default, errors);
    public static Result<T> Failure(IEnumerable<string> errors) => new(false, default, errors.ToArray());
}
/// <summary>
/// 
/// </summary>
public static class Result { 
    public static Result<T> FromErrors<T>(IEnumerable<string> errors) => Result<T>.Failure(errors);
}
