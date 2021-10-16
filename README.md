# maskify
Masking sensitive data

<h2>Request &amp; Response Examples</h2>
<h3>POST /api/mask</h3>

<p>Request  body:</p>
<pre><code>
{
  "Model": {
    "Id": "e49118cd-5a4a-4572-afa8-1ec7516ed2cc",
    "IdentityNumber": "12345678901",
    "Email": "mustafa.ozdemir@maskify.com",
    "Name": "Mustafa",
    "LastName": "Ozdemir",
    "Phone": "+905555555555",
    "BirthDate": "1986-10-19T00:00:00",
    "Address": "Istanbul / Turkiye"
  },
  "ReplacedJsonKeyValues": "{\"IdentityNumber\":\"Censored\",\"Email\":\"\",\"Phone\":\"\",\"Address\":\"\"}",
  "Replacement": "*"
}
</code></pre>

<p>Response body:</p>
<pre><code>
{
  "data": [
    {
      "id": "e49118cd-5a4a-4572-afa8-1ec7516ed2cc",
      "identityNumber": "Censored",
      "email": "m**************@maskify.com",
      "name": "Mustafa",
      "lastName": "Ozdemir",
      "phone": "+9055******55",
      "birthDate": "1986-10-19T00:00:00",
      "address": "I*****************"
    }
  ]
}
</code></pre>

#### <h2>Example usage:</h2>

```csharp

Request requestModel = new Request
{
    Model = new UserDetailModel
    {
        Id = Guid.NewGuid(),
        IdentityNumber = "12345678901",
        Email = "mustafa.ozdemir@maskify.com",
        Name = "Mustafa",
        LastName = "Ozdemir",
        BirthDate = new DateTime(1986, 10, 19),
        Phone = "+905555555555",
        Address = "Istanbul / Turkiye"
    },
    ReplacedJsonKeyValues = "{\"IdentityNumber\":\"Censored\",\"Email\":\"\",\"Phone\":\"\",\"Address\":\"\"}",
    Replacement = "*"
};

HttpClient _httpClient = new HttpClient
{
    BaseAddress = new Uri("http://localhost:49899/")
};

_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

var request = new HttpRequestMessage(HttpMethod.Post, "v1/mask")
{
    Content = new StringContent(JsonSerializer.Serialize(requestModel), Encoding.UTF8, "application/json")
};

HttpResponseMessage response = await _httpClient.SendAsync(request);
string contentResponse = await response.Content.ReadAsStringAsync();

```
