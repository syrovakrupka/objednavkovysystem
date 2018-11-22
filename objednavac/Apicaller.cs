using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace objednavac
{
	public class APICaller
	{
		private static readonly HttpClient client = new HttpClient();
		private static string url = "https://student.sps-prosek.cz/~hanibvi15/objednavkovysystem/";

		public APICaller()
		{

			//List<User> c = JsonConvert.DeserializeObject<List<User>>(json);

		}


		private async static Task<string> GET(string parameters)
		{
			var responseString = await client.GetAsync(url + parameters);
			string json = await responseString.Content.ReadAsStringAsync();

			return json;
		}

		public async Task<Customer> LoginUser(string email, string password)
		{
			var data = new Dictionary<string, string>();
			data.Add("action", "user_login");
			data.Add("email", email);
			data.Add("password", password);

			var result = await POST(data);

			if (result == "0")
			{

			}

			return null;
		}


		private async static Task<string> POST(Dictionary<string, string> data)
		{
			var content = new FormUrlEncodedContent(data);
			var responseString = await client.PostAsync(url, content);
			var json = await responseString.Content.ReadAsStringAsync();

			return json;
		}

	}
}
