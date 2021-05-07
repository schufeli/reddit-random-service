# Reddit Random (Service)
![Workflow Build](https://img.shields.io/github/workflow/status/schufeli/reddit-random/dotnet/main?label=.NET%20build)
![Docker Build](https://img.shields.io/docker/cloud/build/schufeli/reddit-random-service?label=Docker%20build)
![CodeFactor Grade](https://img.shields.io/codefactor/grade/github/schufeli/reddit-random/main?label=CodeFactor%20Grade)
![License](https://img.shields.io/github/license/schufeli/reddit-random?label=License)

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

**Important Information (please read)!!**

Because the used Reddit API Endpoint doesn't send any Ratelimiting information back. There is currently no possible resource-saving way to handle the Rate limits. So you will need to do this on your own in your application. The easiest way would be to just allow a request every second or implementing some kind of delay (60 Request per minute allowed by Reddit). It will be added as soon as there is a solution or workaround.

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
    "Subreddit": "<Subreddit Name>",
    "UserName": "<Name of the Post author>",
    "Spoiler": "<true or false>",
    "Title": "<Post Title>",
    "SelfText": "<Post Text>",
    "Permalink": "<Post Perma Link>",
    "PostLink": "<Link which is assigned to the Post>",
    "MediaSource": "<URL or Embed it depends on the Post>",
    "Gallery": "<Array of URL's>",
    "PostType": "<Table below>"
}
```

#### PostType's
| Code | Type | Description |
| --- | --- | -- |
| 0 | Image | Link to the image will be the value of MediaSource |
| 1 | Video | Link to the image will be the value of MediaSource |
| 2 | Embed | Link or IFrame Embed will be the value of MediaSource |
| 3 | Text | Will be the content of SelfText |
| 4 | Gallery | The Gallery Array will contain as Url for each image |

### Troubleshooting

When you encounter one of the following Status Code Results with a high chance they have been sent from the Reddit API and have the following meanings.

| Status Code | Description |
| --- | --- |
| 401 | Accesstoken is invalid or does not exists. |
| 403 | The Requests Subreddit does not exist. |
| 404 | The Requested Subreddit does not exist or query name was too long. |

## 🍸 Contributors
- [Sirh3e](https://github.com/sirh3e) *Refactoring and guidance.*
- [Schufeli](https://github.com/Schufeli) *Initial work.*
