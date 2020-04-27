A simple microservice project with API as the front-end service and a gRPC application for back-end service. 

**Patterns / Tech used:**
 - multi-tier / onion architecture
 - event-driven design
 - service layer pattern
 - inversion of control (IoC, DI)
 - CQRS (partially)
 - mediator pattern
 - repository pattern
 - DDD, TDD
 - c#, dotnetcore 3.1 
 - gRPC. *(this is my first time using this tech. spent most of my time exploring)*
 - docker - *due to issues with SSL, this can't be used to run the services. please refer to section "How to run locally"*
 - used a template project that I created (still in progress though):  [https://github.com/markglibres/dotnetcore-api-template/tree/master/src/workingdirectory](https://github.com/markglibres/dotnetcore-api-template/tree/master/src/workingdirectory)

 **Pre-requisites:**
  - dotnetcore 3.1 <
 - powershell or bash
 
**How to run locally**
1. open powershell or bash then clone project
```
git clone git@github.com:markglibres/job-app-deltatre.git
```
2. change directory to /job-app-deltatre/src
```
cd ./job-app-deltatre/src/
```
3.  run tests and build project with this command
```
./build.sh
```
4. run services with this command
```
./run.sh

or

./run.sh --skip-build
```
6.  open up browser to check health status of API (front-end service)
[http://localhost:5000/health](http://localhost:5000/health)
7. click Ctrl+C to stop services. *(failure to do this might not kill the process. you have to manually kill the process for ports 5000 & 50001)*

**Api endpoints**
1. Get top searched words:
	* url: [http://localhost:5000/api/words](http://localhost:5000/api/words) 
	* method: GET
2. Search for a single word:
	* url: [http://localhost:5000/api/search/[word-to-search]](http://localhost:5000/api/search/list) 
	* method: GET
	* e.g.  http://localhost:5000/api/search/list
3.  Update list of words. (will not add duplicated words)
	* url: [http://localhost:5000/api/words](http://localhost:5000/api/words) 
	* method: PATCH
	* body:
	    ```
	    { "values": [] }
	    ```
	  * e.g. 
	  ```
	  { "values": ["mynewword", "test"] }
	  ```


*NOTES for demo purposes:*
- test coverage is not 100%. 
- AutoMapper wasn't used. 
- Swagger wasn't included
- docker-compose was  the initial plan to run services, but have issues dealing with SSL within docker, so have to create shell script instead
- was planning to implement 1 simple end-to-end test using node.js & jest, but was running our of time
- data is not persisted. list of words are stored in memory. 
