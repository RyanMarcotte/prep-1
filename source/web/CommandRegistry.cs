using System;
using System.Collections.Generic;
using System.Linq;

namespace code.web
{
  public class CommandRegistry :IFindACommandThatCanHandleARequest
  {
      private readonly IEnumerable<IHandleOneWebRequest> commands;
	  private readonly ICreateAMissingCommandWhenOneCantBeFound missingCommandObjectFactory;

	  public CommandRegistry(IEnumerable<IHandleOneWebRequest> commands, ICreateAMissingCommandWhenOneCantBeFound missingCommandObjectFactory, ICreateAMissingCommandWhenOneCantBeFound missingCommandObjectFactory1)
	  {
		  this.commands = commands;
		  this.missingCommandObjectFactory = missingCommandObjectFactory1;
	  }

	  public IHandleOneWebRequest get_command_that_can_handle(IProvideDetailsAboutAWebRequest request)
     {
         return commands.FirstOrDefault(command => command.can_process(request)) ?? missingCommandObjectFactory(request);
     }
  }
}