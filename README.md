# Apbd test 2

To run the application, you should clone the repository and create appsettings.json according to the following structure
### appsettings.json Structure

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultDatabase": "Server=your_server;Database=your_db;User=placeholder;Password=placeholder;"
  },
  "JwtConfig": {
    "Issuer": "who issues the token",
    "Audience": "for who the token is issued",
    "Key": "key",
    "ValidInMinutes": "integer in minutes specifying how long is token valid"
  }
}
```

 The application is secured from unauthorized access, therefore in order to get the endpoint, one should authorize by sending POST /api/auth request having the following body:
 
### POST /api/auth
```json
{
  "login": "your login",
  "password": "your password"
}
```

If the access is granted, then the appropriate accessToken will be provided
# Apbd_test_2
