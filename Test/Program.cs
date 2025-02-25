using ApiService.Constants;

ApiBaseUrl apiBaseUrl = new ApiBaseUrl();
Console.WriteLine(apiBaseUrl.GetLogoAccessToken("http://172.16.9.132:32001/api/v1/token", "OBJE", "OBJE", "1"));
