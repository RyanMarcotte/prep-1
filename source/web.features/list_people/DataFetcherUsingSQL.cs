using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using code.prep.people;

namespace code.web.features.list_people
{
	public class DataFetcherUsingSQL : IFetchDataUsingTheRequest<IEnumerable<Person>>
	{
		private readonly IBuildDatabaseCommandFromAWebRequest dbCommandBuilder;
		private readonly IExecuteDatabaseCommand<IEnumerable<Person>> dbCommandExecutor;

		public DataFetcherUsingSQL(IBuildDatabaseCommandFromAWebRequest dbCommandBuilder, IExecuteDatabaseCommand<IEnumerable<Person>> dbCommandExecutor)
		{
			this.dbCommandBuilder = dbCommandBuilder;
			this.dbCommandExecutor = dbCommandExecutor;
		}

		public IEnumerable<Person> fetch_using_request(IProvideDetailsAboutAWebRequest request)
		{
			return dbCommandExecutor.execute(dbCommandBuilder.build_database_command(request));
		}
	}

	public interface IExecuteDatabaseCommand<Data>
	{
		Data execute(IDbCommand command);
	}
}
