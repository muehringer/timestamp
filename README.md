# TimeStamp - HackerNews

#### Download Code

Using git

```bash
git clone https://github.com/muehringer/timestamp.git
```

Or could to do the Download [here](https://github.com/muehringer/timestamp/archive/master.zip)


### Content

<p>Folder Docs:
<p>Requirements
<p>ReadMe
  
<p>Folders of Solutions:
<p>Code in .NET Core 2.2 - C# Sharp, Swagger, Rest, API, AutoMapper, JTW - Json Web Token, Data Compression of API, DDD concepts, Dependency injection native of .Net Core

### Load the API with Swagger
  
<p> URL : http://localhost:63051/swagger/index.html

#### Using APIs

<p>First you must use the Token service informing email and password, the email being the same as the password, only for demonstration of JWT.<br>
<p>If the email and password are correct, a valid Token will be generated.<br>
<p>To access the HackerNews API, you must pass the header (Header) Authorization: Bearer + Generate Token, otherwise you will not be allowed access.<br>
  
#### For large numbers of requests

<p>All calls are asynchronous, remembering that it can be improved with the use of cache, for example Redis and call policy retry.



## Licence

Source code can be found on [github](https://github.com/georgeOsdDev/markdown-edit), licenced under [MIT](http://opensource.org/licenses/mit-license.php).

Developed by [Alexandre Muehringer Alves](https://github.com/muehringer)

