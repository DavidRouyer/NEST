using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;
using NUnit.Framework;


namespace Nest.Tests.Integration.Yaml.IndicesValidateQuery
{
	public partial class IndicesValidateQuery10BasicYaml10Tests
	{
		
		public class ValidateQueryApi10Tests
		{
			private readonly RawElasticClient _client;
			private object _body;
		
			public ValidateQueryApi10Tests()
			{
				var uri = new Uri("http:localhost:9200");
				var settings = new ConnectionSettings(uri, "nest-default-index");
				_client = new RawElasticClient(settings);
			}

			[Test]
			public void ValidateQueryApiTests()
			{

				//do indices.create 
				
				this._client.IndicesCreatePost("testing", null, nv=>nv);

				//do cluster.health 
				
				this._client.ClusterHealthGet(nv=>nv);

				//do indices.validate_query 
				
				this._client.IndicesValidateQueryGet(nv=>nv);

				//do indices.validate_query 
				_body = new {
					query= new {
						invalid_query= new {}
					}
				};
				this._client.IndicesValidateQueryPost(_body, nv=>nv);
			}
		}
	}
}