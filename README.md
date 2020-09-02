Here is the technical test for Dare.

I've only done the minimal amount of front end because of time constraints and it wasnt really required. I used jQuery as it was mentioned on the spec. Given more time, I would not use .append to render out the videos, but use some sort of templating language, mustache or similar. 

Most of the work is done in the controller, which would not normally be done there, but I didnt get round to moving it into a services class. 

Not sure the way I am updating the nested content is the best, but it was a quick and easy way I could come up with. 

I did spot a YouTube nuget package available, I would have normally looked into using that but with having not used it before and limited time, I decided to use WebClient and Newtonsoft JSON get the playlist data.

There are magic strings that shouldn't be used, they should be defined as constants somewhere.

The playlist id, api key and no of results are all hard coded, these should be defined and editable in the CMS.