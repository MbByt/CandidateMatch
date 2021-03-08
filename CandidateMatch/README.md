## Table of contents
* [General info](#General-info)
* [Technologies](#Technologies)
* [Project architecture](#Architecture)
* [Running the Project](#Run)

## General info
This project selects the best candidate for a job among the candidates provided by JobAdder Candidate API.
The best candidate is matched with a provided job of JobAdder Job API based on Skill Tags.
This project exposes one standard RESTfull APIs:
api/bestCandidate/{JobId} where {JobId} is the Id of a desired Job.
Sample of data returnd by this API in JSON format:
{
	"candidateId":34,
	"name":"Fay Atwater",
	"skillTags":"mobile, hr-admin, carpentry, sterilisation, housekeeping",
	"skillTagsList":["mobile"," hr-admin"," carpentry"," sterilisation"," housekeeping"]
}



## Technologies
Project was created with:
* Microsoft.aspnetcore.app version: 2.1.1
* microsoft.aspnetcore.mvc.core version: 2.1.1
* Nunit  version: 3.10.1 
* Nunit3testadapter version:3.10.0

## Architecture
This project has been created based on SOLID principal and has been covered by unit test cases.
Also, the type of dependency injection that aids scaling and maintenance is construction injection which is supported by default by .Net core.
This Solution has been organized into the following projects:
CandidateMatch.Common :
Common and global solution tools and configuration are created in this project including but limited to:
Helper Classes, Enums, Configuration Classes and Extension Classes

CandidateMatch.Data:
Data layer items of the solution are created in this project including :
Context,DataModel,Dtos,Entities,Models.

CandidateMatch.Services:
This project consists of the business logic of the solution containing the Candidate Matching service.

CandidateMatch.Tests:
This project provides the test cases that cover all of the API with a different range of sample inputs.

CandidateMatch.Web:
This project is the home of RESTfull API:bestCandidate.

## Run
To run this project, Open it in Visual Studio 2017 and compile it. Then Run the CandidateMatch.Web to initiate the api/bestCandidate API.
Then the API is ready to receive HTTP Get Requests at http://yourHostDomain:Port/api/bestCandidate/{JobId} Endpoint.
where {JobId} is the Id of a desired Job between 1 to 15.
