# Reddit Random (Service)
![Workflow Build](https://img.shields.io/github/workflow/status/schufeli/reddit-random/dotnet/main)
![Docker Build](https://img.shields.io/docker/build/schufeli/reddit-random-service)
[![License](https://img.shields.io/github/license/Schufeli/reddit-random)](https://en.wikipedia.org/wiki/MIT_License)

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
Please have a look at the provided [docker-compose.yml](https://github.com/Schufeli/reddit-random/blob/create-release-version/docker-compose.yml) file.

## 🚀 How to use
__Please note, for the Service to function properly you will need to provide a valid Reddit Access token with at least the read scope.__

If you need to know how to get a Reddit Access token please consult this [Guide](https://github.com/reddit-archive/reddit/wiki/OAuth2) 

### Request a Post
To fetch a Post from the Service you will need to send an HTTP GET Request to your hosted Reddit Random Service (I will use localhost in the following examples!).

``` 
https://localhost<:Port>/reddit/<Subreddit> 
```

You also have to add two additional Headers to your Request use the following table as a reference.

| Name | Value |
| --- | --- |
| ApiKey | Your defined Apikey (See Installation) |
| AccessToken | Valid Reddit Api Accesstoken |

### Response
If your request was successful you will get a JSON object which is similar to the following example with the description of each element.

```json
{
    "Subreddit": "skyrim",
    "UserName": "t3_n533j2",
    "Spoiler": false,
    "Title": "Anybody killed Aerin? I married Mjoll the Lioness &amp; everytime I come home from killing some faithless Imperials he's there following Mjoll around. like a white night/simp/cuck. One time I waited for Aerin to wake up followed him outside of town killed him &amp; dragged him into the lake.",
    "SelfText": "",
    "Permalink": "/r/skyrim/comments/n533j2/anybody_killed_aerin_i_married_mjoll_the_lioness/",
    "PostLink": "https://i.redd.it/1mrqvjph87x61.png",
    "MediaSource": "https://preview.redd.it/1mrqvjph87x61.png?auto=webp&s=1fdfa172be69633fca8002b559a4eee85b056b03",
    "Gallery": null,
    "PostType": 0
}
```