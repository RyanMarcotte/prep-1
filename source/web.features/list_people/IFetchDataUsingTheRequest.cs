namespace code.web.features.list_people
{
	public interface IFetchDataUsingTheRequest<out Data>
	{
		Data fetch_using_request(IProvideDetailsAboutAWebRequest request);
	}
}