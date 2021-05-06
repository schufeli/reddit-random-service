# Reddit Random (Service)
![Workflow Build](https://img.shields.io/github/workflow/status/schufeli/reddit-random-service/dotnet/main)
![Docker Build](https://img.shields.io/docker/build/schufeli/reddit-random-service)
[![License](https://img.shields.io/github/license/Schufeli/reddit-random-service)](https://en.wikipedia.org/wiki/MIT_License)

Reddit Random is a small microservice API to fetch a random Post from any requested Subreddit. Written entirely in C#, built on ASP.NET Core 3.1 with Docker support.
## 📦 Installation
A Docker image is available on the public [docker registry](https://hub.docker.com/repository/docker/schufeli/reddit-random-service) which you can use as you like. The only thing you have to provide to the container is two environment variables:
```
USER_AGENT=<Your Useragent Name>
API_KEY=<Your defined Key>
```

For the User-Agent and other API rules please consult the [Official Reddit Documentation](https://github.com/reddit-archive/reddit/wiki/API)

### Docker pull
```
docker pull schufeli/reddit-random-service
```

### Docker run
```
docker run -p "<Port>:80" --name reddit-random-service -e API_KEY="<API Key>" -e USER_AGENT="<Useragent>" reddit-random-service
```
### Docker-Compose
Please have a look at the provided [docker-compose.yml]() file.

## 🚀 How to use


