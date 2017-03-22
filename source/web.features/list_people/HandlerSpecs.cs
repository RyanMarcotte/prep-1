﻿using System.Collections.Generic;
using System.Linq;
using code.prep.people;
using developwithpassion.specifications.assertions.core;
using developwithpassion.specifications.assertions.interactions;
using Machine.Specifications;
using spec = developwithpassion.specifications.use_engine<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code.web.features.list_people
{
  [Subject(typeof(Handler))]
  public class HandlerSpecs
  {

    public abstract class concern : spec.observe<IImplementAUserStory, Handler>
    {
        
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideDetailsAboutAWebRequest>();
        response = depends.on<ISendResponsesToTheClient>();
        data = Enumerable.Range(1, 100).Select(x => new Person());
		data_fetcher = depends.on<IFetchDataUsingTheRequest<IEnumerable<Person>>>();
		data_fetcher.setup(x => x.fetch_using_request(request)).Return(data);
      };

      Because b = () =>
        sut.process(request);

      It gives_the_list_of_people_to_the_response = () =>
        response.should().received(x => x.send(data));

      static IProvideDetailsAboutAWebRequest request;
	  static IFetchDataUsingTheRequest<IEnumerable<Person>> data_fetcher;
	  static ISendResponsesToTheClient response;
      static IEnumerable<Person> data;
    }
  }
}