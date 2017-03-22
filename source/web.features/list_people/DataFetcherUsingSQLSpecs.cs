using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using code.prep.people;
using developwithpassion.specifications.assertions.core;
using developwithpassion.specifications.assertions.interactions;
using Machine.Specifications;
using spec = developwithpassion.specifications.use_engine<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code.web.features.list_people
{
	[Subject(typeof(Handler))]
	public class DataFetcherUsingSQLSpecs
	{
		public abstract class concern : spec.observe<IFetchDataUsingTheRequest<IEnumerable<Person>>, DataFetcherUsingSQL>
		{

		}

		public class when_fetching_data : concern
		{
			Establish e = () =>
			{
				request = fake.an<IProvideDetailsAboutAWebRequest>();
				dbCommand = fake.an<IDbCommand>();
				dbCommandBuilder = depends.on<IBuildDatabaseCommandFromAWebRequest>();
				dbCommandBuilder.setup(x => x.build_database_command(request)).Return(dbCommand);
				dbCommandExecutor = depends.on<IExecuteDatabaseCommand<IEnumerable<Person>>>();
			};

			Because b = () =>
				sut.fetch_using_request(request);

			It delegates_construction_of_a_sql_query_to_an_sql_query_builder = () =>
			{
				dbCommandBuilder.should().received(x => x.build_database_command(request));
			};

			It executes_the_query = () =>
			{
				dbCommandExecutor.should().received(x => x.execute(dbCommand));
			};

			static IProvideDetailsAboutAWebRequest request;
			static IBuildDatabaseCommandFromAWebRequest dbCommandBuilder;
			static IExecuteDatabaseCommand<IEnumerable<Person>> dbCommandExecutor;
			static IDbCommand dbCommand;
		}
	}

	public interface IBuildDatabaseCommandFromAWebRequest
	{
		IDbCommand build_database_command(IProvideDetailsAboutAWebRequest request);
	}

	public class SQLCommandBuilder : IBuildDatabaseCommandFromAWebRequest
	{
		public IDbCommand build_database_command(IProvideDetailsAboutAWebRequest request)
		{
			return new SqlCommand();
		}
	}
}
