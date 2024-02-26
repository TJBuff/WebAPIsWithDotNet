# Issue Tracker API

The Company is ""

Supported list of Software.

For that supported list of software, *employees* can issue a support request

These support requests will be routed to the appropriate desktop support person for follow-up. (More on that in the Microservices Class)

What they need:

- They need the ID of the employee making the request
- They need the software the issue is with, along with the version
- They need a brief description of the issue
- When the issue was filled


## Three Vectors of API design

- The Resource
- The Method
    - GET - current representation of a resource
    - POST - 
    - PUT
    - DELETE
    - HEAD
    - others that you should be suspect of using
- The Representation

```http
POST /issues
Content-Type: application/json
Authorization: "something here that identified the User (Webguard Token)"
{
    "id": "somePerson@email.com",
    "description": "Something Broke",
    "software": "Excel"
    "softwareVersion" : "97"
}
```

```http
200 Ok
Content-Type: application/json

{
    "id": "1234567890guid",
    "description": "Soemthing Broke",
    "software": "Excel",
    "status": "Pending"
}
```