<h1 align="center" >Basic Web Application Api Architecture</h1>
<h5> 6 layer foundation in this application and there is an initial understanding architecture. Here, login and register concepts are available for users. Each user can add, delete and make changes to some data using certain requests according to their authority.  </h5>

<h2>Core.Application</h2>
<h5> - It is the part where our abstract objects, repositories and some services are written</h5>
<h2>Core.Domain</h2>
<h5> - Entities</h5>
<h2>Core.Business</h2>
<h5> - All business managers are designed in this layer. In other words, we receive the requests via Api in this layer and return the necessary responses. Similar to the Request-response pattern, it works quite simply and requires less resources. At the same time, "mapping" and validation operations are carried out here.</h5>
<h2>Core.Security</h2>
<h5> - It is the part where we generate access tokens using JSON web token and compile user claims. Here, ``attributes'' are compiled, which request can be sent within the framework of which powers. At the same time, I tried to write more readable and understandable with certain extensions</h5>
<h2>Core.Persistence</h2>
<h5> - DbContext, Migrations - layer</h5>
<h2>Presentation.Web API</h2>



